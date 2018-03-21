using System;
using System.Runtime.InteropServices;
using System.Threading;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Controllers;
using MicrowaveOvenClasses.Interfaces;
using NSubstitute;
using NSubstitute.Core;
using NSubstitute.ExceptionExtensions;
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

        #region Powertube

        [Test]
        public void StartCooking_PowerTubeTurnsOn()
        {
            _cookController.StartCooking(99, 5);
            Assert.That(_powerTube.ISON, Is.EqualTo(true));
        }

        [Test]
        public void StartCookingStopCooking_PowerTuberTurnsOff()
        {
            _cookController.StartCooking(99, 5);
            _cookController.Stop();
            Assert.That(_powerTube.ISON, Is.EqualTo(false));
        }

        [Test]
        public void StartCookingFiveSeconds_PowerTubeTurnsOff()
        {
            _cookController.StartCooking(99, 5);
            Thread.Sleep(6000);
            Assert.That(_powerTube.ISON, Is.EqualTo(false));
        }

        #endregion

        #region Display/Output

        [TestCase(50)]
        [TestCase(37)]
        public void StartCooking_OneSecondPasses(int sec)
        {
            _cookController.StartCooking(99, sec);
            Thread.Sleep(1000);
            _output.OutputLine(Arg.Is<string>(str => str.Contains($"00:{sec - 1}")));
        }

        [TestCase(100)]
        [TestCase(50)]
        public void StartCooking_OutputsPower(int powerPercent)
        {
            _cookController.StartCooking(powerPercent, 5);
            _output.OutputLine(Arg.Is<string>(str => str.Contains($"{powerPercent} %")));
        }

        #endregion


        #region Timer



        #endregion

        #region Output

        

        #endregion
    }
}