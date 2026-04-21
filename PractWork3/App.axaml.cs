using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PractWork3.Services;
using PractWork3.ViewModels;
using PractWork3.Views;

namespace PractWork3
{
    public partial class App : Application
    {
        //
        public static IConfiguration? Configuration { get; private set; }
        public static ServiceProvider? Services { get; private set; }
        //

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            //
            ConfigurationBuilder builder = new();
            //добавляем файл с настройками
            builder.AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            
            var collection = new ServiceCollection();
            //Singleton – один на все приложение
            collection.AddSingleton<NavigationService>();
            collection.AddSingleton<MainViewModel>();
            //Transient – создается новый при каждом обращении
            collection.AddTransient<RegistrationViewModel>();
            collection.AddTransient<AuthorizationViewModel>();
            collection.AddTransient<AuthorizationView>();
            collection.AddTransient<RegistrationView>();

            Services = collection.BuildServiceProvider();
            //
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var mainViewModel = Services.GetRequiredService<MainViewModel>();
                desktop.MainWindow = new MainWindow
                {
                    DataContext = mainViewModel
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}