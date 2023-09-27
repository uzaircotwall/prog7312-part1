using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DeweyDecimalTrainingApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Window splashScreen;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Create and show the splash screen
            splashScreen = new SplashScreen();
            splashScreen.Show();

            // Simulate some work (e.g., loading resources) before transitioning to the main window
            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(50); // Simulate work
                splashScreen.Dispatcher.Invoke(() =>
                {
                    (splashScreen.FindName("ProgressBar") as ProgressBar).Value = i;
                });
            }

            // Create and show the main window
            MainWindow mainWindow = new MainWindow();

            // Close the splash screen
            splashScreen.Close();


        }
    }
}