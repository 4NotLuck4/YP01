using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PractWork3.Services;
using System;

namespace PractWork3.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        private readonly NavigationService _navigation; 

        [ObservableProperty]
        private string? _apiKey;

        [ObservableProperty]
        private double _celsius = 0;

        public MainViewModel(NavigationService navigation)
        {
            _navigation = navigation;
            _navigation.PropertyChanged += OnNavigationChanged;
            _navigation.NavigateTo<AuthorizationViewModel>();

            var key = App.Configuration?.GetSection("ApiKeys")["SomeApi"];
            ApiKey = key;
        }

        private void OnNavigationChanged(object? sender, EventArgs e)
        {
            OnPropertyChanged(nameof(CurrentPage));
        }

        public ViewModelBase? CurrentPage => _navigation.Current;

        [RelayCommand]
        private void NavigateToAuthorization()
        {
            _navigation.NavigateTo<AuthorizationViewModel>(vm => vm.Login = "user");
        }

        [RelayCommand]
        private void NavigateToRegistration()
        {
            _navigation.NavigateTo<RegistrationViewModel>();
        }

        [RelayCommand]
        private void GoBack()
        {
            _navigation.GoBack();
        }
    }
}