using DALL_UI.View;
using DALL_UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL_UI.Command
{
    internal class IntoSettingCommand : CommandBase
    {
        //開啟設定
        private readonly MainWindowViewmodel mainWindowViewmodel;
        public IntoSettingCommand(MainWindowViewmodel mainWindowViewmodel) 
        {
            this.mainWindowViewmodel = mainWindowViewmodel;
        }

        public override void Execute(object parameter)
        {
            //開啟畫面
            var viewmodel = new SettingPageViewModel();
            var view = new SettingPageView { DataContext= viewmodel };
            if (view.ShowDialog() == true)
            {
                //重新宣告數據
                mainWindowViewmodel.SetConnect();
            }
        }
    }
}
