using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfApp1.fonts
{
    public class FontUtils
    {
        static FontUtils()
        {
            try
            {
                Awesome = new FontFamily(new Uri(@"pack://application:,,,/FWindSoft.Wpf;component/Resources/"), "./#FontAwesome");
            }
            catch (Exception)
            {
            }
        }


        /// <summary>
        /// Awesome字体
        /// </summary>
        public static FontFamily Awesome { get; private set; }

    }
}
