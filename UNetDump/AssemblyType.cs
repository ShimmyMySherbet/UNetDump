using System.Collections.Generic;

namespace UNetDump
{
    public class AssemblyType
    {
        public string Name;
        public string TypeID;

        public List<AssemblyField> Fields = new List<AssemblyField>();
        public List<AssemblyMethod> Methods = new List<AssemblyMethod>();
    }
}