using System.IO;
using System;

namespace miniProject
{
    partial class Program
    {
        static void Main(string[] args)
        {
            MenuWrapper wrapper = new();
            InfinityMenu menu = new("Infinity Menu");
            Menu newmenu = new("FancyMenu");
            newmenu.Add(new MethodMenuItem("Point1", () => {
                Console.WriteLine("Hello there");
            }));
            newmenu.Add(new MenuItem("Point2"));
            newmenu.Add(new MenuItem("Point3"));
            newmenu.Add(new MenuItem("Point4"));
            newmenu.Add(new MenuItem("Point5"));
            wrapper.Add(menu);
            wrapper.Add(newmenu);
            Menu DriveMenu = new("Browse PC files");
            DriveMenu.Add(new FileSystemMenu("Browse my C-Drive", @"C:\"));
            DriveMenu.Add(new FileSystemMenu("Browse my D-Drive", @"D:\"));
            DriveMenu.Add(new FileSystemMenu("Browse my E-Drive", @"E:\"));
            DriveMenu.Add(new FileSystemMenu("Browse my F-Drive", @"F:\"));
            wrapper.Add(DriveMenu);
            wrapper.Add(new RSSMenu("DR", "https://www.dr.dk/nyheder/service/feeds/senestenyt"));
            wrapper.Add(new MenuItem("Menu Item with no Folder"));
            wrapper.Add(new MethodMenuItem("Controls", () => {
                Console.WriteLine("'Down/Up' Arrow to navigate");
                Console.WriteLine("'Backspace' to step back a level");
                Console.WriteLine("'Enter' to enter a folder/file");
                Console.WriteLine("'Home' to go back to main menu");
                Console.WriteLine("'ESC' to stop program");
            }));
            wrapper.Start();
        }
    }
}
