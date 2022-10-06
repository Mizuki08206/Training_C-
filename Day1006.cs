using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace test1006Console{//名前空間
    public class Day1006{//クラス名
        public static void Main(string[] args)
        {//メソッド名
            /*
            Console.WriteLine("Hello C#");
            Console.WriteLine("He said \n\"hello\"");
            int a;
            int b = 5;
            a = 3;
            Console.WriteLine(a + b);
            Console.WriteLine(b - a);
            double d = a;
            Console.WriteLine(d);
            
            int[] numbers = new int[3];
            numbers[0] = 100;
            numbers[1] = 300;
            numbers[2] = 900;
            Console.WriteLine("{0}{1}{2}", numbers[0], numbers[1], numbers[2]);

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
            string[] sports = { "soccer", "tennis", "bascketball" };
            for (int i = 0; i < sports.Length; i++)
            {
                Console.WriteLine(i + sports[i]);
            }
            int[] dice = { 1, 6, 3 };
            for (int i = 0; i < dice.Length; i++)
            {
                Console.WriteLine("{0}の裏の目は{1}", dice[i], 7 - dice[i]);
            }
            string str = "Flower";//文字列Floewrの比較
            if (str == "Flower")
            {
                Console.WriteLine("43");
            }
            if (str.Equals("Flower"))
            {
                Console.WriteLine(47);
            }
            Random rand = new Random();
            int ran = rand.Next(1, 7);
            int ran2 = rand.Next(1,7);
            Console.WriteLine("{0}or{1}", ran, ran2);
            */
            /*
            Person p = new Person("mizuki",24);
            //プレースホルダは文字列と数値で書き分けない
            Console.WriteLine("{0}は{1}", p.GetName(), p.GetAge());
            */
            /*
            Student s = new Student("鈴木ひまり",24);
            //s.name = "鈴木ひまり";
            //s.grade = 3;
            //Console.WriteLine("名前:{0} 学年:{1}",s.name,s.grade);
            s.show();
            */
            /*
            Calc ca = new Calc();
            ca.num1 = 10;
            ca.num2 = 20;
            Console.WriteLine("{0}+{1}={2}", ca.num1, ca.num2, ca.Add());
            Console.WriteLine("{0}-{1}={2}", ca.num1, ca.num2, ca.Sub());
            Console.WriteLine("{0}*{1}={2}", ca.num1, ca.num2, ca.Mul());
            */
            /*
            Car car=new Car();
            car.Fuel = 10;
            Console.WriteLine(car.Fuel);
            */
            /*
            Console.WriteLine("--RPG GAME--");
            GameChar ch = new GameChar("勇者", 10);
            ch.ShowHp();
            Random rand = new Random();
            while (ch.Hp!=0)
            {
                int ran = rand.Next(1, 11);
                Console.WriteLine("{0}は{1}の攻撃を受けた", ch.Name, ran);
                ch.Attack(ran);
                ch.ShowHp();
            }
            Console.WriteLine("**GAMEOVER**");
            */
            /*//ループ内の乱数生成の検証
            for (int i = 0; i < 10; i++)
            {
                int ran = new Random().Next(1, 11);
                Console.Write("{0} ",ran);
            }
            Console.WriteLine();
            Random rand1 = new Random();
            for (int i = 0; i < 10; i++)
            {
                int ran = rand1.Next(1, 11);
                Console.Write("{0} ",ran);
            }
            Console.WriteLine();
            for (int i=0; i < 10; i++)
            {
                Console.Write("{0} ",new Random().Next(1, 11));
            }
            Console.WriteLine();
            for(int i = 0; i < 10; i++)
            {
                int ran = new Random().Next(1, 11);
                Thread.Sleep(10);
                Console.Write("{0} ",ran);
            }
            */
        }
    }
    public class GameChar
    {
        private string name;
        private int hp;
        public GameChar(string name,int hp)
        {
            this.name = name;
            this.hp = hp;
        }
        public string Name
        {
            get { return name; }
            //set { name = value; }//読み取り専用のため
        }
        public int Hp
        {
            get { return hp; }
            //set { hp = value; }//読み取り専用のため
        }
        public void Attack(int damage)
        {
            this.hp -= damage;
            if (this.hp <= 0)
            {
                this.hp = 0;
                Console.WriteLine("{0}は倒れた", this.name);

            }
        }
        public void ShowHp()
        {
            Console.WriteLine("残りHP:{0}", this.hp);
        }
    }
    public class Car
    {
        private int fuel;//field
        //プロパティ、ゲッターで呼び出されているのか、セッターで呼び出されているのかは呼び出し元で分かる
        public int Fuel
        {
            set { fuel = value; }//値の設定（valueは設定された値）
            get { return fuel; }//値の取得
        }
    }
    public class Student
    {
        string name;
        int grade;
        public Student(string name, int grade)
        {
            Console.WriteLine("create instance");
            this.name = name;
            this.grade = grade;
        }
        public void show()
        {
            Console.WriteLine("abcde");
        }
    }
    public class Calc
    {
        public int num1 = 0;
        public int num2 = 0;
        public int Add()
        {
            return this.num1 + this.num2;
        }
        public int Sub()
        {
            return this.num1 - this.num2;
        }
        public int Mul()
        {
            return this.num1 * this.num2;
        }
    }

}
