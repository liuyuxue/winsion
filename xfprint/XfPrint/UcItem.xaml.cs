using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XfPrint
{
    /// <summary>
    /// UcItem.xaml 的交互逻辑
    /// </summary>
    public partial class UcItem : UserControl
    {
        public UcItem()
        {
            InitializeComponent();
        }

        private void grid_print_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var m = (sender as StackPanel).DataContext as DeviceModel;
            if (m != null)
                m.check = !m.check;

        }
    }
}
