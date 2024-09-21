using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;

namespace Hasher.Avalonia.ViewModels
{
    public class PerformHashViewModel : ViewModelBase
    {
        MainWindowViewModel MainWindowViewModel { get; set; }

        public ICommand CreateCommand { get; set; }

        public ICommand VerifyCommand { get; set; }

        public PerformHashViewModel(MainWindowViewModel mainViewModel)
        {
            MainWindowViewModel = mainViewModel;

            CreateCommand = ReactiveCommand.Create(CreateHash);
            VerifyCommand = ReactiveCommand.Create(VerifyHash);
        }

        private void CreateHash()
        {
            MainWindowViewModel.CurrentPage = new CreateHashViewModel(MainWindowViewModel);
        }

        private void VerifyHash()
        {
            MainWindowViewModel.CurrentPage = new VerifyHashViewModel(MainWindowViewModel);
        }
    }
}
