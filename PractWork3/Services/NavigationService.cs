using PractWork3.ViewModels;
using System;
using System.Collections.Generic;

namespace PractWork3.Services
{
    public class NavigationService
    {
        private readonly Stack<ViewModelBase> _navigationStack = new();

        public ViewModelBase? CurrentPage => _navigationStack.Count > 0 ? _navigationStack.Peek() : null;

        public event Action? NavigationChanged;

        public void NavigateTo<T>(T viewModel, Action<T>? action = null) where T : ViewModelBase
        {
            action?.Invoke(viewModel);
            _navigationStack.Push(viewModel);
            NavigationChanged?.Invoke();
        }

        public void GoBack(int steps = 1)
        {
            for (int i = 0; i < steps && _navigationStack.Count > 1; i++)
            {
                _navigationStack.Pop();
            }
            NavigationChanged?.Invoke();
        }
    }
}