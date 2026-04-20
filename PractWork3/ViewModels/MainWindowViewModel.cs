using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PractWork3.Services;

namespace PractWork3.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        [ObservableProperty]
        private ViewModelBase? _currentPage;

        public NavigationService NavigationService { get; } = new();

        public MainViewModel()
        {
            NavigationService.NavigationChanged += () => CurrentPage = NavigationService.CurrentPage;
            NavigationService.NavigateTo(new AuthorizationViewModel());
        }

        [RelayCommand]
        private void NavigateToAuthorization()
        {
            NavigationService.NavigateTo(new AuthorizationViewModel());
        }

        [RelayCommand]
        private void NavigateToRegistration()
        {
            NavigationService.NavigateTo(new RegistrationViewModel());
        }

        [RelayCommand]
        private void GoBack()
        {
            NavigationService.GoBack();
        }
    }
}