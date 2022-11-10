using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Training_C____
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunLength.Run();

        }
        public static void Saiki(int num)
        {
            if(num != 0)
            {
                Console.Write("*");
                Saiki(--num);
            }
        }


    }
    public class RunLength//ランレングス法
    {
        public static void Run()
        {
            Console.WriteLine("ランレングス法");
            foreach(var value in values(Console.ReadLine()))
            {
                string valu =value.ToString();
                string[] val = valu.Split(',','(',')',' ');
                foreach(var output in val)
                {
                    Console.Write(output);
                }
            }
            Console.WriteLine();
        }
        static IEnumerable<(char,int)> values(string s)
        {
            var count = 1;
            var prev = s[0];
            for(int i = 0; i < s.Length; i++)
            {
                if (prev == s[i])
                {
                    count++;
                }
                else
                {
                    yield return (prev, count);
                    count = 1;
                }
                prev = s[i];
            }
            yield return(prev, count);
        }
    }
}
