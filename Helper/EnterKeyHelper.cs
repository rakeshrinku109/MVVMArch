using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace MVVMArch.Helper
{
    public static class EnterKeyHelpers
    {
        public static ICommand GetEnterKeyCommand(DependencyObject target)
        {
            return (ICommand)target.GetValue(EnterKeyCommandProperty);
        }

        public static void SetEnterKeyCommand(DependencyObject target, ICommand value)
        {
            target.SetValue(EnterKeyCommandProperty, value);
        }

        //public static readonly DependencyProperty EnterKeyCommandProperty =
        //    DependencyProperty.RegisterAttached(
        //        "EnterKeyCommand",
        //        typeof(ICommand),
        //        typeof(EnterKeyHelpers),
        //        new PropertyMetadata(null, OnEnterKeyCommandChanged, onEnterKeyCommandChanged));

        public static readonly DependencyProperty EnterKeyCommandProperty = DependencyProperty.RegisterAttached("EnterKeyCommand", typeof(ICommand), typeof(EnterKeyHelpers), new PropertyMetadata(default(ICommand),new PropertyChangedCallback(OnEnterKeyCommandChanged)));



        //public static readonly DependencyProperty EnterKeyCommandProperty =
        //  DependencyProperty.RegisterAttached(
        //      "EnterKeyCommand",
        //      typeof(ICommand),
        //      typeof(EnterKeyHelpers),
        //      new FrameworkPropertyMetadata(null, OnEnterKeyCommandChanged, onEnterKeyCommandChanged));

        private static object onEnterKeyCommandChanged(DependencyObject d, object baseValue)
        {
            return baseValue;
        }

        static void OnEnterKeyCommandChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            
            ICommand command = (ICommand)e.NewValue;
            FrameworkElement fe = (FrameworkElement)target;
            Control control = (Control)target;
            TextBox text = (TextBox)target;
            control.KeyDown += (s, args) =>
            {
                if (args.Key == Key.Enter)
                {
                    // make sure the textbox binding updates its source first
                    BindingExpression b = control.GetBindingExpression(TextBox.TextProperty);
                    if (b != null)
                    {
                        b.UpdateSource();
                    }
                    command.Execute(text.Text);
                }
            };
        }
    }

}
