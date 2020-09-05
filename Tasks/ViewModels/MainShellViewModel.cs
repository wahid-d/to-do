﻿using System;
using System.Threading.Tasks;
using MvvmHelpers;
namespace Tasks.ViewModels
{
    public class MainShellViewModel : BaseViewModel
    {
        public MainShellViewModel()
        {
            Tasks = new ObservableRangeCollection<Models.Task>();
            GenerateTasks();
        }

        public ObservableRangeCollection<Tasks.Models.Task> Tasks { get; set; }

        private async Task GenerateTasks()
        {
            for (int i = 0; i < 100; i++)
            {
                Tasks.Add(new Models.Task()
                {
                    Id = Guid.NewGuid(),
                    Title = string.Format($"Task #{i}"),
                    Notes = "Some notes about the task",
                    DueDate = DateTime.Now,
                    DueTime = DateTime.Now
                });

                await Task.Delay(250);
            }
        }
    }
}
