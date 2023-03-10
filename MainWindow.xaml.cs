using System;
using System.Collections.Generic;
using System.IO;
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

namespace IZ_laba04
{
    public partial class MainWindow : Window
    {
        DataProcessor proc;

        public MainWindow()
        {
            InitializeComponent();
            Question_label.Content = "";
            test_button.Visibility = Visibility.Collapsed;
            Question_label.Visibility = Visibility.Collapsed;
            Answer_box.Visibility = Visibility.Collapsed;
            button_restart.Visibility = Visibility.Collapsed; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ;
        }

        private void Button_Begin_Click(object sender, RoutedEventArgs e)
        {
            titleName.Visibility = Visibility.Collapsed;
            Button_begin.Visibility = Visibility.Collapsed;
            Button_close.Visibility = Visibility.Collapsed;
            test_button.Visibility = Visibility.Visible;
            Answer_box.Visibility = Visibility.Visible;
            button_restart.Visibility = Visibility.Visible;
            Question_label.Visibility = Visibility.Visible;

            proc = new DataProcessor(this);

            proc.Input();
            proc.Quiz(null);

            Answer_box.ItemsSource = proc.temp_answers;
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void test_button_Click(object sender, RoutedEventArgs e)
        {
            if(Answer_box.SelectedItem != null)
            {
                proc.Quiz(Answer_box.SelectedItem.ToString());
                Answer_box.ItemsSource = proc.temp_answers;
            }
        }

        private void button_restart_Click(object sender, RoutedEventArgs e)
        {
            Answer_box.Visibility = Visibility.Visible;
            test_button.Visibility = Visibility.Visible;

            proc = new DataProcessor(this);

            proc.Input();
            proc.Quiz(null);

            Answer_box.ItemsSource = proc.temp_answers;
        }
    }
}
