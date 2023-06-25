using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DALL_UI.Command
{
    internal class CloseCommand : CommandBase
    {
        //關閉畫面
        public CloseCommand() 
        {
        
        }

        public override void Execute(object parameter)
        {
            (parameter as Window).DialogResult = false;
        }
    }
}
