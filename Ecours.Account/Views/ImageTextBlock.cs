using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Ecours.Account.Views
{
    public class MyStackPanel: StackPanel
    {

        public MyStackPanel()
        {
           
            this.Children.Add(new TextBlock() { Text = "Test"});

           
            Rectangle rectangle = new Rectangle
            {
                Width = 10,
                Height = 10,
                Fill = new SolidColorBrush() { Color = Colors.Green }
            };

            this.Children.Add(rectangle);
        }

        protected override void OnRender(DrawingContext dc)
        {

            base.OnRender(dc);

            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = Colors.LimeGreen;
            Pen myPen = new Pen(Brushes.Blue, 10);
            Rect myRect = new Rect(0, 0, 10, 10);
            dc.DrawRectangle(mySolidColorBrush, myPen, myRect);

        }
    }
}
