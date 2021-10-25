using System;
using Launchior.ViewModels;
using ReactiveUI;

namespace Launchior.Models
{
    public class AppShortcut : ViewModelBase
    {
        private string _filePath;
        public string FilePath
        {
            get => _filePath;
            set => this.RaiseAndSetIfChanged(ref _filePath, value);
        }
        
        private string _name;
        public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }
        
        private string _shortcutType;
        public string ShortcutType
        {
            get => _shortcutType;
            set => this.RaiseAndSetIfChanged(ref _shortcutType, value);
        }
        
        private string _terminal;
        public string Terminal
        {
            get => _terminal;
            set => this.RaiseAndSetIfChanged(ref _terminal, value);
        }
        
        private string _noDisplay;
        public string NoDisplay
        {
            get => _noDisplay;
            set => this.RaiseAndSetIfChanged(ref _noDisplay, value);
        }
        
        private string _comment;
        public string Comment
        {
            get => _comment;
            set => this.RaiseAndSetIfChanged(ref _comment, value);
        }
        
        private string _executionFile;
        public string ExecutionFile
        {
            get => _executionFile;
            set => this.RaiseAndSetIfChanged(ref _executionFile, value);
        }
        
        private string _iconFile;
        public string IconFile
        {
            get => _iconFile;
            set => this.RaiseAndSetIfChanged(ref _iconFile, value);
        }
        
        private string _categories;
        public string Categories
        {
            get => _categories;
            set => this.RaiseAndSetIfChanged(ref _categories, value);
        }
        
        private string _customAttributes;
        public string CustomAttributes
        {
            get => _customAttributes;
            set => this.RaiseAndSetIfChanged(ref _customAttributes, value);
        }
        
        private string _preview;
        public string Preview
        {
            get => _preview;
            set => this.RaiseAndSetIfChanged(ref _preview, value);
        }

        public AppShortcut()
        {
            FilePath = string.Empty;
            Name = string.Empty;
            ShortcutType = string.Empty;
            Terminal = string.Empty;
            NoDisplay = string.Empty;
            Comment = string.Empty;
            ExecutionFile = string.Empty;
            IconFile = string.Empty;
            Categories = string.Empty;
            CustomAttributes = string.Empty;
            Preview = string.Empty;
        }
        
        public void UpdatePreview()
        {
            Preview = "[Desktop Entry]";
            if (!string.IsNullOrEmpty(Name)) Preview += $"{Environment.NewLine}Name={Name}";
            if (!string.IsNullOrEmpty(ShortcutType)) Preview += $"{Environment.NewLine}Type={ShortcutType}";
            if (!string.IsNullOrEmpty(Terminal)) Preview += $"{Environment.NewLine}Terminal={Terminal}";
            if (!string.IsNullOrEmpty(NoDisplay)) Preview += $"{Environment.NewLine}NoDisplay={NoDisplay}";
            if (!string.IsNullOrEmpty(Comment)) Preview += $"{Environment.NewLine}Comment={Comment}";
            if (!string.IsNullOrEmpty(ExecutionFile)) Preview += $"{Environment.NewLine}Exec={ExecutionFile}";
            if (!string.IsNullOrEmpty(IconFile)) Preview += $"{Environment.NewLine}Icon={IconFile}";
            if (!string.IsNullOrEmpty(Categories)) Preview += $"{Environment.NewLine}Categories={Categories}";
            if (!string.IsNullOrEmpty(CustomAttributes)) Preview += $"{Environment.NewLine}{CustomAttributes}";
        }
    }
}