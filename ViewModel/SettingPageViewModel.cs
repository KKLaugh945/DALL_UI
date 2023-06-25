using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Effects;

namespace DALL_UI.ViewModel
{
    internal class SettingPageViewModel:ViewModelBase
    {
        private string _Key = Properties.Settings.Default.UIKEY;
        public string Key
        {
            get => _Key;
            set
            { 
                _Key=value;
                OnPropertyChanged(nameof(Key));
            }
        }

        public SettingPageViewModel() 
        {
            CloseCommand = new Command.CloseCommand();
            SaveDataCommand = new Command.SaveDataCommand(this);
        }

        public ICommand CloseCommand { get; }
        public ICommand SaveDataCommand { get; }
    }
}
