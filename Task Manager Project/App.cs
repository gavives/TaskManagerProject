using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager_Project
{
    class App
    {
        private List<string> tasks = new List<string>();
        private List<bool> isActioned = new List<bool>();

        public App()
        {
            Console.OutputEncoding = Encoding.Unicode;

            ReadListFromFile();
        }

        public void Run()
        {
            bool quit;

            do
            {
                PrintTaskList();
                var key = RunInputCycle();
                quit = HandleUserInput(key); 

            } while (!quit);


            WriteListToFile();

            Console.WriteLine(); //Ensures "press any key to quit..." is on its own line


        }

        private ConsoleKey RunInputCycle()
        {
            ConsoleKey key;
            
             PrintUsageOptions();
             key = GetInputFromUser();

            return key;
        }

        private bool HandleUserInput(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.A:
                    InputTaskToList();
                    break;
                case ConsoleKey.D:
                    break;
                case ConsoleKey.N:
                    break;
                case ConsoleKey.DownArrow:
                    break;
                case ConsoleKey.Enter:
                    break;
                case ConsoleKey.Q:
                    return true;
                    
            }

            return false;
        }

        private ConsoleKey GetInputFromUser()
        {
            return Console.ReadKey().Key;
        }

        private void PrintUsageOptions()
        {
            Console.WriteLine("a: add | n: next page | d: delete | enter: action | \u2193: select | q: quit");
            Console.Write("Input:");
        }

        private void InputTaskToList()
        {
            Console.Clear();
            Console.Write("Add a new task (Empty to cancel): ");

            var input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input)) 
            {
                tasks.Add(input);
            }
            
        }

        private void PrintTaskList()
        {
            Console.Clear();

            foreach (var t in tasks)
            {
                Console.WriteLine(t);
            }

            Console.WriteLine();
        }

        private void ReadListFromFile()
        {
            

            try
            {

                using (StreamReader sr = new StreamReader(@"C:\Users\Default\Documents\TaskManager.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        var input = sr.ReadLine();

                        var splits = input.Split(new Char[] { '\x1e' });

                        if (splits.Length == 2)
                        {
                            tasks.Add(splits[0]);
                            isActioned.Add(bool.Parse(splits[1]));
                        }

                        

                    }
                }
            }
            catch (FileNotFoundException)
            {; }

           
        }

        private void WriteListToFile()
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Default\Documents\TaskManager.txt"))
            {
                
                {
                    for (int i = 0; i < tasks.Count; ++i) 
                {
                    sw.WriteLine($"{ tasks[i]}\x1e{isActioned[i]}");

                }
            } 
                
        }

    

