using System;
using System.Windows.Input;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Tasks.Models;

namespace Tasks.ViewModels
{
    public class AddTaskViewModel : BaseViewModel
    {
        public AddTaskViewModel()
        {
            AddCommand = new Command
                (
                    execute: () =>
                    {
                        var task = new Task()
                        {
                            Title = Title,
                            Notes = Note,
                            HasCompleted = false,
                            DueDate = HasDate ? Date : new DateTime(),
                            DueTime = HasTime ? Time : new DateTime()
                        };
                        Console.WriteLine($"{task.Title} {task.Notes}");
                    },
                    canExecute: () => { return !string.IsNullOrWhiteSpace(Title); }
                );
        }

        public ICommand AddCommand { get; private set; }

        bool _hasDate = false;
        public bool HasDate
        {
            get { return _hasDate; }
            set { SetProperty(ref _hasDate, value); }
        }

        bool _hasTime = false;
        public bool HasTime
        {
            get { return _hasTime; }
            set { SetProperty(ref _hasTime, value); }
        }

        private DateTime _date = DateTime.Now;
        public DateTime Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }

        private DateTime _time = DateTime.Now;
        public DateTime Time
        {
            get { return _time; }
            set { SetProperty(ref _time, value); }
        }

        private string _title = "Do Homework";
        public string Title
        {
            get { return _title; }
            set
            {
                SetProperty(ref _title, value);
                (AddCommand as Command).RaiseCanExecuteChanged();
            }
        }

        private string _note = "Finish your homework by tomorrow";
        public string Note
        {
            get { return _note; }
            set { SetProperty(ref _note, value); }
        }

        private string _titleLabel = "Title";
        public string TitleLabel
        {
            get { return _titleLabel; }
            set { SetProperty(ref _titleLabel, value); }
        }

        private string _noteLabel = "Note";
        public string NoteLabel
        {
            get { return _noteLabel; }
            set { SetProperty(ref _noteLabel, value); }
        }

        private string _dateLabel = "At Date";
        public string DateLabel
        {
            get { return _dateLabel; }
            set { SetProperty(ref _dateLabel, value); }
        }

        private string _timeLabel = "At Time";
        public string TimeLabel
        {
            get { return _timeLabel; }
            set { SetProperty(ref _timeLabel, value); }
        }



        private bool _noteExpanded = false;
        public bool NoteExpanded
        {
            get { return _noteExpanded; }
            set
            {
                SetProperty(ref _noteExpanded, value);
                OnPropertyChanged(nameof(NoteExpanderArrow));
            }
        }

        private string _noteExpanderArrow = "";
        public string NoteExpanderArrow
        {
            get
            {
                if(NoteExpanded)
                {
                    return ((char)(0xf077)).ToString();
                }
                else
                {
                    return ((char)(0xf078)).ToString();
                }
            }
        }

        
    }
}
