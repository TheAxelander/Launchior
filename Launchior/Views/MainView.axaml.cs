using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Launchior.Models;
using Launchior.ViewModels;

namespace Launchior.Views
{
    public partial class MainView : UserControl
    {
        private MainViewModel _mainViewModel;
        public MainView()
        {
            _mainViewModel = new MainViewModel();
            DataContext = _mainViewModel;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        protected override void OnInitialized()
        {
            _mainViewModel.LoadData();
        }

        private void Shortcuts_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
                _mainViewModel.SetSelectedItem(e.AddedItems[0] as AppShortcut ?? new AppShortcut());
        }
    }
}