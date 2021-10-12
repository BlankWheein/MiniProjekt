using System;

namespace MiniOpgave
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuWrapper menu = new();
            Menu undermenu2 = new("Menu1");
            undermenu2.Add(new MenuItem("Punkt1", "Indhold af punkt 1... det er indtil videre bare tekst"));
            undermenu2.Add(new MenuItem("Punkt2", "Indhold af punkt 2... det er indtil videre bare tekst"));
            undermenu2.Add(new MenuItem("Punkt3", "Indhold af punkt 3... det er indtil videre bare tekst"));
            Menu undermenu = new("Menu2");
            undermenu.Add(new MenuItem("TestPunk1", "content"));
            undermenu.Add(new MenuItem("TestPunk2", "content"));
            menu.Add(undermenu2);
            menu.Add(undermenu);
            menu.Start();
        }
    }



}
