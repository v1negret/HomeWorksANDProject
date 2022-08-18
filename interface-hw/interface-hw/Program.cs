namespace interface_hw
{
    public class Program
    {

    }
    public interface IRobot
    {
        public string GetInfo();

        public List<string> GetComponents();

        public string GetRobotType() => "I'm a Robot!";

    }

    public interface IChargeable
    {
        public void Charge();

        public string GetInfo();
    }

    public interface IFlyingRobot : IRobot
    {
        public string GetRobotType() => "I'm flying Robot!";
    }
    internal class Quadcopter : IFlyingRobot, IChargeable
    {
        private List<string> _components = new List<string> { "rotor1", "rotor2", "rotor3", "rotor4" };

        public void Charge()
        {
            Console.WriteLine("Charging...");
            Thread.Sleep(3000);
            Console.WriteLine("Charged!");

        }

        public List<string> GetComponents()
        {
            return _components;
        }

        public string GetInfo()
        {
            throw new NotImplementedException();
        }
    }
}

