using System;
using System.Collections.ObjectModel;
using ReactiveUI;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Launchior.Common;
using Launchior.Models;

namespace Launchior.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private AppShortcut _selectedAppShortcut;
        public AppShortcut SelectedAppShortCut
        {
            get => _selectedAppShortcut;
            set => this.RaiseAndSetIfChanged(ref _selectedAppShortcut, value);
        }
        
        public ObservableCollection<AppShortcut> Shortcuts { get; set; }
        
        public MainViewModel()
        {
            Shortcuts = new ObservableCollection<AppShortcut>();
        }

        public void LoadData()
        {
            var path = $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}/.local/share/applications";
            var files = 
                Directory.EnumerateFiles(path, "*.desktop")
                    .OrderBy(i => i)
                    .ToList();
            foreach (var file in files)
            {
                Shortcuts.Add(new AppShortcut
                {
                    FilePath = file,
                    Name = file.Split('/').Last(),
                    ShortcutType = "application"
                });
            }
        }

        public void SetSelectedItem(AppShortcut newSelection)
        {
            var parser = new DesktopParser(newSelection.FilePath);
            var (result, message) = parser.ParseDesktopFile();
            if (result is null)
            {
                //TODO Show Error Message
                return;
            }
            SelectedAppShortCut = result;
        }
    }
}