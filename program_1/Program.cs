using System;


namespace program_1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Int32 a, b;
            Int64 c;
            double x, y, res;
/*
            ///task 1
            Console.WriteLine("Task 1\nHello World!");
            Console.WriteLine("Press Enter to go to thi next task!");
            Console.ReadLine();
            

            ///task 2
            Console.WriteLine("Task 2\nSelect an arithmetic operation(+ - * /)");
            string sign = Console.ReadLine();
            while (sign != "+" && sign != "-" && sign != "*" && sign != "/")
            {
                Console.WriteLine("Invalid character, try again!");
                sign = Console.ReadLine();
            }
            Console.WriteLine("Enter two numbers with a Enter");
            a = Convert.ToInt32(Console.ReadLine()); 
            b = Convert.ToInt32(Console.ReadLine());

            switch (sign)
            {
                case "+":
                    Console.WriteLine((a + b).ToString());
                    break;
                case "-":
                    Console.WriteLine((a - b).ToString());
                    break;
                case "/":
                    if (b == 0) { Console.WriteLine("Division by ziro!"); break;}
                    Console.WriteLine(((double)a / (double)b).ToString());
                    break;
                case "*":
                    Console.WriteLine((a * b).ToString());
                    break;
                default:
                    Console.WriteLine("4то ты ввёл ");
                    break;
            }
            Console.WriteLine("Press Enter to go to thi next task!");
            Console.ReadLine();


            ///task 3

            Console.WriteLine("Task 3");
            Console.WriteLine("Enter the following: len, min, max for array");
            Int32   len = Convert.ToInt32(Console.ReadLine()), 
                    min = Convert.ToInt32(Console.ReadLine()), 
                    max = Convert.ToInt32(Console.ReadLine());

            Int32[] ar = new Int32[len];
            Random rand = new Random();
            Console.WriteLine("This random array:");

            for (Int32 i = 0; i < len; i++)
            {
                ar[i] = rand.Next(min, max + 1);
                Console.Write(ar[i].ToString() + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Press Enter to go to thi next task!");
            Console.ReadLine();
            

            ///task 4

            Console.WriteLine("Task 4\nEnter which value to short(- or +)");
            string s = Console.ReadLine();
            while (s != "+" && s != "-")
            {
                Console.WriteLine("Invalid character, try again!");
                s = Console.ReadLine();
            }
            if (s == "+")
                Array.Sort(ar);
            else
                if (s == "-")
                    Array.Reverse(ar);
                else
                    Console.WriteLine("Press to Alt + F4");
            for (Int32 i = 0; i < len; i++)
                Console.Write(ar[i] + " ");
            Console.WriteLine();
            Console.WriteLine("Press Enter to go to thi next task, you");
            Console.ReadLine();

            
            ///Task 5
            
            Console.WriteLine("Task 5\nEnter two numbers(a, b) with a Enter\ny = (2 * tg(a) * sin(b)) / (|a * b| + 1) ");
            x = Convert.ToDouble(Console.ReadLine());
            y = Convert.ToDouble(Console.ReadLine());
            res = ((double)2 * Math.Tan(x) * Math.Sin(y)) / (Math.Abs(x * y) + (double)1);
            Console.WriteLine("y = " + res + "\n");
            
            Console.WriteLine("Enter x\n(Cos(x)^2 - 1)/2 = ?");
            x = Convert.ToDouble(Console.ReadLine());
            res = ((Math.Cos((double)x)) * (Math.Cos((double)x)) - 1) / 2;
            Console.WriteLine("result: " + res + "\n");

            Console.WriteLine("Enter x and y\n1 / sqrt(|x * sin(y)|) = ?");
            x = Convert.ToDouble(Console.ReadLine());
            y = Convert.ToDouble(Console.ReadLine());
            res = (double)1 / Math.Sqrt(Math.Abs(x * Math.Sin(y)));
            Console.WriteLine("result = " + res + "\n");

            Console.WriteLine("Enter x and y\nx^3 * sqrt(|tg(x)| + 1) + y^3 * sqrt(|tg(y)| + 1) * 2");
            x = Convert.ToDouble(Console.ReadLine());
            y = Convert.ToDouble(Console.ReadLine());
            res = Math.Pow(x,3) * Math.Sqrt(Math.Abs(Math.Tan(x)) + 1) + Math.Pow(y,3) * Math.Sqrt(Math.Abs(Math.Tan(y)) + 1) * (double)(2);
            Console.WriteLine("result = " + res + "\n");
            Console.WriteLine("Press Enter to go to thi next task, you");
            Console.ReadLine();
            
            */
            
            ///task 6

            Console.WriteLine("Enter the text for analise:");
            string str = Console.ReadLine(), last_words = "";
            double count_words = 0,
                    count_chars = 0;
            int wordFlag = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ' ') count_chars++;
                if ((((int)str[i] >= 65 && (int)str[i] <= 90) || ((int)str[i] >= 97 && (int)str[i] <= 122)))
                    wordFlag = 1;
                else
                {
                    if (wordFlag == 1)
                    {
                        count_words++;
                        last_words += str[i - 1];
                        wordFlag = 2;
                    }
                }
                if ((i == str.Length - 1) && (wordFlag == 1))
                {
                    count_words++;
                    last_words += str[i];
                }
            }
            Console.WriteLine("word count: " + count_words);
            Console.WriteLine("number of characters without spaces: " + count_chars);
            if (count_words == 0) count_words = 1;
            Console.WriteLine("relation: {0:0.00}", (count_chars / count_words));
            Console.WriteLine("a word from the last characters of words: " + last_words);


            ///end

            Console.WriteLine("Press Enter exit program");
            Console.ReadLine();
        }
    }
}
