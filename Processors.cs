﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        StreamReader sr = new StreamReader("laba03.txt"); 
        MainWindow form; //Передача формы 
        public List<string> temp = new List<string>(); //Хранилище деревьев
        int i = 0; // Текущий номер строки
        List<string> temp_answers = new List<string>(); // Варианты ответа текущего вопроса

        public void Input()
        {
            string[] data;
            string temp = "";
            string line;

            while ((line = sr.ReadLine()) != null)
                temp += line;

            data = temp.Split(';');

            this.temp = data.ToList();
            return;
        }
        
        public void Quiz()
        {
            while (!temp[0].Split('\n')[i].Contains("ТО")) // Условие выхода ((ГОВНО))
            {
                string[] temp_quiz = temp[0].Split('\n'); // Сплит первого набора в списке
                
                foreach(string lol in temp)
                {
                    string temporary = lol.Split('\n')[i].Split('=')[1]; // Добавление всех вариантов ответа на текущий вопрос
                    if (!temp_answers.Contains(temporary))
                        temp_answers.Add(lol.Split('\n')[i].Split('=')[1]);
                }

                form.Question_label.Content = temp[0].Split('"')[1]; // Как достать вопрос из строки
                i += 2; // Итератор 
            }
        }
    }
}
