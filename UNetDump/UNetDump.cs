using Newtonsoft.Json;
using Rocket.Core.Plugins;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace UNetDump
{
    public class UNetDump : RocketPlugin
    {
        public void DumpAsm()
        {
            var bindAll = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;
            var dump = new ObjectDump();
            var index = 0;
            var blacklist = new string[]
            {
                "system",
                "mscorlib",
                "unity",
                "mono",
                "microsoft"
            };

            var asms = AppDomain.CurrentDomain.GetAssemblies().Where((x) =>
            {
                var d = x.FullName.ToLower();
                return !(blacklist.Any(y => d.Contains(y)));
            }).ToArray();
            foreach (var asm in asms)
            {
                index++;
                Console.WriteLine($"Dumping asm {index}/{asms.Length}: {asm.FullName}");
                var asmDump = new AssemblyDump()
                {
                    AssemblyName = asm.GetName().Name
                };
                dump.Assemblies.Add(asmDump);
                try
                {
                    foreach (var typ in asm.GetTypes().Where(x => !x.IsInterface && !x.IsGenericType))
                    {
                        var aType = new AssemblyType()
                        {
                            TypeID = Convert.ToBase64String(typ.GUID.ToByteArray()),
                            Name = typ.FullName
                        };

                        foreach (var f in typ.GetFields(bindAll))
                        {
                            aType.Fields.Add(new AssemblyField()
                            {
                                TypeID = Convert.ToBase64String(f.FieldType.GUID.ToByteArray()),
                                TypeName = f.FieldType.FullName,
                                Name = f.Name,
                                Private = f.IsPrivate,
                                Static = f.IsStatic
                            });
                        }

                        foreach (var f in typ.GetProperties(bindAll))
                        {
                            aType.Fields.Add(new AssemblyField()
                            {
                                TypeID = Convert.ToBase64String(f.PropertyType.GUID.ToByteArray()),
                                TypeName = f.PropertyType.FullName,
                                Name = f.Name,
                                Private = f.CanRead ? f.GetMethod.IsPrivate : true,
                                Static = f.CanRead ? f.GetMethod.IsStatic : false
                            });
                        }

                        foreach (var m in typ.GetMethods(bindAll))
                        {
                            aType.Methods.Add(new AssemblyMethod()
                            {
                                TypeID = Convert.ToBase64String(m.ReturnType.GUID.ToByteArray()),
                                Name = m.Name,
                                TypeName = m.ReturnType.FullName,
                                Parameters = m.GetParameters().Select(x => $"{x.ParameterType.FullName} {x.Name}").ToList()
                            });
                        }

                        asmDump.Types.Add(aType);
                    }
                }
                catch (Exception)
                {
                }
            }
            Console.WriteLine("writing...");
            File.WriteAllText(Path.Combine(Directory, "Assemblies.json"), JsonConvert.SerializeObject(dump, Formatting.Indented));
            Console.WriteLine("Done.");
        }

        public void DumpNet()
        {
            var handlers = new List<NetMethod>();
            foreach (var type in typeof(Provider).Assembly.GetTypes())
            {
                if (type.IsClass && !type.IsAbstract)
                {
                    foreach (var f in type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static))
                    {
                        if (typeof(ClientMethodHandle).IsAssignableFrom(f.FieldType) && f.IsStatic)
                        {
                            ClientMethodHandle handle = (ClientMethodHandle)f.GetValue(null);

                            ClientMethodInfo info = handle.Reflect<ClientMethodInfo>("clientMethodInfo");

                            var declaringType = info.Reflect<Type>("declaringType");

                            var name = info.Reflect<string>("name");   // handler name

                            var customAttribute = info.Reflect<SteamCall>("customAttribute");

                            var writeMethodInfo = info.Reflect<MethodInfo>("writeMethodInfo");

                            var handlerMethod = declaringType.GetMethod(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.IgnoreCase);

                            handlers.Add(new NetMethod()
                            {
                                DeclaringType = type.FullName,
                                Handler = name,
                                SendHandle = f.Name,
                                SentBy = "Server",
                                LegacyName = customAttribute.legacyName,
                                Parameters = handlerMethod == null ? "" : string.Join(", ", handlerMethod.GetParameters().Select(x => $"{x.ParameterType.Name} {x.Name}"))
                            });
                        }
                        else if (typeof(ServerMethodHandle).IsAssignableFrom(f.FieldType) && f.IsStatic)
                        {
                            var handle = (ServerMethodHandle)f.GetValue(null);

                            var info = handle.Reflect<ServerMethodInfo>("serverMethodInfo");

                            var declaringType = info.Reflect<Type>("declaringType");

                            var name = info.Reflect<string>("name");   // handler name

                            var customAttribute = info.Reflect<SteamCall>("customAttribute");

                            var writeMethodInfo = info.Reflect<MethodInfo>("writeMethodInfo");

                            var handlerMethod = declaringType.GetMethod(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.IgnoreCase);

                            handlers.Add(new NetMethod()
                            {
                                DeclaringType = type.FullName,
                                Handler = name,
                                SendHandle = f.Name,
                                SentBy = "Client",
                                LegacyName = customAttribute.legacyName,
                                Parameters = handlerMethod == null ? "" : string.Join(", ", handlerMethod.GetParameters().Select(x => $"{x.ParameterType.Name} {x.Name}"))
                            });
                        }
                    }
                }
            }

            File.WriteAllText(Path.Combine(Directory, "UnturnedNetMethods.json"), JsonConvert.SerializeObject(handlers, Formatting.Indented));
        }

        public override void LoadPlugin()
        {
            base.LoadPlugin();
            DumpNet();
            DumpAsm();
        }
    }
}