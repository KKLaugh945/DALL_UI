using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DALL_UI.Command
{
    public abstract class CommandBase : ICommand
    {
        //基礎常用的icommand宣告 用於繼承用
        //https://youtu.be/DNez3wIpHeE

        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public abstract void Execute(object parameter);

        protected void OnCanExecutedChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

    }
}
