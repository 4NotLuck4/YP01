using CommunityToolkit.Mvvm.ComponentModel;
using PractWork6_Styles.Models;
using System.Collections.ObjectModel;

namespace PractWork6_Styles.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        public ObservableCollection<MoneyOperation> Operations { get; } = new()
        {
            new MoneyOperation { Description = "Зарплата", Amount = 50000, IsIncome = true },
            new MoneyOperation { Description = "Продукты", Amount = 5000, IsIncome = false },
            new MoneyOperation { Description = "Кафе", Amount = 1500, IsIncome = false },
            new MoneyOperation { Description = "Премия", Amount = 10000, IsIncome = true }
        };
    }
}