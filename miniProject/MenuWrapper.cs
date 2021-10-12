using System;
using System.Collections.Generic;

namespace miniProject
{
    partial class Program
    {
        class MenuWrapper
        {
            int SelectedIndex = 0;
            private int _width, _height;
            int MaxItems = -1;
            private bool _running;
            private List<IMenuItem> items = new();
            IMenuItem ItemToDraw = null;
            List<IMenuItem> History = new() { };
            public void Add(IMenuItem item)
            {
                items.Add(item);
            }

            public void Start()
            {
                _running = true;
                _width = Console.WindowWidth;
                _height = Console.WindowHeight;
                #pragma warning disable CA1416 // 플랫폼 호환성 검증
                Console.SetWindowSize(_width, _height);
                #pragma warning restore CA1416 // 플랫폼 호환성 검증
                while (_running)
                {
                    Draw();
                    HandleInput();
                }
            }

            private void Draw()
            {
                int index = 0;
                if (ItemToDraw == null)
                {
                    for (int i = 0; i < items.Count; i++)
                    {
                        IMenuItem item = items[i];
                        index = item.Draw(index, SelectedIndex);

                    }
                    MaxItems = index - 1;
                }
                else
                {
                    for (int i = 0; i < ItemToDraw.items.Count; i++)
                    {
                        index = ItemToDraw.items[i].Draw(index, SelectedIndex);
                    }
                    MaxItems = index - 1; 
                }
            }
            public void StepBack()
            {
                IMenuItem item;
                item = History[History.Count - 1];
                if (History.Count - 1 != 0) { History.RemoveAt(History.Count - 1); }
                ItemToDraw = item;
                SelectedIndex = 0;
                Console.Clear();
            }
            public void Home()
            {
                IMenuItem item;
                item = History[0];
                History = new() { null };
                ItemToDraw = item;
                SelectedIndex = 0;
                Console.Clear();
            }
            public void Enter()
            {
                IMenuItem item;
                item = GetSelectedItem();
                ItemToDraw = item;
                History.Add(item.Parent);
                SelectedIndex = 0;
                Console.Clear();
                if (item is Menu || item is null) { return; }
                item.Execute();
            }
            public void MoveUp()
            {
                SelectedIndex = Math.Max(SelectedIndex - 1, 0);
            }
            public void MoveDown()
            {
                SelectedIndex = Math.Min(SelectedIndex + 1, MaxItems);
            }

            public void HandleInput()
            {
                ConsoleKeyInfo info = Console.ReadKey();
                switch (info.Key)
                {
                    case (ConsoleKey.Escape):
                        _running = false;
                        break;
                    case (ConsoleKey.DownArrow):
                        MoveDown();
                        break;
                    case (ConsoleKey.UpArrow):
                        MoveUp();
                        break;
                    case (ConsoleKey.Backspace):
                        StepBack();
                        break;
                    case (ConsoleKey.Enter):
                        Enter();
                        break;
                    case (ConsoleKey.Home):
                        Home();
                        break;
                }
            }
            public IMenuItem GetSelectedItem()
            {
                int index = 0;
                if (ItemToDraw == null)
                {
                    for (int i = 0; i < items.Count; i++)
                    {
                        IMenuItem item = items[i];
                        if (index == SelectedIndex)
                        {
                            return item;
                        }
                        index++;
                    }
                }
                else
                {
                    for (int i = 0; i < ItemToDraw.items.Count; i++)
                    {
                        IMenuItem item = ItemToDraw.items[i];
                        if (index == SelectedIndex)
                        {
                            return item;
                        }
                        index++;
                    }
                }
                return ItemToDraw;

            }

        }
    }
}
