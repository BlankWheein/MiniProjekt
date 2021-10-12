using System;
using System.Collections.Generic;

namespace miniProject
{
    partial class Program
    {
        class MenuItem : IMenuItem
        {
            public string Title { get; set; }
            public string Content { get; set; }
            public IMenuItem Parent { get; set; }
            public List<IMenuItem> items { get; set; } = new();

            public void Add(IMenuItem item)
            {
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

            }

            public MenuItem(string Title)
            {
                this.Title = Title;
            }
            public MenuItem(string Title, string Content) : this(Title)
            {
                this.Content = Content;
            }
        }

    }
}
