using PractWork2.Models;

namespace PractWork2.ViewModels
{
    public partial class RegistrationViewModel : ViewModelBase
    {
        public UserCredentials UserCredentials { get; } = new();
    }
}
