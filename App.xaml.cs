using DALL_UI.ViewModel;
using OpenAI_API.Chat;
using OpenAI_API;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DALL_UI
{
    /// <summary>
    /// App.xaml 的互動邏輯
    /// </summary>
    public partial class App : Application
    {
        //與伺服器連接
        public static OpenAIAPI GPT { get; set; }
        public static Conversation Chat { get; set; }


        protected override void OnStartup(StartupEventArgs e)
        {
            var _windowViewModel = new MainWindowViewmodel();
            MainWindow = new MainWindow { DataContext = _windowViewModel };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
