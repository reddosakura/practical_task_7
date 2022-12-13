using System;
using System.Diagnostics;
using System.ComponentModel;
using ArrowName;

namespace TaskManagerN
{
    
    public static class TaskManager
    {
        internal enum Consts
        {
            min = 1,
            step = 3,
            left = 1
        }
        public static void ShowAllProcesses()
        {
            Console.Clear();
            Console.WriteLine("Список процессов");
            Process[] localAll = Process.GetProcesses();
            foreach (var proc in localAll)
            {
                try
                {
                    // List<string> procInfo = new List<string>();
                    Console.WriteLine($"( ) - {proc.ProcessName}\n    |- Выделенная память: {proc.PagedMemorySize64 / (1024 * 1024)}MB\n    |- Время начала выполнения: {proc.StartTime}");
                }
                catch (System.ComponentModel.Win32Exception)
                {
                    // List<string> procInfo = new List<string>();
                    Console.WriteLine($"( ) - {proc.ProcessName}\n    |- Выделенная память: {proc.PagedMemorySize64 / (1024 * 1024)}MB\n    |- Время начала выполнения: Отказано в доступе");
                }
            }

            Arrows arrows = new Arrows((int)Consts.min, localAll.Length);
            arrows.ShowArrow((int)Consts.left, (int)Consts.min, (int)Consts.step, "~", localAll);
        }
        public static void Main()
        {
            ShowAllProcesses();
        }
    }
}