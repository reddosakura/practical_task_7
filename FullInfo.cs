
using System.Diagnostics;
using ArrowName;

namespace FullInfoN
{
    public class FullInfo
    {
        public static void ShowFullInfo(Process proc)
        {
            Console.Clear();
            try
            {
                Console.WriteLine($"ID процесса: {proc.Id}\nВремя начала процесса: {proc.StartTime}" +
                                  $"\nОбъем физической памяти: {proc.PagedMemorySize64}\n" +
                                  $"Информация об ответе пользовательского интерфейса: {proc.Responding}");
            }
            catch (System.ComponentModel.Win32Exception)
            {
                Console.WriteLine($"ID процесса: Отказано в доступе\nВремя начала процесса: Отказано в доступе" +
                                  $"\nОбъем физической памяти: Отказано в доступе\n" +
                                  $"Информация об ответе пользовательского интерфейса: отказано в доступе");
            }
            finally
            {
                Console.WriteLine($"Подробная информация о процессе: {proc.ProcessName}.\n" +
                                  $"Для завершения этого процесса нажмите D, для завершения дерева процессов ");
            }

            Arrows.KeyProcess(proc);
        }
    }
}