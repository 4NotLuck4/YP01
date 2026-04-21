using CommunityToolkit.Mvvm.ComponentModel;

namespace PractWork4.Models
{
    public partial class User : ObservableObject
    {
        [ObservableProperty]
        private string? _login;

        [ObservableProperty]
        private string? _password;
    }
}
