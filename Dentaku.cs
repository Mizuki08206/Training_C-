using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentaku
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("計算式を入力してください");
            var inputs=Console.ReadLine().Split(' ');

            //発展問題か簡易電卓かを判定
            bool which = false;
            foreach (var input in inputs)
            {
                if (input == "(" || input == ")")//( )の優先のみ対応
                {
                    which = true;
                }
            }
            if (which)
            {
                ECalc(inputs);
            }
            else
            {
                Calc(inputs);
            }
        }
        public static void ECalc(string[] inputs)
        {
            if (ECheck(inputs))
            {
                Console.WriteLine("No Problem");
                //チェックは済んでいるため、正しい計算式が入ってくる前提
                //1.　）を見つける　
                //2.（　を見つける
                //3.計算してaで置換する
                //4.計算結果を、（のインデックスに格納する
                //5.aを削除して前に詰める
                int i = 0;
                while (i<inputs.Length)//括弧をなくすループ
                {
                    if (inputs[i] == ")")//このif内のどこかでArray.Resize
                    {
                        int sum = 0;
                        for(int j = i-1; j >= 0; j--)
                        {
                            if (inputs[j] == "(")
                            {
                                Console.WriteLine("J={0},I={1}", j, i);
                                for (int k = j+1; k < i; k++)
                                {
                                    Console.WriteLine("k=" + k);
                                    if (k == j + 1)
                                    {
                                        sum = int.Parse(inputs[k]);
                                        Console.WriteLine("sum=" + sum);
                                        continue;
                                    }
                                    Console.WriteLine("計算!");
                                    if (int.TryParse(inputs[k], out int num))//ここ後で怪しくなるかも
                                    {
                                        Console.WriteLine("num="+num);
                                        switch (inputs[k-1])
                                        {
                                            case "+":
                                                Console.WriteLine("{0}+{1}", sum, num);
                                                sum += num;
                                                break;
                                            case "-":
                                                Console.WriteLine("{0}-{1}", sum, num);
                                                sum -= num;
                                                break;
                                            case "*":
                                                Console.WriteLine("{0}*{1}", sum, num);
                                                sum *= num;
                                                break;
                                            case "/":
                                                Console.WriteLine("{0}/{1}", sum, num);
                                                sum /= num;
                                                break;
                                        }
                                    }
                                }
                                for(int l = j; l <= i; l++)
                                {
                                    inputs[l] = "aaa";
                                }
                                inputs[j]= sum.ToString();
                                break;
                            }
                        }

                        foreach (var output in inputs)
                        {
                            Console.Write(output + " ");
                        }

                        //aに書き換えるところとaを消して詰めるところ
                        int lc = 0;//aaaが何個重なっているか。いくつ前に詰めるか
                        int end = -1;//aaaが終わるインデックス
                        
                        for(int j=0;j<inputs.Length;j++)
                        {
                            if (inputs[j] == "aaa")
                            {
                                end = j;
                                lc++;
                            }
                        }
                        for(int k = end+1; k < inputs.Length; k++)
                        {
                            inputs[k - lc] = inputs[k];
                        }
                        int tmp = inputs.Length;
                        Array.Resize<string>(ref inputs, tmp - lc);
                        Console.WriteLine("\n配列の長さが{0}=>{1}になりました。", tmp, tmp - lc);
                        i = 0;
                        Console.WriteLine("\n\n============================\n");
                        foreach (var output in inputs)
                        {
                            Console.Write(output+" ");
                        }
                        Console.WriteLine("\n\n============================\n");
                    }
                    i++;
                }

                Calc(inputs);
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
        public static bool ECheck(string[] inputs)//計算式が正しく並んでいるかをチェック
        {
            bool check = true;//計算式が正しく並んでいるか
            bool numor = true;//数値と演算子の順序のチェック
            int brackets = 0;//括弧の組み合わせのチェック、（　は+1で、　）は-1、最終0になれば問題なし
            foreach(var input in inputs)
            {
                if (numor)//数字もしくは括弧が入るべきところのチェック
                {
                    if(int.TryParse(input, out int tmp) || input == "(")
                    {
                        if (int.TryParse(input,out tmp)){//括弧は次に演算子は来ないからfalseにしない
                            numor = false;//次は演算子もしくは閉じ括弧
                        } 
                    }
                    else
                    {
                        check = false;
                    }
                }
                else//演算子が入るべきところのチェック
                {
                    if (input == "+" || input == "-" || input == "*" || input == "/" || input==")")
                    {
                        if (input == "+" || input == "-" || input == "*" || input == "/")
                        {
                            numor = true;//次は数字もしくは開き括弧
                        }
                    }
                    else
                    {
                        check = false;
                    }
                }
                if (input == "(")//たぶん foreach < if < if の中に入れても同じ
                {
                    brackets++;
                }
                else if(input== ")")
                {
                    brackets--;
                }
            }
            if (brackets != 0)
            {
                check = false;
            }
            return check;
        }
        public static void Calc(string[] inputs)
        {
            if (Check(inputs))
            {
                //%2==0が数値
                //%2==1が演算子
                int.TryParse(inputs[0], out int sum);
                int lc = 2;
                while (lc < inputs.Length)
                {
                    switch (inputs[lc - 1])
                    {
                        case "+":
                            sum += int.Parse(inputs[lc]);
                            break;
                        case "-":
                            sum -= int.Parse(inputs[lc]);
                            break;
                        case "*":
                            sum *= int.Parse(inputs[lc]);
                            break;
                        case "/":
                            sum /= int.Parse(inputs[lc]);
                            break;
                    }
                    lc += 2;//必ず数値に添え字を置く
                }
                Console.WriteLine("合計:{0}", sum);
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
        public static bool Check(string[] inputs)
        {
            bool flag = true;
            int lc = 0;
            while (inputs.Length > lc)//%2==0が数字かどうか
            {
                if(!int.TryParse(inputs[lc], out int tmp))
                {
                    flag = false;
                }
                lc += 2;
            }
            lc = 1;
            while (inputs.Length > lc)//%2==1が演算子かどうか
            {
                if (!(inputs[lc] == "+" || inputs[lc] == "-" || inputs[lc] == "*" || inputs[lc] == "/"))
                {
                    flag = false;
                }
                lc += 2;
            }
            if (!(inputs.Length % 2 == 1))//配列の数が正しいかどうか
            {
                flag = false;
            }
            return flag;
        }
    }
    public class Inspection
    {
        public static void A()
        {
            string str1 = "abcde";
            string str2 = "12345";
            Console.WriteLine(int.TryParse(str1,out int num1));
            Console.WriteLine(num1);
            Console.WriteLine(int.TryParse(str2,out int num2));
            Console.WriteLine(num2);

        }
    }
}
