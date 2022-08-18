
Node tree = null;

while (true)
{
    Console.WriteLine("Введите имя сотрудника: ");
    string? name = Console.ReadLine();
    if (String.IsNullOrEmpty(name))
    {
        break;
    }
    Console.WriteLine("Введите зарплату сотрудника: ");
    var i = Console.ReadLine();
    int salary = int.Parse(i);

    if (tree == null)
    {
        tree = new Node
        {
            Name = name,
            Salary = salary
        };
    }
    else
    {
        AddNode(tree, new Node
        {
            Name=name,
            Salary=salary
        });
    }
}
Traverse(tree);

while (true)
{
    Console.WriteLine("Введите интересующую вас зарплату. Чтобы выйти введите 0: ");
    var i = Console.ReadLine();
    int salary = int.Parse(i);
    if(salary == 0)
    {
        break;
    }
    var NodeMessage = Find(tree, salary);
    Console.WriteLine(NodeMessage);
    

}

static string Find(Node node, int needle)
{

    if (needle < node.Salary)
    {
        if (node.Left != null)
        {
            return Find(node.Left, needle);
        }
        else
        {
            return ("Такой сотрудник не найден");
        }
    }
    else if (needle > node.Salary)
    {
        if (node.Right != null)
        {
            return Find(node.Right, needle);
        }
        else
        {
            return ("Такой сотрудник не найден");
        }
    }
    else
    {
        return node.Name;
    }
}

static void Traverse(Node node)
{
    if (node.Left != null)
    {
        Traverse(node.Left);
    }

    Console.WriteLine("Имя: " + node.Name + " " + "Зарплата: " + node.Salary);

    if (node.Right != null)
    {
        Traverse(node.Right);
    }
}

static void AddNode(Node node, Node toAdd)
{
    if (toAdd.Salary < node.Salary)
    {
        // идем в левое поддерево
        if (node.Left != null)
        {
            AddNode(node.Left, toAdd);
        }
        else
        {
            node.Left = toAdd;
        }
    }
    else
    {
        // идем в правое поддерево
        if (node.Right != null)
        {
            AddNode(node.Right, toAdd);
        }
        else
        {
            node.Right = toAdd;
        }
    }
}
class Node
{
    public string Name { get; set; }
    public int Salary { get; set; }

    public Node Left { get; set; }
    public Node Right { get; set; }
}