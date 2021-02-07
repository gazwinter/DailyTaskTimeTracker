using DailyTaskTimeTracker.Constants;
using DailyTaskTimeTracker.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace DailyTaskTimeTracker.Converters
{
    public class PopupImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var image = "";
            var type = (PopupType)value;


            switch (type)
            {                
                case PopupType.Error:
                    image = IconFontSolid.TimesCircle;
                    break;
                case PopupType.Info:
                    image = IconFontSolid.InfoCircle;
                    break;

                case PopupType.Warning:
                    image = IconFontSolid.ExclamationTriangle;
                    break;
                case PopupType.Success:
                    image = IconFontSolid.Check;
                    break;
            }

            return image;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
