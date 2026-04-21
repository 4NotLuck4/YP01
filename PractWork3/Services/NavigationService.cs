using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using PractWork3.ViewModels;
using System;
using System.Collections.Generic;

namespace PractWork3.Services
{
    public partial class NavigationService : ObservableObject
    {
        private readonly Stack<ViewModelBase> _navigationStack = new();

        public ViewModelBase? Current => _navigationStack.Count > 0 ? _navigationStack.Peek() : null;


        public void NavigateTo<T>(T viewModel, Action<T>? action = null) where T : ViewModelBase
        {
            action?.Invoke(viewModel);
            _navigationStack.Push(viewModel);
            OnPropertyChanged(nameof(Current));
        }

        public void NavigateTo<T>(Action<T>? action = null) where T : ViewModelBase
        {
            var viewModel = App.Services?.GetRequiredService<T>();
            if (viewModel != null)
                NavigateTo(viewModel, action);
        }

        public void GoBack(int steps = 1)
        {
            for (int i = 0; i < steps && _navigationStack.Count > 1; i++)
            {
                _navigationStack.Pop();
            }
            OnPropertyChanged(nameof(Current));
        }
    }
}