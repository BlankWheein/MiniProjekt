using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace miniProject
{
    partial class Program
    {
        class FileSystemItem : IMenuItem
        {
            public string Title { get; set; }

            private string directoryInfo;
            private bool _executed { get; set; } = false;

            public string Content { get; set; }
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
                Add(new MethodMenuItem("Read", () =>
                {
                    try
                    {
                        string text = System.IO.File.ReadAllText(directoryInfo);
                        if (text.Length > 100000)
                        {
                            Console.WriteLine("File is too big, open with Windows instead");
                        } else
                        {
                            Console.WriteLine(text);
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Cannot Access this file");
                    }
                }));
                Add(new MethodMenuItem("Open with Windows", () =>
                {
                    try
                    {
                        var process = new Process
                        {
                            StartInfo = new ProcessStartInfo()
                            {
                                UseShellExecute = true,
                                FileName = @$"{directoryInfo}"
                            }
                        };
                        process.Start();
                        Console.WriteLine($"Opened File @{directoryInfo}");
                    }
                    catch (InvalidCastException)
                    {
                        throw;
                    }
                    catch (Exception ex)
                    {
                        
                    }
                }));
                _executed = true; 
            }
            public FileSystemItem(string Title, string directoryInfo)
            {
                this.Title = Title;
                this.directoryInfo = directoryInfo;
            }
        }

    }
}
