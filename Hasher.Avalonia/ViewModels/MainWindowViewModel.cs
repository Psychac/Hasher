using ReactiveUI;

namespace Hasher.Avalonia.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
#pragma warning disable CA1822 // Mark members as static
        public string Greeting => "Welcome to Avalonia!";
#pragma warning restore CA1822 // Mark members as static

        private ViewModelBase _CurrentPage;

        public ViewModelBase CurrentPage
        {
            get { return _CurrentPage; }
            set { this.RaiseAndSetIfChanged(ref _CurrentPage, value); }
        }

        public MainWindowViewModel()
        {
            _CurrentPage = new PerformHashViewModel(this);
        }
    }
}
