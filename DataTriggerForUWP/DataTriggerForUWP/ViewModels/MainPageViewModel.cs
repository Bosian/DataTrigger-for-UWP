using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace DataTriggerForUWP.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private string _property = "Same Value";
        public string Property
        {
            get
            {
                return _property;
            }

            set
            {
                if (_property != value)
                {
                    _property = value;
                    NotifyPropertyChange();
                }
            }
        }

        private string _value;
        public string Value
        {
            get
            {
                return _value;
            }

            set
            {
                if (_value != value)
                {
                    _value = value;
                    NotifyPropertyChange();
                }
            }
        }


        private SolidColorBrush _color;
        public SolidColorBrush Color
        {
            get
            {
                if (_color == null)
                {
                    _color = new SolidColorBrush(Colors.Yellow);
                }

                return _color;
            }

            set
            {
                if (_color != value)
                {
                    _color = value;
                    NotifyPropertyChange();
                }
            }
        }


        public MainPageViewModel()
        {

        }

        public void SameValueButton_Click(object sender, RoutedEventArgs e)
        {
            Value = "Same Value";
        }

        public void DifferenceValueButton_Click(object sender, RoutedEventArgs e)
        {
            Value = "Other value";
        }
    }
}
