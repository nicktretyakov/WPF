using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace Ecours.Contractor.Views
{
    public class TooltipTextBlock : TextBlock
    {

        private static FieldInfo firstLineField_m = typeof(TextBlock).GetField("_firstLine", BindingFlags.NonPublic | BindingFlags.Instance);

        private static PropertyInfo lineMetricsWidthProperty_m = firstLineField_m.FieldType.GetProperty("Width", BindingFlags.NonPublic | BindingFlags.Instance);

        public static readonly DependencyPropertyKey IsTextTrimmedKey = DependencyProperty.RegisterReadOnly(
            "IsTextTrimmed",
            typeof(bool),
            typeof(TooltipTextBlock),
            new PropertyMetadata(false));


        public static readonly DependencyProperty IsTextTrimmedProperty = IsTextTrimmedKey.DependencyProperty;


        public bool IsTextTrimmed
        {
            get
            {
                return (bool)GetValue(IsTextTrimmedProperty);
            }
        }


        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);

            SetIsTextTrimmed();
        }


        private void SetIsTextTrimmed()
        {


            if (TextTrimming.None == TextTrimming)
            {
                SetValue(IsTextTrimmedKey, false);
            }
            else
            {
                Double firstLineWidth = (Double)lineMetricsWidthProperty_m.GetValue(firstLineField_m.GetValue(this), null);
                Double renderWidth = RenderSize.Width;

                SetValue(IsTextTrimmedKey, firstLineWidth > renderWidth);
            }
        }
    }

}
