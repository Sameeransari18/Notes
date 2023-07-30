using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Models
{
    internal class About
    {
        public string Name { get; set; }
        public string Title => AppInfo.Name;
        public string Version => AppInfo.VersionString;
        public string MoreInfoUrl => "https://github.com/Sameeransari18";
        public string Message => "This app is written in XAML and C# with .NET MAUI.";
    }
}
