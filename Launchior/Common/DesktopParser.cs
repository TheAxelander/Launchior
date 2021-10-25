using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Launchior.Models;

namespace Launchior.Common
{
    public class DesktopParser
    {
        private readonly string _filePath;
        
        public DesktopParser(string filePath)
        {
            _filePath = filePath;
        }

        public Tuple<AppShortcut?, string> ParseDesktopFile()
        {
            var result = new AppShortcut
            {
                FilePath = _filePath,
                Name = _filePath.Split('/').Last()
            };

            try
            {
                foreach (var line in File.ReadLines(_filePath))  
                {
                    //TODO Parse
                    if (line == "[Desktop Entry]") continue;

                    var lineParts = line.Split('=');
                    if (lineParts.Length < 2)
                        throw new Exception("Unexpected line format: No '=' character found.");
                    
                    var lineKey = lineParts[0];
                    var lineValue = string.Empty;
                    for (var i = 1; i < lineParts.Length; i++)
                    {
                        lineValue += lineParts[i];
                    }
                    
                    switch (lineKey)
                    {
                        case "Name":
                            result.Name = lineValue;
                            break;
                        case "Type":
                            result.ShortcutType = lineValue;
                            break;
                        case "Terminal":
                            result.Terminal = lineValue;
                            break;
                        case "NoDisplay":
                            result.NoDisplay = lineValue;
                            break;
                        case "Comment":
                            result.Comment = lineValue;
                            break;
                        case "Exec":
                            result.ExecutionFile = lineValue;
                            break;
                        case "Icon":
                            result.IconFile = lineValue;
                            break;
                        case "Categories":
                            result.Categories = lineValue;
                            break;
                        default:
                            result.CustomAttributes += $"{line}{Environment.NewLine}";
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                return new Tuple<AppShortcut?, string>(null, e.Message);
            }

            result.UpdatePreview();
            return new Tuple<AppShortcut?, string>(result, string.Empty);
        }
    }
}