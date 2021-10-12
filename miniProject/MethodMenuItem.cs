using System;
using System.Collections.Generic;

namespace miniProject
{
    partial class Program
    {
        public delegate void Action<in T>(T obj);
        class MethodMenuItem : IMenuItem
        {
            public string Title { get; set; }
            public string Content { get; set; }
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
                if (action != null)
                    action();
            }
            public MethodMenuItem(string Title) 
            {
                this.Title = Title;
            }
            public MethodMenuItem(string Title, Action method) : this(Title)
            {
                if (method is null)
                {
                    throw new ArgumentNullException(nameof(method));
                }
                action = method;
            }
            public MethodMenuItem(string Title, Action method, string Content) : this(Title, method)
            {
                this.Content = Content;
            }
        }

    }
}
