namespace ECS.Legacy
{
    interface ITempSensor
    {
        int GetTemp();
        bool RunSelfTest();

    }
    internal class TempSensor : ITempSensor
    {
        public int GetTemp()
        {
            return 25;
        }

        public bool RunSelfTest()
        {
            
            return true;
        }
    }

    public class TestTempSensor : ITempSensor
    {
        public int GetTemp()
        {
            return 25;
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}