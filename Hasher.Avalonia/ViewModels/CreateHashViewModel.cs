using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using Hasher.Avalonia.Models;
using Hasher.Avalonia.Services;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;

namespace Hasher.Avalonia.ViewModels
{
    public class CreateHashViewModel : ViewModelBase
    {
        MainWindowViewModel MainWindowViewModel { get; set; }

        public ICommand CancelCommand { get; set; }

        public ICommand OpenFileCommand { get; set; }

        public ObservableCollection<FileDataViewModel> Files { get; set; } = new ObservableCollection<FileDataViewModel>();

        public CreateHashViewModel()
        {
            if (Design.IsDesignMode)
            {
                Files = new ObservableCollection<FileDataViewModel>(new[]
                {
                new FileDataViewModel() { FileName = "Hello", FileSize = 10 },
                new FileDataViewModel() { FileName = "Avalonia", FileSize = 100}
            });
            }
        }

        public CreateHashViewModel(MainWindowViewModel mainWindowViewModel) 
        {
            MainWindowViewModel = mainWindowViewModel;

            CancelCommand = ReactiveCommand.Create(CancelNewHash);
            OpenFileCommand = ReactiveCommand.Create(OpenFiles);
        }

        private void CancelNewHash()
        {
            MainWindowViewModel.CurrentPage = new PerformHashViewModel(MainWindowViewModel);
        }

        private async void OpenFiles()
        {
            Files.Clear();

            IFilesService? filesService = App.Current?.Services?.GetService<IFilesService>();
            if (filesService is null) throw new NullReferenceException("Missing File Service instance.");

            var files = await filesService.OpenFilesAsync();
            if (files is null) return;

            foreach (IStorageFile? file in files)
            {
                if(file is null) continue;

                FileDataViewModel fileViewModel = new FileDataViewModel();
                fileViewModel.FileName = file.Path.AbsolutePath;
                fileViewModel.FileSize = Math.Round((double)file.GetBasicPropertiesAsync().Result.Size.GetValueOrDefault() / 1000000, 2);
                fileViewModel.IsSelected = true;

                Files.Add(fileViewModel);
            }
        }
    }
}
