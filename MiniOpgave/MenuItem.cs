using System;
using System.Collections.Generic;

namespace MiniOpgave
{
    internal class MenuItem : IMenuItem
    {
        public string Content { get; set; }
        public string Title {  get; set; }
        public List<IMenuItem> Menues { get; set; } = new();

        public MenuItem(string Title, string Content)
        {
            this.Content = Content;
            this.Title = Title;
        }

        public void Draw(int index)
        {
            string s = item.Title;
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, index);
            ConsoleColor color = SelectedIndex == index ? ConsoleColor.Green : ConsoleColor.Gray;
            Console.ForegroundColor = color;
            Console.WriteLine(s);
        }
    }
    class Menu : IMenuItem
    {
        public List<IMenuItem> Menues { get; set; } = new();
        public string Title { get; set; }
        public string Content { get; set; }

        public void Add(IMenuItem item)
        {
            Menues.Add(item);
        }

        public Menu(string Title)
        {
            this.Title = Title;
        }

        public int Draw(int index, int SelectedIndex)
        {
            string s = Title;
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2 + 10, Math.Max(index-1, 0));
            ConsoleColor color = ConsoleColor.Yellow;
            Console.ForegroundColor = color;
            Console.WriteLine(s);
            for (int i = 0; i < Menues.Count; i++)
            {
                s = Menues[i].Title;
                Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2 + 10, index);
                color = SelectedIndex == index ? ConsoleColor.Green : ConsoleColor.Gray;
                Console.ForegroundColor = color;
                Console.WriteLine(s);
                index++;
            }
            return index;
        }

    }

    interface IMenuItem
    {
        public List<IMenuItem> Menues { get; set; }
        public int Draw(int index, int SelectedIndex);
        string Content { get; set; }
        string Title { get; set; }
    }
}