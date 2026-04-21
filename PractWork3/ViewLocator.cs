using Avalonia.Controls;
using Avalonia.Controls.Templates;
using PractWork3.ViewModels;
using System;

namespace PractWork3
{
    public class ViewLocator : IDataTemplate
    {
        public static bool SupportsRecycling => false;

        public Control? Build(object? data)
        {
            if (data is null)
                return null;

            var name = data.GetType().FullName!.Replace("ViewModel", "View");
            var type = Type.GetType(name);

            if (type != null)
            {
                var view = App.Services?.GetService(type);
                if (view is Control control)
                {
                    control.DataContext = data;
                    return control;
                }
                return (Control)Activator.CreateInstance(type)!;
            }

            return new TextBlock { Text = "Not Found: " + name };
        }

        public bool Match(object? data)
        {
            return data is ViewModelBase;
        }
    }
}