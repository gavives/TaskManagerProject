﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager_Project
{
    class App
    {
        private List<string> taskList;

        public App()
        {
            taskList = ReadListFromFile();
        }

        public void Run()
        {
            var quit = false;

            do
            {
                PrintTaskList();
                InputTaskToList();
            } while (!quit);

            WriteListToFile();

            
            

        }


        private void InputTaskToList()
        {
            Console.Write("Add a new task:");

            var input = Console.ReadLine();
            taskList.Add(input);
        }

        private void PrintTaskList()
        {
            foreach (var t in taskList)
            {
                Console.WriteLine(t);
            }

            Console.WriteLine();
        }

        private List<string> ReadListFromFile()
        {
            var taskList = new List<string>();

            try
            {

                using (StreamReader sr = new StreamReader(@"C:\Users\Default\Documents\TaskManager.txt"))
                {
                    var input = sr.ReadLine();
                    taskList.Add(input);
                }
            }
            catch (FileNotFoundException)
            { ; }

            return taskList;
        }

        private void WriteListToFile()
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Default\Documents\TaskManager.txt"))
            {
                foreach (var t in taskList)
                {
                    sw.WriteLine(t);
                }
            }
        }
            
    }
}
