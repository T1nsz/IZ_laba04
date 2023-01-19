using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IZ_laba04
{
    class DataProcessor
    {
        readonly MainWindow form1;
        public DataProcessor(MainWindow Form1)
        {
            form1 = Form1;
        }

        StreamReader sr = new StreamReader("laba03.txt");
        public List<string> temp = new List<string>();
        int i = 0;
        public List<string> temp_answers = new List<string>();

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
                i += 2;
            }

            temp_answers = new List<string>();

            string[] temp_quiz = temp[0].Split('\n');

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
                {
                    continue;
                }
                string temporary = temp1.Split('=')[1];
                if (!temp_answers.Contains(temporary))
                {
                    temp_answers.Add(lol.Split('\n')[i + 1].Split('=')[1]);
                }
            }
            string[] tempp = temp[0].Split('"');
            form1.Question_label.Content = temp[0].Split('\n')[i + 1].Split('=')[0].Split('"')[1];
            return;
        }
    }
}
