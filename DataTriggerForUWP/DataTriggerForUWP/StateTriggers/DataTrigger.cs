using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace DataTriggerForUWP
{
    public class DataTrigger : StateTriggerBase
    {

        #region Binding目標
        public object Binding
        {
            get { return (object)GetValue(BindingProperty); }
            set { SetValue(BindingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Property.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BindingProperty =
            DependencyProperty.Register("Binding", typeof(object), typeof(DataTrigger), new PropertyMetadata(null, PropertyChangedCallback));

        #endregion

        #region 目標值
        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(string), typeof(DataTrigger), new PropertyMetadata(null, PropertyChangedCallback));
        #endregion

        #region 比較條件

        public enum CompareEnum
        {
            Equal,
            NotEqual,
            LessThan,
            LessThanOrEqual,
            GreaterThan,
            GreaterThanOrEqual
        }

        private static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataTrigger dataTrigger = d as DataTrigger;

            if (dataTrigger == null)
            {
                return;
            }

            switch (dataTrigger.Comparison)
            {
                case CompareEnum.Equal:

                    dataTrigger.SetActive(dataTrigger.Binding?.ToString() == dataTrigger.Value);

                    break;
                case CompareEnum.NotEqual:

                    dataTrigger.SetActive(dataTrigger.Binding?.ToString() != dataTrigger.Value);

                    break;
                case CompareEnum.LessThan:

                    dataTrigger.SetActive(dataTrigger.Binding?.ToString().CompareTo(dataTrigger.Value) < 0);

                    break;
                case CompareEnum.LessThanOrEqual:

                    dataTrigger.SetActive(dataTrigger.Binding?.ToString().CompareTo(dataTrigger.Value) <= 0);

                    break;
                case CompareEnum.GreaterThan:

                    dataTrigger.SetActive(dataTrigger.Binding?.ToString().CompareTo(dataTrigger.Value) > 0);

                    break;
                case CompareEnum.GreaterThanOrEqual:

                    dataTrigger.SetActive(dataTrigger.Binding?.ToString().CompareTo(dataTrigger.Value) >= 0);

                    break;
                default:
                    throw new NotImplementedException();
            }

        }

        public CompareEnum Comparison
        {
            get { return (CompareEnum)GetValue(ComparisonProperty); }
            set { SetValue(ComparisonProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Comparison.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ComparisonProperty =
            DependencyProperty.Register("Comparison", typeof(CompareEnum), typeof(DataTrigger), new PropertyMetadata(CompareEnum.Equal));

        #endregion

        public DataTrigger()
        {

        }
 
    }
}
