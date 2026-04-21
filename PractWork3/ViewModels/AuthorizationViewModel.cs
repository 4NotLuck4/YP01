using CommunityToolkit.Mvvm.ComponentModel;
using PractWork3.Services;

namespace PractWork3.ViewModels
{
    public partial class AuthorizationViewModel : ViewModelBase
    {
        private readonly NavigationService _navigation;

        public string Title { get; } = "Авторизация";

        [ObservableProperty]
        private string? _login;

        public AuthorizationViewModel(NavigationService navigation)
        {
            _navigation = navigation;
        }
    }
}