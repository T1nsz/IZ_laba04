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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Begin_Click(object sender, RoutedEventArgs e)
        {
            titleName.Visibility = Visibility.Collapsed;
            Button_begin.Visibility = Visibility.Collapsed;
            Button_close.Visibility = Visibility.Collapsed;

            DataProcessor processor = new DataProcessor("C://Users//artem//source//repos//IZ_laba04//laba03.txt");
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }

    class TXT
    {
        public List<List<string>> Answers = new List<List<string>>(); //Ответы (их больше 1 для одного вопроса)
        public List<string> Ans = new List<string>();
        public List<string> Questions = new List<string>(); //Вопросы
        public List<string> Goals = new List<string>(); //Цели

        //У каждого вопроса свой индекс, который совпадает с индексом ответов.

        public void ReadFile(string Path)
        {
            StreamReader sr = new StreamReader(Path);
            string line;
            string[] line2;
            bool flag1 = false; //флаг для questions
            bool flag2 = false; //флаг для answers
            int schet;          //поиск индекса

            while ((line = sr.ReadLine()) != null)
            {
                if (line.StartsWith("ЕСЛИ") | line.StartsWith("\tИ")) //Факторы
                {
                    if (line.StartsWith("\tИ")) //Если встречаем И, то нам нужна следующая строка
                    {
                        line = sr.ReadLine();
                    }
                    line2 = line.Split('"'); // line2[1] - вопрос, line2[3] - ответ
                    schet = 0;
                    foreach (string str in Questions)    //Проверка, имеется ли уже такой вопрос в бд.
                    {
                        if (str == line2[1])
                        {
                            flag1 = true;
                            break;
                        }
                        schet++;
                    }
                    if (flag1 == false) //Если не нашелся, то добавляется и создается новый список в ответах
                    {
                        Questions.Add(line2[1]);

                        Ans = new List<string>();
                        Answers.Add(Ans);
                    }
                    foreach (string str in Answers[schet]) //ищем ответ
                    {
                        if (str == line2[3])
                        {
                            flag2 = true;
                            break;
                        }
                    }
                    if (flag2 == false) //Если не найден, то добавляем
                    {
                        Answers[schet].Add(line2[3]);
                    }
                }
                if (line.StartsWith("ТО")) //Встречаем цель
                {
                    line = line.Remove(0, 3);
                    line = line.TrimEnd(';');

                    foreach (string str in Goals)
                    {
                        if (str == line)
                        {
                            flag1 = true;
                            break;
                        }
                    }
                    if (flag1 == false)
                    {
                        Goals.Add(line);
                    }
                }
                flag1 = false;
                flag2 = false;
            }
        }
    }

    class DataProcessor
    {
        public TXT based = new TXT();

        public DataProcessor(string Path)
        {
            based.ReadFile(Path);
        }
    }
}
