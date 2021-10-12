using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.ServiceModel.Syndication;
using System.Xml;

namespace miniProject
{
    partial class Program
    {
        class RSSMenu : IMenuItem
        {
            public string Title { get; set; }
            public string Content { get; set; }
            public string URL { get; private set; }
            private Action action { get; set; }
            private bool _executed { get; set; } = false;
            public IMenuItem Parent { get; set; }
            public List<IMenuItem> items { get; set; } = new();
            public void Add(IMenuItem item)
            {
                item.Parent = this;
                items.Add(item);
            }
            private int DrawSelf(int index, int SelectedIndex)
            {
                string s = Title;
                Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, index);
                ConsoleColor color = SelectedIndex == index ? ConsoleColor.Green : ConsoleColor.Gray;
                Console.ForegroundColor = color;
                Console.WriteLine(s);
                index++;
                return index;
            }
            public int Draw(int index, int SelectedIndex)
            {

                index = DrawSelf(index, SelectedIndex);
                return index;
            }

            public void Execute()
            {
                if (_executed) { return; }
                _executed = true;
                XmlReader reader = XmlReader.Create(URL);
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                reader.Close();
                foreach (SyndicationItem item in feed.Items)
                   {
                    Add(new MethodMenuItem(item.Title.Text, () =>
                    {
                        OpenUrl(item.Links[0].Uri.ToString());
                        const UInt32 WM_KEYDOWN = 0x0100;
                        const int VK_BACK = 0x08;

                        [DllImport("user32.dll")]
                        static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);

                        Process[] processes = Process.GetProcessesByName("VsDebugConsole");

                        foreach (Process proc in processes)
                            PostMessage(proc.MainWindowHandle, WM_KEYDOWN, VK_BACK, 0);
                    }));
                   }
            }
            private void OpenUrl(string uri)
            {
                var psi = new ProcessStartInfo();
                psi.UseShellExecute = true;
                psi.FileName = uri;
                Process.Start(psi);
            }
            public RSSMenu(string Title)
            {
                this.Title = Title;
            }
            public RSSMenu(string Title, string URL) : this(Title)
            {
                this.URL = URL;
            }
        }

    }
}
