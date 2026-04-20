using Avalonia.Controls;
using PractWork2.ViewModels;

namespace PractWork2.Views;

public partial class ControlsView : UserControl
{
    public ControlsView()
    {
        InitializeComponent();
        DataContext = new ControlsViewModel();
    }
}