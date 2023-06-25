using DALL_UI.ViewModel;
using OpenAI_API.Chat;
using OpenAI_API.Images;
using OpenAI_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DALL_UI.Command
{
    internal class GetImageCommand : CommandBase
    {
        private readonly MainWindowViewmodel mainWindowViewmodel;
        public GetImageCommand(MainWindowViewmodel mainWindowViewmodel) 
        {
            this.mainWindowViewmodel= mainWindowViewmodel;
        }

        public override async void Execute(object parameter)
        {
            //從app拿到數據
            if (string.IsNullOrEmpty(mainWindowViewmodel.Describe))
                MessageBox.Show("沒有輸入描述");
            else if (App.GPT == null)
                MessageBox.Show("尚未成功建立連線 請前往設定頁面進行設定");
            else
            {
                var send = "幫我把以下內容翻譯成英文\r\n" + mainWindowViewmodel.Describe;
                try
                {
                    App.Chat.AppendUserInput(send);
                    var response = await App.Chat.GetResponseFromChatbotAsync();
                    ImageResult ImageGet;
                    switch (mainWindowViewmodel.SelectIndex)
                    {
                        case 0:
                        default:
                            ImageGet = await App.GPT.ImageGenerations.CreateImageAsync(
                       new ImageGenerationRequest(response, 4, ImageSize._256));
                            break;
                        case 1:
                            ImageGet = await App.GPT.ImageGenerations.CreateImageAsync(
                                new ImageGenerationRequest(response, 4, ImageSize._512));
                            break;
                        case 2:
                            ImageGet = await App.GPT.ImageGenerations.CreateImageAsync(
                                new ImageGenerationRequest(response, 4, ImageSize._1024));
                            break;
                    }
                    mainWindowViewmodel.Image1.ImageUrl = ImageGet.Data[0].Url;
                    mainWindowViewmodel.Image2.ImageUrl = ImageGet.Data[1].Url;
                    mainWindowViewmodel.Image3.ImageUrl = ImageGet.Data[2].Url;
                    mainWindowViewmodel.Image4.ImageUrl = ImageGet.Data[3].Url;
                    mainWindowViewmodel.IsEnable = true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    mainWindowViewmodel.IsEnable = false;
                }
            }
        }
    }
}
