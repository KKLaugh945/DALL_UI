using DALL_UI.Command;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DALL_UI.ViewModel
{
    internal class MainWindowViewmodel: ViewModelBase
    {
        //輸出字串
        private string _Describe="";
        public string Describe 
        {
            get => _Describe;
            set 
            { 
                _Describe = value; 
                OnPropertyChanged(nameof(Describe));
            }
        }

        //選項設定
        public ObservableCollection<ComboBoxItem> Item { get; }
        //圖片大小選擇
        public ushort SelectIndex { get; set; }
        //圖片選擇index
        public ushort ImageSelect { get; set; }
        //圖片1
        public ImageViewModel Image1 { get; }
        public ImageViewModel Image2 { get; }
        public ImageViewModel Image3 { get; }
        public ImageViewModel Image4 { get; }

        //控制按鈕可否使用
        private bool _IsEnable = false;
        public bool IsEnable 
        { 
            get => _IsEnable;
            set 
            {
                _IsEnable= value;
                OnPropertyChanged(nameof(IsEnable));
            }
        }

        //圖片實際大小
        private string _GetImageSize = "";
        public string GetImageSize 
        {
            get => _GetImageSize;
            set
            {
                _GetImageSize = value;
                OnPropertyChanged(nameof(GetImageSize));
            }
        }


        public MainWindowViewmodel() 
        {
            Item = new ObservableCollection<ComboBoxItem> {
                new ComboBoxItem { Content = "256x256" },
                new ComboBoxItem { Content = "512x512" },
                new ComboBoxItem { Content = "1024x1024" }
            };
            SelectIndex = 0;
            ImageSelect = 0;
            Image1 = new ImageViewModel();
            Image2=new ImageViewModel();
            Image3=new ImageViewModel();
            Image4=new ImageViewModel();
            CleanInputCommand = new Command.CleanInputCommand(this);
            IntoSettingCommand = new Command.IntoSettingCommand(this);
            GetImageCommand=new     Command.GetImageCommand(this);
            SaveImageCommand = new Command.SaveImageCommand(this);
            SetConnect();
        }

        //設定通話
        public void SetConnect() 
        {
            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.UIKEY))
                MessageBox.Show("請前往設定頁面設定key");
            else
            {
                try
                {
                    App.GPT = new OpenAI_API.OpenAIAPI(Properties.Settings.Default.UIKEY);
                    App.Chat = App.GPT.Chat.CreateConversation(new ChatRequest
                    {
                        Model = Model.ChatGPTTurbo,
                        Temperature = 0.9,
                        MaxTokens = 100,
                    });
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        //清空選項
        public ICommand CleanInputCommand { get; }
        //開啟設定畫面
        public ICommand IntoSettingCommand { get; }
        //傳送要求給gpt
        public ICommand GetImageCommand { get; }
        //儲存
        public ICommand SaveImageCommand { get; }
    }
}
