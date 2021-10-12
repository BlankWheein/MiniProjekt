using System;
using System.Collections.Generic;

namespace MiniOpgave
{
    


    class MenuWrapper
    {
        private (int, int) xy = new(0, 0);
        public int SelectedIndex {  get; set; }
        public List<IMenuItem> Menues { get; set; } = new();

        public bool Started {  get; set; }
        public MenuWrapper(bool Started=false)
        {
            this.Started = Started;
        }
        public void Start()
        {
            Started = true;
            while (Started)
            {
                Draw();
                ConsoleKey keyPress = HandleInput();
                int MenuCount = 0;
                for (int i = 0; i < Menues.Count; i++)
                {
                    MenuCount += Menues[i].Menues.Count;
                }
                switch(keyPress)
                {
                    case (ConsoleKey.Escape):
                        Started = false;
                        break;
                    case (ConsoleKey.DownArrow):
                        SelectedIndex = Math.Min(SelectedIndex + 1, MenuCount - 1);
                        break;
                    case (ConsoleKey.UpArrow):
                        SelectedIndex = Math.Max(SelectedIndex - 1, 0);
                        break;
                }
            }
        }
        

        public void Add(IMenuItem menuItem)
        {
            Menues.Add(menuItem);
        }
        public void Draw()
        {

            int index = 0;
            for (int i = 0; i < Menues.Count; i++)
            {
                IMenuItem item = Menues[i];
                item.Draw(index);
                index++;
                for (int j = 0; j < item.Menues.Count; j++)
                {
                    item.Menues[j].Draw(index);
                    index++;
                }
            }
            
        }

        public void Select()
        {
            throw new NotImplementedException();
        }
    }
}