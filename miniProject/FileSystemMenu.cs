using System;
using System.Collections.Generic;
using System.IO;

namespace miniProject
{
    partial class Program
    {
        class FileSystemMenu : IMenuItem
        {
            private string directoryInfo;

            public string Title { get; set; }
            public string Content { get; set; }
            public IMenuItem Parent { get; set; }
            public List<IMenuItem> items { get; set; } = new();
            private bool _executed = false;

            public int Draw(int index, int SelectedIndex)
            {
                string s = $"[[{Title}]]";
                Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, index);
                ConsoleColor color = SelectedIndex == index ? ConsoleColor.DarkYellow : ConsoleColor.Yellow;
                Console.ForegroundColor = color;
                Console.WriteLine(s);
                index++;
                return index;
            }

            public void Add(IMenuItem item)
            {
                item.Parent = this;
                items.Add(item);
            }
            public void Execute()
            {
                if (_executed) { return; }
                _executed = true;
                try
                {
                    foreach (string entry in Directory.GetDirectories(directoryInfo))
                    {
                        AddFileSystemInfoAttributes(new DirectoryInfo(entry));
                    }
                    foreach (string entry in Directory.GetFiles(directoryInfo))
                    {
                        AddFileSystemInfoAttributes(new FileInfo(entry));
                    }
                }
                catch (Exception)
                {
                    
                }
            }
            private FileSystemMenu(string Title)
            {
                this.Title = Title;

            }

            public FileSystemMenu(string Title, string directoryInfo) : this(Title)
            {
                this.directoryInfo = directoryInfo;
            }
            public void AddFileSystemInfoAttributes(FileSystemInfo fsi)
            {
                if ((fsi.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    FileSystemMenu newMenu = new(fsi.FullName, fsi.FullName);
                    Add(newMenu);
                } else
                {
                    string Title = String.Format("{0}", fsi.FullName);
                    Add(new FileSystemItem(Title, fsi.FullName));
                }
                
            }
        }
    }
}
