using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonViewControl
{
    /// <summary>
    /// 当ListView高度过高时,出现滚动条,让滚轮支持滚动条.
    /// </summary>
    public class ScrollListView : System.Windows.Controls.ListView
    {
        public ScrollListView() : base()
        {
            this.AddHandler(System.Windows.Controls.ListView.MouseWheelEvent, new System.Windows.Input.MouseWheelEventHandler(listview_MouseWheel), true);
        }
        void listview_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            var listview = sender as System.Windows.Controls.ListView;
            try
            {
                var scroll = CommonLib.Function.CommonTools.GetChildObject<System.Windows.Controls.ScrollViewer>(listview, null);
                if (scroll != null)
                    scroll.ScrollToVerticalOffset(scroll.VerticalOffset - e.Delta);
            }
            catch{}
        }
    }
}
