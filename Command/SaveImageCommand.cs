using DALL_UI.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace DALL_UI.Command
{
    internal class SaveImageCommand : CommandBase
    {
        //儲存目前查看的圖像
        private readonly MainWindowViewmodel mainWindowViewmodel;
        public SaveImageCommand(MainWindowViewmodel mainWindowViewmodel) 
        {
            this.mainWindowViewmodel = mainWindowViewmodel;
        }

        public override void Execute(object parameter)
        {
            try
            {
                using (var webClient = new WebClient())
                {
                    //獲取圖片網址
                    string pathGet;
                    switch (mainWindowViewmodel.ImageSelect)
                    {
                        case 0:
                        default:
                            pathGet = mainWindowViewmodel.Image1.ImageUrl;
                            break;
                        case 1:
                            pathGet = mainWindowViewmodel.Image2.ImageUrl;
                            break;
                        case 2:
                            pathGet = mainWindowViewmodel.Image3.ImageUrl;
                            break;
                        case 3:
                            pathGet = mainWindowViewmodel.Image4.ImageUrl;
                            break;
                    }
                    // 下載圖片
                    byte[] imageData = webClient.DownloadData(pathGet);

                    // 顯示 SaveFileDialog 讓使用者選擇儲存路徑
                    System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
                    saveFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;

                        // 儲存圖片到指定路徑
                        using (var fs = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
                        {
                            fs.Write(imageData, 0, imageData.Length);
                        }

                        MessageBox.Show("圖片已儲存");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
