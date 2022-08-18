const char PLUS = '+';
const char WS = ' ';

while (true)
{
    Console.WriteLine("введите размерность таблицы");
    int n;

    if (Int32.TryParse(Console.ReadLine(), out n) && n > 1 && n < 6)
    {
        do
        {
            Console.WriteLine("введите произвольный текст");
            string? text = Console.ReadLine();
            int border_count = n * 2;
            int text_length = text.Length;

            if (text != null)
            {
                int m = border_count + text_length;

                for (int i = 1; i <= 3; i++)
                {
                    switch (i) {
                        case 1:
                            firstTablePrint(n, border_count, text_length, text);
                            break;
                        case 2:
                            secondTablePrint(m);
                            break;
                        case 3:
                            thirdTAblePrint(m + 2);
                            break;
                    }
                }
                break;
            }

        } while (true);
        break;
    }
    
}


//Выводим первую таблицу
void firstTablePrint(int n,int border_count, int text_length, string text)
{

    int count_lines = text_length + 2;
    int middle_lines = count_lines / 2;

    string space = new string(WS, n);
    string line_border = new string(PLUS, border_count + text_length + 2);
    string line_space = string.Concat(PLUS, new String(WS, text_length + border_count), PLUS);
    string line_text = string.Concat(PLUS, space, text, space, PLUS);

    for(int i = 0; i <= count_lines; i++)
    {
        switch (i)
        {
            case int j when j == count_lines || j == 0:
                Console.WriteLine(line_border);
                break;
            case int j when j == middle_lines:
                Console.WriteLine(line_text);
                break;
            default:
                Console.WriteLine(line_space);
                break;
        }
    }
    
}

//Выводим вторую таблицу
void secondTablePrint(int n)
{
    int middle = (n % 2 == 0) ? n / 2 : (n + 1) / 2;
    int end = n - 2;

    string border = String.Concat(Enumerable.Repeat(PLUS, n + 2));
    string ord_chars = String.Concat(Enumerable.Repeat("+ ", middle)).Substring(0, n);
    string rev_chars = String.Concat(Enumerable.Repeat(" +", middle)).Substring(0, n);

    for (int i = 0; i <= end; i++)
    {
        if (i == 0 || i == end)
        {
            Console.WriteLine(border);
        }
        else if (i % 2 == 0)
        {
            Console.WriteLine(String.Concat(PLUS, ord_chars, PLUS));
        }
        else
        {
            Console.WriteLine(String.Concat(PLUS, rev_chars, PLUS));
        }
    }

}

//Выводим третью таблицу
void thirdTAblePrint(int n)
{
    char curChar;
    int middle = n / 2;
    int end = n - 1;

    for (int i = 0; i < n; i++)
    {
        List<char> curStr = new List<char>();

        for (int j = 0; j < n; j++)
        {
            if (i == 0 || i == end || j == 0 || j == end)
            {
                curChar = PLUS;
            }
            else if (j == i || j == end - i)
            {
                curChar = PLUS;
            }
            else
            {
                curChar = WS;
            };
            curStr.Add(curChar);
        }
        Console.WriteLine(String.Concat(curStr));
    }
}