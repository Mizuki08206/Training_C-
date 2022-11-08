using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace tmp
{
    internal class Shimoyan01
    {
        private static string path = "C:\\Users\\ia\\source\\repos\\tmp\\tmp\\record.txt";
        private static string path1 = "C:\\Users\\ia\\source\\repos\\tmp\\tmp\\record.csv";

        static void Main(string[] args)
        {
            //CsvOut();
            CsvIn();
            //while (true)
            //{
            //    Console.WriteLine("課題１>>1\n課題２>>2");
            //    Console.Write(">>");
            //    int num = 0;
            //    string input = Console.ReadLine();
            //    if (int.TryParse(input, out num))
            //    {
            //        if (num == 1)
            //        {
            //            Which();
            //            break;
            //        }
            //        else if (num == 2)
            //        {
            //            In();
            //            break;
            //        }
            //    }
            //    Console.WriteLine("入力がおかしい");
            //}

        }
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
                string[,] strs=new string[list.Count,4];
                for(int j=0;j<list.Count;j++)
                {
                    string[] tmp = list[j].Split(',');
                    foreach(string str in tmp)
                    {
                        Console.WriteLine("60{0}",str);
                    }
                    Console.WriteLine("62strs.GetLength(0)＝{0}", strs.GetLength(0));
                    for(int i = 0; i < strs.GetLength(1); i++)
                    {
                        strs[j,i] = tmp[i];
                    }
                }
                for (int j = 0; j < strs.GetLength(0); j++)
                {
                    for (int i = 0; i < strs.GetLength(1); i++)
                    {
                        Console.WriteLine("72strs[j, i]={0}", strs[j, i]);
                    }
                    Console.WriteLine("===================");
                }
                //Enter押すたびに変わる
                string input = "";
                while (input=="")
                {
                    Random rand=new Random();
                    for(int i = 0; i < strs.GetLength(0); i++)
                    {
                        Console.Write(strs[i,rand.Next(strs.GetLength(1))]);
                        
                    }
                    input = Console.ReadLine();
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

            using (StreamWriter sw = new StreamWriter(path1, false,Encoding.UTF8))
            {
                foreach (string line in list)
                {
                    sw.WriteLine(line);
                }
            }
        }

        public static void Which()
        {
            while (true)
            {
                Console.WriteLine("書き出し>>1\n読み込み>>2");
                Console.Write(">>");
                int num = 0;
                string input=Console.ReadLine();
                if(int.TryParse(input, out num))
                {
                    if (num == 1)
                    {
                        Out();
                        break;
                    }
                    else if(num==2)
                    {
                        In();
                        break;
                    }
                }
                Console.WriteLine("入力がおかしい");
            }
        }
        public static void In()
        {
            using(StreamReader sr=new StreamReader(path))
            {
                if (!sr.EndOfStream)
                {
                    List<string> list = new List<string>();
                    while (!sr.EndOfStream)
                    {
                        list.Add(sr.ReadLine());
                    }
                    foreach(string s in list)
                    {
                        Console.WriteLine(s);
                    }
                }
                else
                {
                    Console.WriteLine("何も書かれていませんでした。");
                }
            }
            Console.WriteLine("In終了");
        }
        public static void Out()
        {
            Console.WriteLine("入力してください");
            string input = Console.ReadLine();
            string[] sp = input.Split('。');
            using(StreamWriter sw=new StreamWriter(path,true,Encoding.UTF8))
            {
                foreach(string s in sp)
                {
                    sw.WriteLine(s);
                }
                Console.WriteLine("===================================");
            }
            Console.WriteLine("Out終了");
        }
    }
}
