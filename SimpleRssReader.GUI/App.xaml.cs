using SimpleRssReader.GUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SimpleRssReader.Domain.DAL;

namespace SimpleRssReader.GUI
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow window = new MainWindow();
            var viewModel = new MainWindowViewModel(new RssFeedsRepository(new RssContext("RssContext")));
            window.DataContext = viewModel;
            window.Show();
        }
    }
}
