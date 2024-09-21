using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;

namespace Hasher.Avalonia.ViewModels
{
    public class VerifyHashViewModel : ViewModelBase
    {
        public MainWindowViewModel MainWindow { get; set; }

        public ICommand CancelCommand { get; set; }

        public VerifyHashViewModel(MainWindowViewModel mainWindow)
        {
            MainWindow = mainWindow;

            CancelCommand = ReactiveCommand.Create(CancelVerifyHash);
        }

        private void CancelVerifyHash()
        {
            MainWindow.CurrentPage = new PerformHashViewModel(MainWindow);
        }
    }
}
