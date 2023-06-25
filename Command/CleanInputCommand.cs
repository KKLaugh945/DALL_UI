using DALL_UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL_UI.Command
{
    internal class CleanInputCommand : CommandBase
    {
        private readonly MainWindowViewmodel mainWindow;
        public CleanInputCommand(MainWindowViewmodel mainWindow) 
        {
            this.mainWindow = mainWindow;
        }

        public override void Execute(object parameter)
        {
            mainWindow.Describe = "";
        }
    }
}
