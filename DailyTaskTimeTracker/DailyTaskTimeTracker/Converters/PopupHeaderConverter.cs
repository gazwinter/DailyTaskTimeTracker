using DailyTaskTimeTracker.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace DailyTaskTimeTracker.Converters
{
    public class PopupHeaderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = (PopupType)value;
            Color backgroundColor = Color.Transparent; 

            switch (type)
            {
                case PopupType.Custom:
                    backgroundColor = Color.Transparent;
                    break;
                case PopupType.Error:
                    backgroundColor = Color.Red;
                    break;
                case PopupType.Info:
                    backgroundColor = Color.LightBlue;
                    break;

                case PopupType.Warning:
                    backgroundColor = Color.Orange;
                    break;
                case PopupType.Success:
                    backgroundColor = Color.Green;
                    break;
            }

            return backgroundColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
