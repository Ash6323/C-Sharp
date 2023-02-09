using System;

namespace Properties
{
    public class MyFile2
    {
        public void Properties()
        {
            
            Console.BackgroundColor= ConsoleColor.Yellow;
            Console.ForegroundColor= ConsoleColor.Blue;
            Console.Title = "Experiemting with Console class Properties";
            Console.Beep();

            Console.WriteLine("Title is changed");
            Console.WriteLine("Background color is set to be Yellow");
            Console.WriteLine("Foreground color is set to be Blue");
            Console.WriteLine("A Beep is also heard (Using Beep() method");

        }
    }

}
