using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20221111
{
    public class Day1111
    {
        
        static void Main(string[] args)
        {
            //Q1.q();
            //Q2.q();
            //CsvOut();
            CsvIn();
        }

        private static string path1 = "C:\\Users\\ia\\source\\repos\\20221111\\20221111\\record.csv";
        public static void CsvIn()
        {
            using (var parser = new TextFieldParser(path1))
            {
                //parser.Delimiters = new string[] { "," };
                List<string> list = new List<string>();
                while (!parser.EndOfData)
                {
                    list.Add(parser.ReadLine());
                }
                string[,] strs = new string[list.Count, 4];
                for (int j = 0; j < list.Count; j++)
                {
                    string[] tmp = list[j].Split(',');
                    foreach (string str in tmp)
                    {
                        Console.WriteLine("60{0}", str);
                    }
                    Console.WriteLine("62strs.GetLength(0)＝{0}", strs.GetLength(0));
                    for (int i = 0; i < strs.GetLength(1); i++)
                    {
                        strs[j, i] = tmp[i];
                    }
                }
                for (int j = 0; j < strs.GetLength(0); j++)
                {
                    for (int i = 0; i < strs.GetLength(1); i++)
                    {
                        Console.WriteLine("72strs[{1}, {2}]={0}", strs[j, i],j,i);
                    }
                    Console.WriteLine("===================");
                }
                //Enter押すたびに変わる
                string input = "";
                while (input == "")
                {
                    Random rand = new Random();
                    for (int i = 0; i < strs.GetLength(1); i++)
                    {
                        int ran = rand.Next(strs.GetLength(1));
                        //Console.WriteLine(ran);
                        Console.Write(strs[ran,i]);

                    }
                    input = Console.ReadLine();
                    Console.Clear();
                }
            }
        }
        public static void CsvOut()
        {
            List<string> list = new List<string>();
            //誰が,どこで,何を,どのようにして
            list.Add("チュニジアが,トルコで,右耳を,失った");
            list.Add("ピコ太郎が,アメリカで,ジャスティンビーバーに,再会した");
            list.Add("ケイティペリーが,カリフォルニアの途中で,右肩を,脱臼した");
            list.Add("しもやんが,ＩＡで,肝硬変もどきで,昼寝をした");
            list.Add("コーヒーが,美味しい,だが,とてもおいしい");

            using (StreamWriter sw = new StreamWriter(path1, false, Encoding.UTF8))
            {
                foreach (var line in list)
                {
                    sw.WriteLine(line);
                }
            }
        }
    }
    public class Q1
    {
        public static void q()
        {
            string input = "";
            while (input!="EXIT")
            {
                Console.Write(">");
                input = Console.ReadLine();
                if (input == null||input=="")
                {
                    Console.WriteLine("Error");
                }
                Console.WriteLine(">>{0}", input);
            }
        }
    }
    public class Q2
    {
        public static void q()
        {
            Console.WriteLine("今日は何月何日でしょう？");
            int month;
            int day;
            DateTime dt=DateTime.Now;
            Console.WriteLine(dt);
            Console.WriteLine(dt.ToString("MM/dd"));
            int chmonth = int.Parse(dt.ToString("MM"));
            int chday = int.Parse(dt.ToString("dd"));
            while (true)
            {
                Console.Write("何月？==>");
                string monthin = Console.ReadLine();
                Console.Write("何日？==>");
                string dayin = Console.ReadLine();
                if (int.TryParse(monthin, out month) && int.TryParse(dayin,out day)){
                    if(month==chmonth && day == chday)
                    {
                        Console.WriteLine("正解！！");
                    }
                    else
                    {
                        Console.WriteLine("間違っています！");
                    }
                    Console.WriteLine("END");
                    break;
                }
            }
            
            

        }
    }
}
