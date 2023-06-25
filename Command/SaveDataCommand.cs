using DALL_UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DALL_UI.Command
{
    internal class SaveDataCommand:CommandBase
    {
        //儲存這邊的設定
        private readonly SettingPageViewModel settingScreenView;

        public SaveDataCommand(SettingPageViewModel settingScreenView) 
        {
            this.settingScreenView = settingScreenView;
        }

        public override void Execute(object parameter)
        {
            Properties.Settings.Default.UIKEY = settingScreenView.Key;
            Properties.Settings.Default.Save();
            (parameter as Window).DialogResult = true;
        }
    }
}
