using System;
 
class z3
{
    static void Main(string[] args)
    {
        string str = ")((";
 
        int left = 0;
        int right = 0;
        bool checkRight = true;
        foreach (char ch in str)
        {
            if (ch == '(')
                left++;
            if (ch == ')')
            {
                if (left == right)
                    checkRight = false;
                right++;
            }
        }
 
        if (left == right && checkRight)
            Console.WriteLine("да");
        else
        {
            Console.WriteLine("нет");
            if (!checkRight) Console.WriteLine($"первый символ ')' имеет позицию {str.IndexOf(')')}");
            if (left > right)Console.WriteLine($"кол-во символов '{'('}' равно: {left}");
        }
 
        Console.ReadKey();
    }
}