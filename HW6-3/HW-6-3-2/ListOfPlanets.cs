
class ListOfPlanets
{

    public ListOfPlanets()
    {
        Planet Earth = new();
        Earth.Name = "Земля";
        Earth.Position = 3;
        Earth.Equator_km = 12_750;

        Planet Mars = new();
        Mars.Name = "Марс";
        Mars.Position = 4;
        Mars.Equator_km = 6_670;
        Mars.PreviousPlanet = Earth;

        Planet Venus = new();
        Venus.Name = "Венера";
        Venus.Position = 2;
        Venus.Equator_km = 12_103;
        Venus.PreviousPlanet = Mars;

        Planets.Add(Earth);
        Planets.Add(Mars);
        Planets.Add(Venus);

    }

    static List<Planet> Planets = new();

    public (int pos, int eq, string? error) GetPlanet(string name, Func<string, string?> planetValidator)
    {

        string? alert = planetValidator(name);

        foreach (Planet planet in Planets)
        {
            if (planet.Name == name && string.IsNullOrEmpty(alert))
            {
                return (planet.Position, planet.Equator_km, "Выполнено успешно");
                               
            } else if (planet.Name == name && !string.IsNullOrEmpty(alert))
            {
                return (0, 0, alert);
            }
        }
        return (0, 0, "Не удалось найти планету");

    }


}

