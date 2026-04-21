using Avalonia.Controls;
using PractWork4.ViewModels;

namespace PractWork4.Views;

public partial class UserListView : UserControl
{
    public UserListView()
    {
        InitializeComponent();
        DataContext = new UserListViewModel();
    }
}