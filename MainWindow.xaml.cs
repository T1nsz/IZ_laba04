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
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataProcessor form2;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Begin_Click(object sender, RoutedEventArgs e)
        {
            titleName.Visibility = Visibility.Collapsed;
            Button_begin.Visibility = Visibility.Collapsed;
            Button_close.Visibility = Visibility.Collapsed;

            form2 = new DataProcessor(this);

            form2.Input();
            form2.Quiz("8");

            //DataProcessor processor = new DataProcessor(MainWindow);
            //processor.Input();
            //processor.Quiz("0");
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void test_button_Click(object sender, RoutedEventArgs e)
        {
            Question_label.Content = "dadada";
        }
    }


}
