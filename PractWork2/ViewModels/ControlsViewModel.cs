using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;

namespace PractWork2.ViewModels
{
    public partial class ControlsViewModel : ViewModelBase
    {
        public ObservableCollection<string> Languages { get; } = new()
        {
            "C#", "Java", "Python", "JavaScript", "C++"
        };

        [ObservableProperty]
        private string? _selectedLanguage;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Age))]
        private DateTimeOffset? _selectedDate = DateTimeOffset.Now;

        public int Age
        {
            get
            {
                if (!SelectedDate.HasValue) return 0;
                var today = DateTime.Today;
                var birth = SelectedDate.Value.Date;
                var age = today.Year - birth.Year;
                if (birth > today.AddYears(-age)) age--;
                return age;
            }
        }

        [ObservableProperty]
        private double _opacity = 1.0;
    }
}