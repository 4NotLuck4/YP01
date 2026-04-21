using PractWork3.Services;
using PractWork3.ViewModels;

namespace PractWork3.ViewModels
{
    public partial class RegistrationViewModel : ViewModelBase
    {
        private readonly NavigationService _navigation;

        public string Title { get; } = "Регистрация";

        public RegistrationViewModel(NavigationService navigation)
        {
            _navigation = navigation;
        }
    }
}