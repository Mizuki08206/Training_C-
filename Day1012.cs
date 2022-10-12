using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace practice
{
    internal class Day1012
    {

        static void Main(string[] args)
        {
            //2022/10/12集合研修
            //Mammals cat = new Cat("猫");
            //Mammals mice = new Mice("ネズミ");
            //Practice1.q();
            //Practice2.q();
            //Practice3.q();
            //Practice4.q();
            //Practice5.q();
            //Practice6.q();


            //MakeMan.m();
            //DigiTex7.m();
            AccessCounter ac = new AccessCounter();
            ac.Log();



        }
    }

    

    public class AccessCounter//最終アクセスを保持するクラスを作成する
    {
        private string path= @"C:\\Users\\mizuk\\OneDrive\\ドキュメント\\PowerSolutions研修\\7.C#\\access.txt";
        private string access;
        private int num=1;
        public AccessCounter()
        {
            Console.WriteLine("最終アクセスを記録");
        }
        public void Log()
        {
            using(StreamReader sr = new StreamReader(this.path))
            {
                if (!sr.EndOfStream)
                {
                    this.access= sr.ReadLine();
                    this.num = int.Parse(sr.ReadLine());
                    Console.WriteLine("前回のアクセスは\n{0}\n{1}回目です", this.access, this.num);
                }
                else
                {
                    Console.WriteLine("最初のアクセスです。");
                }
            }
            
            using(StreamWriter sw = new StreamWriter(this.path, false, Encoding.UTF8))
            {
                DateTime t = DateTime.Now;
                string result = t.ToString("yyyy年MM月dd日 HH時mm分ss秒:");
                //Console.WriteLine(result);
                sw.WriteLine(result);
                //Console.WriteLine(this.num+1);
                sw.WriteLine(this.num+1);
            }
        }
    }
    public class DigiTex7
    {
        public static void m()
        {
            string url = @"C:\Users\mizuk\OneDrive\ドキュメント\PowerSolutions研修\7.C#\sample.txt";
            using(StreamWriter sw=new StreamWriter(url, true,Encoding.UTF8))
            {
                sw.WriteLine("Hello");
                sw.WriteLine("World");
            }
            //usingを使用しない場合は、closeで閉める
            StreamWriter tmp = new StreamWriter(url, true, Encoding.UTF8);
            tmp.WriteLine("Good Morning");
            tmp.Close();
        }
    }
    public class MakeMan
    {
        public static void m()
        {
            List<Man> men = new List<Man>();
            for (int i = 0; i < 5; i++)//人の登録
            {
                string name = null;
                while (true)
                {
                    try
                    {
                        Console.Write("名前は？＞＞");
                        name = Console.ReadLine();
                        Console.Write("年齢は？＞＞");
                        int age = int.Parse(Console.ReadLine());//文字列を数値に変換できなければ、catchに入る
                        men.Add(new Man(name, age, 100 + i));
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("入力がおかしい");
                    }
                }
            }
            foreach (Man m in men)
            {
                m.Walk();
            }
        }
    }
    public class Man:Human
    {
        public int strong { get; set; }
        public Man(string name,int age,int strong):base(name,age)
        {
            Console.WriteLine("---Man---");
            this.strong = strong;
        }
        public override void Walk()
        {
            Console.WriteLine("{0}歳の{1}は{2}の力で歩いた", this.age, this.name, this.strong);
        }
    }
    public abstract class Human
    {
        public string name { get; set; }
        public int age { get; set; }
        public Human(string name,int age)
        {
            Console.WriteLine("---Human---");
            this.age = age;
            this.name = name;
        }
        public abstract void Walk();
    }

    //2022/10/12集合研修
    public class Cat : Mammals
    {
        public override void Bark()
        {
            Console.WriteLine("ニャーニャー");
        }
        public Cat(string name)//:base(name)
        {
            this.name = name;
            this.ShowName();
            this.Bark();
            Console.WriteLine("---------------");
        }
    }
    public class Mice : Mammals
    {
        public override void Bark()
        {
            Console.WriteLine("チューチュー");
        }
        public Mice(string name)// : base(name)
        {
            this.name = name;
            this.ShowName();
            this.Bark();
            Console.WriteLine("---------------");
        }
    }
    public abstract class Mammals
    {
        //名前
        protected string name = "";
        //抽象メソッド
        public abstract void Bark();
        public void ShowName()
        {
            Console.WriteLine("名前：{0}", this.name);
        }

    }
    interface IDrive
    {
        void Drive();
    }
    interface IMechanical
    {
        void Maintain();
    }
    public class Car : IDrive, IMechanical
    {
        public void Drive()
        {
            Console.WriteLine("運転する。");
        }
        public void Maintain()
        {
            Console.WriteLine("メンテナンスをする。");
        }
    }
    public class Practice1
    {
        public static void q()
        {
            List<string> array = new List<string>();
            while (true)
            {
                Console.Write("文字列を入力>>");
                string instr= Console.ReadLine();
                if (instr == null)
                {
                    Console.WriteLine("NULLでした");
                }
                if (instr == "")
                {
                    Console.WriteLine("終了します");
                    break;
                }
                array.Add(instr);
            }
            foreach(string outstr in array)
            {
                Console.WriteLine(outstr);
            }
        }

    }
    public class Practice2
    {
        public static void q()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic["cat"] = "猫";
            dic["dog"] = "犬";
            dic["bird"] = "鳥";
            dic["riger"] = "トラ";
            Console.Write("英語で動物の名前を入力してください：");
            string input=Console.ReadLine();
            bool flag = true;
            foreach(string key in dic.Keys)
            {
                if (key == input)
                {
                    Console.WriteLine("「{0}」です。", dic[input]);
                    flag = false;
                }
            }
            if (flag)
            {
                Console.WriteLine("対応するデータは登録されていません。");
            }
        }
        
    }
    public class Practice3
    {
        public static void q()
        {
            HashSet<int> rans = new HashSet<int>();
            Random rand = new Random();
            Console.Write("乱数：");
            for(int i = 0; i < 10; i++)
            {
                int ran = rand.Next(1, 10);
                Console.Write(" {0}", ran);
                rans.Add(ran);
            }
            Console.Write("\n出現した数：");
            foreach(int tmp in rans)
            {
                Console.Write(" {0}", tmp);
            }
            Console.WriteLine();
        }
    }
    public class Practice4
    {
        public static void q()
        {
            List<int> nums = new List<int>();
            while (true)
            {
                try
                {
                    Console.WriteLine("整数を入力してください");
                    int num=int.Parse(Console.ReadLine());
                    if (num < 0)
                    {
                        //Console.WriteLine("終了します");
                        break;
                    }
                    nums.Add(num);
                }catch(Exception e)
                {
                    Console.WriteLine("数値で入力してください");
                }
            }
            foreach(int num in nums)
            {
                Console.WriteLine(num);
            }

        }
    }
    public class Practice5
    {
        public static void q()
        {
            Dictionary<int,string> mo=new Dictionary<int,string>();
            mo[1] = "Ja";
            mo[2] = "Fe";
            mo[3] = "Ma";
            mo[4] = "Ap";
            mo[5] = "Ma";
            mo[6] = "June";
            mo[7] = "July";
            mo[8] = "Au";
            mo[9] = "Se";
            mo[10] = "Oc";
            mo[11] = "No";
            mo[12] = "Di";
            int input = 0;
            bool flag = false;
            while (true)
            {
                try
                {
                    Console.WriteLine("月(1～12)を入力してください");
                    input = int.Parse(Console.ReadLine());
                    break;
                }catch(Exception e)
                {
                    Console.WriteLine("数値で入力してください");
                }
            }
            foreach(int key in mo.Keys)
            {
                if (key == input)
                {
                    Console.WriteLine(mo[key]);
                    flag = true;
                }
            }
            if (!flag)
            {
                Console.WriteLine("入力された月はありませんでした");
            }
        }
    }
    public class Practice6
    {
        public static void q()
        {
            List<string> array = new List<string>();
            while (true)
            {
                string input=Console.ReadLine();
                if (input == "")
                {
                    Console.WriteLine("Enterが押された");
                    break;
                }
                array.Add(input);
            }
            Console.WriteLine("5文字以上の文字列は");
            foreach(string output in array)
            {
                if (5 <= output.Length)
                {
                    Console.WriteLine(output);
                }
            }
        }
    }

}