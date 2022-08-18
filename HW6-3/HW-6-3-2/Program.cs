
int n = 0;
Func<string, string?> Validation = (i) =>
{
    if (n < 3)
    {
        n++;
        return null;
    }
    n = 0;
    return "Вы спрашиваете слишком часто";
};

ListOfPlanets listOfPlanets = new();

var Earth = listOfPlanets.GetPlanet("Земля", Validation);
Console.WriteLine("Земля\n" +
                 "Диаметр экватора: {0}\n" +
                 "Позиция от Солнца: {1}\n" +
                 "Успешность: {2}\n", Earth.eq, Earth.pos, Earth.error);

var Limonia = listOfPlanets.GetPlanet("Лимония", Validation);
Console.WriteLine("Лимония\n" +
                 "Диаметр экватора: {0}\n" +
                 "Позиция от Солнца: {1}\n" +
                 "Успешность: {2}\n", Limonia.eq, Limonia.pos, Limonia.error);

var Mars = listOfPlanets.GetPlanet("Марс", Validation);
Console.WriteLine("Марс\n" +
                 "Диаметр экватора: {0}\n" +
                 "Позиция от Солнца: {1}\n" +
                 "Успешность: {2}\n", Mars.eq, Mars.pos, Mars.error);
