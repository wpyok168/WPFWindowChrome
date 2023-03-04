using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using WpfChrome.WindowMVVM;

namespace WpfChrome
{
    public class WindowStyleViewModel: ViewModelBase
    {
        public RelayCommand MinimizeCommand { get; }
        public RelayCommand MaximizeCommand { get; }
        public RelayCommand CloseCommand { get; }
        public RelayCommand<object> TitleBackGroundChangeCommand { get; set; }

        private PropertyInfo[] colorPropertyInfo = typeof(Colors).GetProperties();
        private string titleBarColor = "#673AB7";

        public string TitleBarColor { get => titleBarColor; set { titleBarColor = value; this.RaisePropertyChanged(); } }
        public PropertyInfo[] ColorPropertyInfo { get => colorPropertyInfo; set => colorPropertyInfo = value; }

        public WindowStyleViewModel()
        {
            MinimizeCommand = new RelayCommand(MinimizeWindow);
            MaximizeCommand = new RelayCommand(MaximizeWindow);
            CloseCommand = new RelayCommand(CloseWindow);
            //TitleBackGroundChangeCommand = new RelayCommand<object>(new Func<object, bool>(this.ColorTitleBarChanged));
            TitleBackGroundChangeCommand = new RelayCommand<object>(this.ColorTitleBarChanged);
        }

        private void CloseWindow(object obj)
        {
            SystemCommands.CloseWindow(obj as Window);
        }

        private void MaximizeWindow(object obj)
        {
            var mainWindow = obj as Window;
            switch (mainWindow.WindowState)
            {
                case WindowState.Normal:
                    SystemCommands.MaximizeWindow(mainWindow);
                    break;
                case WindowState.Minimized:
                    break;
                case WindowState.Maximized:
                    SystemCommands.RestoreWindow(mainWindow);
                    break;
                default:
                    break;
            }
        }

        private void MinimizeWindow(object obj)
        {
            SystemCommands.MinimizeWindow(obj as Window);
        }

        private void ColorTitleBarChanged(object obj)
        {
            if (obj == null)
            {
                return ;
            }
            // Color cl = (Color)(obj as PropertyInfo).GetValue(null, null);
            //new SolidColorBrush(ColorConverter.ConvertFromString("#673AB7"))
            PropertyInfo pi = obj as PropertyInfo;
            TitleBarColor = pi.Name;
        }
    }
}
