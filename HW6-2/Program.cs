
ListOfPlanets listOfPlanets = new();

var Earth = listOfPlanets.GetPlanet("Земля");
Console.WriteLine("Земля\n" +
                 "Диаметр экватора: {0}\n" +
                 "Позиция от Солнца: {1}\n" +
                 "Успешность: {2}\n", Earth.eq, Earth.pos, Earth.error);

var Limonia = listOfPlanets.GetPlanet("Лимония");
Console.WriteLine("Лимония\n" +
                 "Диаметр экватора: {0}\n" +
                 "Позиция от Солнца: {1}\n" +
                 "Успешность: {2}\n", Limonia.eq, Limonia.pos, Limonia.error);

var Mars = listOfPlanets.GetPlanet("Марс");
Console.WriteLine("Марс\n" +
                 "Диаметр экватора: {0}\n" +
                 "Позиция от Солнца: {1}\n" +
                 "Успешность: {2}\n", Mars.eq, Mars.pos, Mars.error);

