var Venus1 = new
{

    Name = "Венера",
    Position = 2,
    Equator_km = 12_102

};

var Earth = new
{

    Name = "Земля",
    Position = 3,
    Equator_km = 12_742,
    
    PreviousPlanet = Venus1

};

var Mars = new
{
    Name = "Марс",
    Position = 4,
    Equator_km = 6_779,

    PreviousPlanet = Earth

};

var Venus2 = new
{

    Name = "Венера",
    Position = 2,
    Equator_km = 12_102, 
    
    PreviousPlanet = Mars

};

Console.WriteLine($"Планета: {Venus1.Name} \nПозиция от Солнца: {Venus1.Position} \nДиаметр экватора: {Venus1.Equator_km}км");
if (!Venus1.Equals(Venus1))
    Console.WriteLine($"{Venus1.Name} - не эквивалентна Венере");
else
    Console.WriteLine($"{Venus1.Name} - эквивалентна Венере");

Console.WriteLine();

Console.WriteLine($"Планета: {Earth.Name} \nПозиция от Солнца: {Earth.Position} \nДиаметр экватора: {Earth.Equator_km}км");
if (!Earth.Equals(Venus1))
    Console.WriteLine($"{Earth.Name} - не эквивалентна Венере");
else
    Console.WriteLine($"{Earth.Name} - эквивалентна Венере");

Console.WriteLine();

Console.WriteLine($"Планета: {Mars.Name} \nПозиция от Солнца: {Mars.Position} \nДиаметр экватора: {Mars.Equator_km}км");
if (!Mars.Equals(Venus1))
    Console.WriteLine($"{Mars.Name} - не эквивалентна Венере");
else
    Console.WriteLine($"{Mars.Name} - эквивалентна Венере");

Console.WriteLine();

Console.WriteLine($"Планета: {Venus2.Name} \nПозиция от Солнца: {Venus2.Position} \nДиаметр экватора: {Venus2.Equator_km}км");
if (!Venus2.Equals(Venus1))
    Console.WriteLine($"{Venus2.Name} - не эквивалентна Венере");
else
    Console.WriteLine($"{Venus2.Name} - эквивалентна Венере");