try
{
    Stack ss = new("a", "b", "c");

    Stack aa = new();

    Console.WriteLine($"Size = {ss.Size} Top = {ss.Top}");

    ss.Pop();

    Console.WriteLine($"Size = {ss.Size} Top = {ss.Top}");

    ss.Merge(new Stack("a", "2"));

    Console.WriteLine($"Size = {ss.Size} Top = {ss.Top}");

    Console.WriteLine(" \n \n \n \n \n");

    Console.WriteLine("Со Stack aa:");

    Console.WriteLine("Выполняем: Stack.Concat(aa, new Stack('a', 'b', 'c'), new Stack('1', '2', '3'), new Stack('А', 'Б', 'В'))");

    Stack.Concat(aa, new Stack("a", "b", "c"), new Stack("1", "2", "3"), new Stack("А", "Б", "В"));

    Console.WriteLine("Получаем: ");


    foreach(string text in aa.Strings)
    {
        Console.Write(text + ", ");
    }

    Console.WriteLine($"Size = {aa.Size} Top = {aa.Top}");





}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
public class Stack
{
    public Stack(params string[] str)
    {
        AddMore(str);
    }

    public int Size
    {
        get { return strings.Count; }
    }

    public string Top
    {
        get { 
            if (strings.Count == 0)
            {
                return null;
            }
            else
            {
                return strings[strings.Count - 1];
            }
                
        }
    }

    private List<string> strings = new();

    public List<string> Strings
    {
        get { return strings; }
    }

    public void Add(string str)
    {
        strings.Add(str);
    }

    public void AddMore(params string[] str)
    {
        strings.AddRange(str);
    }
    public string Pop()
    {
        if(strings.Count == 0)
        {
            throw new Exception("Стек пустой!");
        }
        string str = strings[strings.Count - 1];
        strings.RemoveAt(strings.Count - 1);
        return str;
    }
    public static void Concat(Stack b, params Stack[] stack)
    {

        foreach (Stack s in stack)
        {
            Stack a = new();
            Stack c = new();
            for (int i = 0; i < s.strings.Count; i++)
            {
                a.Strings.Add(s.strings[i]);
                
            }
            foreach (string str in a.strings)
            {
                c.strings.Add(str);
            }
            c.strings.Reverse();
            foreach(string str in c.strings)
            {
                b.Strings.Add(str);
            }


        }

    }



}

public static class StackExtensions{
    public static void Merge(this Stack s1, Stack s2)
    {
        s2.Strings.Reverse();

        for(int i = 0; i < s2.Strings.Count; i++)
        {
            s1.Add(s2.Strings[i]);
        }

        
    }
}