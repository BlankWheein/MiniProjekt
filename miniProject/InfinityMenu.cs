using System;
using System.Collections.Generic;

namespace miniProject
{
    partial class Program
    {
        class InfinityMenu : IMenuItem
        {
            public string Title { get; set; }
            public string Content { get; set; }
            public List<IMenuItem> items { get; set; } = new();
            public IMenuItem Parent { get; set; }
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
                for (int i = 0; i < 6; i++)
                {
                    Add(new InfinityMenu(Title));
                }
                _executed = true;
            }
            public InfinityMenu(string Title)
            {
                this.Title = Title;

            }
        }
    }
}
