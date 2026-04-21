using CommunityToolkit.Mvvm.Input;
using PractWork4.Models;
using System.Collections.ObjectModel;

namespace PractWork4.ViewModels
{
    public partial class UserListViewModel : ViewModelBase
    {
        public string? NewLogin { get; set; }
        public string? NewPassword { get; set; }

        public ObservableCollection<User> Users { get; } = new()
        {
            new User { Login="Login1", Password="Password1"},
            new User { Login="Login2", Password="Password2"},
            new User { Login="Login3", Password="Password3"}
        };

        [RelayCommand]
        private void DeleteUser(User user)
        {
            Users.Remove(user);
        }

        [RelayCommand]
        private void AddUser()
        {
            if (!string.IsNullOrWhiteSpace(NewLogin) && !string.IsNullOrWhiteSpace(NewPassword))
            {
                Users.Add(new User { Login = NewLogin, Password = NewPassword });
                NewLogin = string.Empty;
                NewPassword = string.Empty;
            }
        }
    }
}