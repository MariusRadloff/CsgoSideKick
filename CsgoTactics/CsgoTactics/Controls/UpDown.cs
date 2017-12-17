using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CsgoTactics.Controls
{
    class UpDown : Grid
    {


        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static PropertyChangedCallback OnValueChanged { get; private set; }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(UpDown), new PropertyMetadata(0d, OnValueChanged));

        public UpDown()
        {
            CreateUpDown();
        }

        void CreateUpDown()
        {
            Button buttonUp = new Button();
            Button buttonDown = new Button();
            TextBox textBoxValue = new TextBox();

            buttonUp.Height = 15;
            buttonUp.Width = 40;
            buttonUp.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Right;
            buttonUp.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Top;
            buttonUp.Content = "Up";

            buttonDown.Height = 15;
            buttonDown.Width = 40;
            buttonDown.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Right;
            buttonDown.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Bottom;
            buttonDown.Content = "Down";

            textBoxValue.Width = this.Width - buttonDown.Width;
            textBoxValue.Height = buttonDown.Height + buttonUp.Height;
            textBoxValue.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Left;

            this.Children.Add(textBoxValue);
            this.Children.Add(buttonUp);
            this.Children.Add(buttonDown);
            
        }
        private void OnButtonUpClicked()
        {
            Value++;
        }

        private void OnButtonDownClicked()
        {
            Value--;
        }
    }
}
