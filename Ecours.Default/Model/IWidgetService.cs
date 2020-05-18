using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Ecours.Default.Model
{
    public interface IWidgetService
    {
        IEnumerable<Widget> GetWidgetList();

        IEnumerable<UserControl> GetUserControlList();

        void Select(WidgetTag tag);
    }
}
