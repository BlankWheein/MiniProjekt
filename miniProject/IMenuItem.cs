using System.Collections.Generic;

namespace miniProject
{
    partial class Program
    {
        interface IMenuItem
        {
            string Title { get; set; }
            string Content { get; set; }
            IMenuItem Parent { get; set; }
            List<IMenuItem> items { get; set; }
            void Add(IMenuItem item);
            int Draw(int index, int SelectedIndex);
            void Execute();

        }
    }
}
