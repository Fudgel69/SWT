namespace ECS.Legacy
{
    interface IHeater
    {
        void TurnOn();
        void TurnOff();
        bool RunSelfTest();
    }
    public class Heater : IHeater
    {
        public void TurnOn()
        {
            System.Console.WriteLine("Heater is on");
        }

        public void TurnOff()
        {
            System.Console.WriteLine("Heater is off");
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }

    public class TestHeater : IHeater
    {
        public int _on { get; set; }
        public void TurnOn()
        {
            System.Console.WriteLine("Heater is on");
            _on = 1;
        }

        public void TurnOff()
        {
            System.Console.WriteLine("Heater is off");
            _on = 0;
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}