using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace UNetBrowser
{
    public partial class LoadForm : Form
    {
        private delegate void RequestCallback(List<NetMethod> methods);

        private delegate void ErrorCallback(Exception exception);

        public LoadForm()
        {
            InitializeComponent();
        }

        private void OnWindowLoaded(object sender, EventArgs e)
        {
            Debug.WriteLine("Init Request...");
            ThreadPool.QueueUserWorkItem(async (_) =>
            {
                Debug.WriteLine("Running Request...");

                try
                {
                    var request = WebRequest.CreateHttp("https://projects.shimmymysherbet.com/UNetDumper/UnturnedNetMethods.json");
                    request.Method = "GET";
                    Debug.WriteLine("Reading Request...");

                    using (var result = await request.GetResponseAsync())
                    using (var stream = new StreamReader(result.GetResponseStream()))
                    {
                        var json = await stream.ReadToEndAsync();
                        Debug.WriteLine("Deserialize...");

                        var methods = JsonConvert.DeserializeObject<List<NetMethod>>(json);
                        Debug.WriteLine($"Loaded {methods.Count} net methods from remote server, callback...");
                        Invoke((RequestCallback)RequestCompleteCallback, methods);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error during request: {ex.Message}");
                    Debug.WriteLine(ex.StackTrace);
                    Invoke((ErrorCallback)RequestErrorCallback, ex);
                }

                Debug.WriteLine($"request task complete.");
            });
        }

        private void RequestCompleteCallback(List<NetMethod> methods)
        {
            Debug.WriteLine($"Request callback recieved, creating browser...");

            var browser = new NetBrowser(methods);
            browser.FormClosed += OnBrowserExited;
            Debug.WriteLine($"Showing...");

            browser.Show();
            Debug.WriteLine($"Switching...");

            Hide();
            browser.BringToFront();
            browser.Focus();
            Debug.WriteLine($"Done.");
        }

        private void OnBrowserExited(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void RequestErrorCallback(Exception exception)
        {
            MessageBox.Show($"Failed to download Net Method Index.\n\n Error: {exception.Message}\nStacktrace:\n{exception.StackTrace}\n\nIf this issue persists, contact ShimmyMySherbet#5694 on Discord");
            Application.Exit();
        }
    }
}