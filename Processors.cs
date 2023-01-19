using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IZ_laba04
{
    //class TXT
    //{
    //    public List<List<string>> Answers = new List<List<string>>(); //Ответы (их больше 1 для одного вопроса)
    //    public List<string> Ans = new List<string>();
    //    public List<string> Questions = new List<string>(); //Вопросы
    //    public List<string> Goals = new List<string>(); //Цели

    //    //У каждого вопроса свой индекс, который совпадает с индексом ответов.

    //    public void ReadFile(string Path)
    //    {
    //        StreamReader sr = new StreamReader(Path);
    //        string line;
    //        string[] line2;
    //        bool flag1 = false; //флаг для questions
    //        bool flag2 = false; //флаг для answers
    //        int schet;          //поиск индекса

    //        while ((line = sr.ReadLine()) != null)
    //        {
    //            if (line.StartsWith("ЕСЛИ") | line.StartsWith("\tИ")) //Факторы
    //            {
    //                if (line.StartsWith("\tИ")) //Если встречаем И, то нам нужна следующая строка
    //                {
    //                    line = sr.ReadLine();
    //                }
    //                line2 = line.Split('"'); // line2[1] - вопрос, line2[3] - ответ
    //                schet = 0;
    //                foreach (string str in Questions)    //Проверка, имеется ли уже такой вопрос в бд.
    //                {
    //                    if (str == line2[1])
    //                    {
    //                        flag1 = true;
    //                        break;
    //                    }
    //                    schet++;
    //                }
    //                if (flag1 == false) //Если не нашелся, то добавляется и создается новый список в ответах
    //                {
    //                    Questions.Add(line2[1]);

    //                    Ans = new List<string>();
    //                    Answers.Add(Ans);
    //                }
    //                foreach (string str in Answers[schet]) //ищем ответ
    //                {
    //                    if (str == line2[3])
    //                    {
    //                        flag2 = true;
    //                        break;
    //                    }
    //                }
    //                if (flag2 == false) //Если не найден, то добавляем
    //                {
    //                    Answers[schet].Add(line2[3]);
    //                }
    //            }
    //            if (line.StartsWith("ТО")) //Встречаем цель
    //            {
    //                line = line.Remove(0, 3);
    //                line = line.TrimEnd(';');

    //                foreach (string str in Goals)
    //                {
    //                    if (str == line)
    //                    {
    //                        flag1 = true;
    //                        break;
    //                    }
    //                }
    //                if (flag1 == false)
    //                {
    //                    Goals.Add(line);
    //                }
    //            }
    //            flag1 = false;
    //            flag2 = false;
    //        }
    //    }
    //}

    class DataProcessor
    {
        MainWindow form1;
        public DataProcessor(MainWindow Form1)
        {
            form1 = Form1;
        }


        StreamReader sr = new StreamReader("laba03.txt");
        //MainWindow form1 = new MainWindow(); //Передача формы 
        public List<string> temp = new List<string>(); //Хранилище деревьев
        int i = 0; // Текущий номер строки
        public List<string> temp_answers = new List<string>(); // Варианты ответа текущего вопроса

        public void Input()
        {
            string[] data;
            string temp = "";
            string line;

            while ((line = sr.ReadLine()) != null)
                temp += "\n" + line;

            data = temp.Split(';');

            form1.Question_label.Content = "loddddl";

            this.temp = data.ToList();
            this.temp.RemoveAt(this.temp.Count - 1);
            return;
        }

        public void Quiz(string choise)
        {
            if (choise != null)
            {
                for (int k = 0; k < temp.Count; k++)
                {
                    if (temp[k].Split('\n')[i+1].Split('=')[1] != choise)
                    {
                        temp.RemoveAt(k);
                        k--;
                    }
                }
                i += 2; // Итератор 
            }

            temp_answers = new List<string>();

            string[] temp_quiz = temp[0].Split('\n'); // Сплит первого набора в списке

            foreach (string lol in temp)
            {
                if (lol.Split('\n')[i].Contains("ТО "))
                {
                    form1.Question_label.Content = lol.Split('\n')[i];
                    form1.Answer_box.Visibility = Visibility.Collapsed;
                    form1.test_button.Visibility = Visibility.Collapsed;
                    return;
                }
                string temp1 = lol.Split('\n')[i+1];
                if (lol == "")
                    continue;
                string temporary = temp1.Split('=')[1]; // Добавление всех вариантов ответа на текущий вопрос
                if (!temp_answers.Contains(temporary))
                   temp_answers.Add(lol.Split('\n')[i+1].Split('=')[1]);
            }
            string[] tempp = temp[0].Split('"');
            form1.Question_label.Content = temp[0].Split('\n')[i + 1].Split('=')[0]; // Как достать вопрос из строки
            return; 
        }
    }
}
