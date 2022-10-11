using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1011
{
    internal class Day1011
    {
        static void Main(string[] args)
        {

            //Person person = new Person("山田太郎");
            //person.Show();
            Student student = new Student("mizuki");
            student.Show();
            Student student1 = new Student();
            student.Show();

            /*出力
            学年：３
            名前：小友
             */
            /*
            List<string> list = new List<string> { "mizuki","taro","hanako","jiro"};
            //Console.WriteLine(list.Count);

            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic[1] = "Tokyo";
            dic[2] = "London";
            foreach(string i in dic.Values)
            {
                Console.WriteLine(i);
            }

            string str = "123.987";
            double num = 123.45678;
            double tmp = Double.Parse(str);
            Console.WriteLine(tmp);
            */
            //演習問題1
            /*
            int num1 = 10;
            int num2 = 20;
            int sum = num1 + num2;
            Console.WriteLine(sum);

            //演習問題2
            for(int i = 2; i < 6; i++)
            {
                Console.WriteLine(i);
            }

            //演習問題3
            
             
             */

            /*
            Child tmp = new Grand();
            tmp.Show();
            tmp.Con();
            */
            /*
            Monster m = new Monster(10);
            m.ShowHp();
            Random rand = new Random();
            while (m.Hp != 0)
            {
                int ran = rand.Next(1, 10);
                Console.WriteLine("モンスターが{0}のダメージを受ける", ran);
                m.Attack(ran);
                m.ShowHp();
            }
            Console.WriteLine("**敵を撃破**");
            */
        }
    }
    public class Monster : GameChar
    {
        public Monster(int hp):base(hp)
        {

        }
        public override void Attack(int damage)
        {
            base.Attack(damage);
            if (this.Hp == 0)
            {
                Console.WriteLine("==ゴールドをゲット！==");
            }
        }
    }
    public class GameChar
    {
        public int Hp { get; set; }
        public GameChar(int hp)
        {
            this.Hp = hp;
        }
        public virtual void Attack(int damage)
        {
            //継承したクラスがHpにアクセスできないから、読み取り専用だとエラーになる
            this.Hp -= damage;
            if (this.Hp <= 0)
            {
                Hp = 0;
            }
        }
        public void ShowHp()
        {
            Console.WriteLine("HP:{0}", this.Hp);
        }
    }
    interface Parent1
    {
        void Show();
    }
    public abstract class Child : Parent1
    {
        public void Show()
        {
            Console.WriteLine("Child:Parent");
        }
        public abstract void Con();
    }
    public class Grand:Child
    {
        public override void Con()
        {
            Console.WriteLine("Con");
        }
    }
    public class Student : Person//Personを継承した子クラス
    {
        private int grade = 1;
        /*
        public Student(int grade,string name):base(name)
        {
            this.grade = grade;
            Console.WriteLine("Student(Sub)");
        }*/
        public override void Show()
        {
            Console.WriteLine("学年：{0}",this.grade);
            base.Show();//javaでは、super.show()
        }
        public Student()//:base()
        {
            Console.WriteLine("=================");
        }
        public Student(string name) : base(name)
        {
            Console.WriteLine("=================");
        }
    }
    public class Person//親クラス
    {
        //子クラスで親クラスのコンストラクタを呼び出しているのに、
        //なぜコンソール出力がされない？
        private string name;
        public Person()
        {
            Console.WriteLine("---------------");
        }
        public Person(string name)
        {
            this.name = name;
            Console.WriteLine("Person(Super)");
        }
        public virtual void Show()
        {
            Console.WriteLine("名前：{0}", this.name);
        }
    }
}
