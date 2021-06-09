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

namespace WpfApp2
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            foreach (UIElement c in LayoutRoot.Children)
            {
                if (c is Button)
                {
                    ((Button)c).Click += Number_Click_2;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            combo.Items.Add(text.Text);
            text.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            combo.Items.RemoveAt(combo.Items.Count-1);
            
        }
        private int count = 1;
        private void Number_Click_2(object sender, RoutedEventArgs e)
         {
            string s = (string)((Button)e.OriginalSource).Content;
            if (s == count.ToString())
            {
                Progress.Value += 6.25;
                (sender as Button).Visibility = Visibility.Collapsed;
                count++;
            }
            else
            {
                foreach (UIElement c in LayoutRoot.Children)
                {
                    if (c is Button)
                    {
                        ((Button)c).Visibility = Visibility.Visible;
                        count = 1;
                        Progress.Value = 0;
                    }
                }
            }
            //this.tab2.Visibility(sender as Button);
             //this.tab2.(sender as Button).Visibility = Visibility.Visible;
        }
        
    }
}
