using Ecours.Default.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Ecours.Default.Model
{

    public enum WidgetTag
    {
        FastLink, // Быстрые ссылки
        Ask, // Задать вопрос
        CheckSelf, // Проверь себя
        Calendar, // Календарь
        Chat, // Чат/задачи
        AccountInfo, // Информация об УЗ
        LastActions, // Последние действия в данной УЗ
        PermissionExpiration // Окончение разрешений
    }

    public class Widget {
        public bool Checked { get; set; }
        public string Name { get; set; }
        public UserControl Control { get; set; }
        public WidgetTag Tag { get; private set; }
        public Widget(bool ch, string name, WidgetTag tag)
        {
            Checked = ch;
            Name = name;
            Tag = tag;
        }

        public  void Check()
        {
            Checked = !Checked;
        }
    }
    public class WidgetService : IWidgetService
    {

        private readonly List<Widget> widgets_m;

        public IEnumerable<UserControl> GetUserControlList()
        {

            return widgets_m.Where(w => w.Checked).Select(w => w.Control);
        }

        public IEnumerable<Widget> GetWidgetList()
        {
            return widgets_m;
        }

        public void Select(WidgetTag tag)
        {
            widgets_m.Where(w => w.Tag == tag).FirstOrDefault().Check(); 
        }

        public WidgetService() {
            widgets_m = new List<Widget>() {
                new Widget(true, "Быстрые ссылки", WidgetTag.FastLink)
                {
                    Control = new FastLinkWidget()
                },
                 new Widget(true, "Задать вопрос", WidgetTag.Ask)
                {
                     Control = new AskWidget()
                },
                new Widget(true, "Проверь себя", WidgetTag.CheckSelf)
                {
                     Control = new CheckSelfWidget()
                },
                new Widget(true, "Календарь", WidgetTag.Calendar)
                {
                    Control = new CalendarWidget()
                },

                new Widget(false, "Чат/Задачи", WidgetTag.Chat)
            };
        }
    }
}
