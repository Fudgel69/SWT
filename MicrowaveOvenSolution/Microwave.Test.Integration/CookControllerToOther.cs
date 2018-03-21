using System;
using System.Runtime.InteropServices;
using System.Threading;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Controllers;
using MicrowaveOvenClasses.Interfaces;
using NSubstitute;
using NUnit.Framework;
using Timer = MicrowaveOvenClasses.Boundary.Timer;

namespace Microwave.Test.Integration
{
    [TestFixture]
    public class CookControllerToOther
    {

        private IOutput _output;
        private IDisplay _display;
        private IPowerTube _powerTube;
        private ITimer _timer;
        private ICookController _cookController;

        [SetUp]
        public void SetUp()
        {
            _output = new Output();
            _display = new Display(_output);
            _powerTube = new PowerTube(_output);
            _timer = new Timer();
            _cookController = new CookController(_timer, _display, _powerTube);
        }


        [Test]
        public void StartCookingFiveSeconds_PowerTubeTurnsOn()
        {
            _cookController.StartCooking(99, 5);
            Thread.Sleep(1);
            Assert.That(_powerTube.ISON.Equals(true));
        }

        [Test]
        public void StartCookingFiveSeconds_PowerTubeTurnsOff()
        {
            _cookController.StartCooking(99, 5);
            Thread.Sleep(5);
            Assert.That(_powerTube.ISON.Equals(false));
        }

    }
}