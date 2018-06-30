using System;
using System.IO;
// ReSharper disable InconsistentNaming

namespace VetisLog.Agent.Code
{
    public class TashSchedulerAddCommand
    {
        public string TaskName { get; set; }
        public string Description { get; set; }
        public int MinutesInterval { get; set; }
        public string PathToStart { get; set; }
        public string Args { get; set; }
        public string WorkingDirPath { get; set; } = null;

        public bool Validate()
        {
            if (!File.Exists(PathToStart))
            {
                throw new FileNotFoundException($"Приложение для запуска не найдено! Путь: {PathToStart}.");
            }

            if (string.IsNullOrEmpty(Args))
            {
                Args = null;
            }

            if (string.IsNullOrEmpty(WorkingDirPath))
            {
                WorkingDirPath = null;
            }

            if (!Directory.Exists(WorkingDirPath))
            {
                WorkingDirPath = null;
            }

            if (string.IsNullOrEmpty(TaskName))
            {
                throw new ArgumentException("Не уставлено название задания");
            }

            if (string.IsNullOrEmpty(Description))
            {
                throw new ArgumentException("Не уставлено описание задания");
            }

            if (MinutesInterval < 1)
            {
                throw new ArgumentException("Не уставлена периодичность выполнения задания в минутах. Задание не может быть запущено чаще 1 раза в минуту!");
            }

            return true;
        }
    }
}