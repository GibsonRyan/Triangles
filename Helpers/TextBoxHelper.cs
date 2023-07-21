using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System.Text.RegularExpressions;

namespace Triangles.Helpers
{
    public static class TextBoxHelper
    {
        public static readonly DependencyProperty IsNumericOnlyProperty =
            DependencyProperty.RegisterAttached("IsNumericOnly", typeof(bool), typeof(TextBoxHelper), new UIPropertyMetadata(false, OnIsNumericOnlyChanged));

        public static bool GetIsNumericOnly(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsNumericOnlyProperty);
        }

        public static void SetIsNumericOnly(DependencyObject obj, bool value)
        {
            obj.SetValue(IsNumericOnlyProperty, value);
        }

        private static void OnIsNumericOnlyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBox)
            {
                TextBox textBox = (TextBox)d;
                textBox.PreviewTextInput -= TextBox_PreviewTextInput;

                if ((bool)e.NewValue)
                {
                    textBox.PreviewTextInput += TextBox_PreviewTextInput;
                }
            }
        }

        private static void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!IsTextAllowed(e.Text, (TextBox)sender))
            {
                e.Handled = true;
            }
        }

        private static bool IsTextAllowed(string text, TextBox textBox)
        {
            Regex regex = new Regex("[^0-9.]+"); 

            bool isMatch = !regex.IsMatch(text);
            bool onlyOneDot = (textBox.Text + text).Count(c => c == '.') <= 1;

            return isMatch && onlyOneDot;
        }
    }


}
