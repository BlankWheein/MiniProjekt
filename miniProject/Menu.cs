using System;
using System.Collections.Generic;

namespace miniProject
{
    partial class Program
    {
        class Menu : IMenuItem
        {
            public string Title { get; set; }
            public string Content { get; set; }
            public IMenuItem Parent { get; set; }
            public List<IMenuItem> items { get; set; } = new();

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
                throw new NotImplementedException();
            }

            public Menu(string Title)
            {
                this.Title = Title;
            }
        }
    }
}
