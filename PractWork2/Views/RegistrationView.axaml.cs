using Avalonia.Controls;
using PractWork2.ViewModels;

namespace PractWork2.Views;

public partial class RegistrationView : UserControl
{
    public RegistrationView()
    {
        InitializeComponent();
        DataContext = new RegistrationViewModel();
    }
}