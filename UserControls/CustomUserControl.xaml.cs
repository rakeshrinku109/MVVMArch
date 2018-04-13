using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVMArch.UserControls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty setTextProperty = DependencyProperty.Register("setText", typeof(string), typeof(UserControl1), new PropertyMetadata("Default text", new PropertyChangedCallback(OnSetTextChanged)));
        private static void OnSetTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl1 userControl = d as UserControl1;
            userControl.textBlck.Text = e.NewValue.ToString();
            
        }

        private void OnSetTextChanged(DependencyPropertyChangedEventArgs e)
        {
            textBlck.Text = e.NewValue.ToString();
        }


        /// <summary>
        /// CLR property encapsulating the dependency property
        /// </summary>
        public string setText
        {
            get { return (string)GetValue(setTextProperty); }
            set { SetValue(setTextProperty, value); }
        }
     


    }
}
