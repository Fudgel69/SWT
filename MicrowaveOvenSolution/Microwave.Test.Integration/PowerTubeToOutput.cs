using System;
using System.Runtime.InteropServices;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Controllers;
using MicrowaveOvenClasses.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace Microwave.Test.Integration
{
    [TestFixture]
    public class PowerTubeToOutput
    {
        private PowerTube _powertube;
        private Output _output;

        [SetUp]
        public void Setup()
        {
            _output = new Output();
            _powertube = new PowerTube(_output);
        }

        [TestCase(10)]
        [TestCase(50)]
        [TestCase(90)]
        public void TurnOn_DisplaysPower(int pwr)
        {
            _powertube.TurnOn(pwr);
            _output.OutputLine(Arg.Is<string>(str => str.Contains($"{pwr} %")));
        }

        [Test]
        public void TurnOff_DisplaysOff()
        {
            _powertube.TurnOn(50);
            _powertube.TurnOff();
            _output.OutputLine(Arg.Is<string>(str => str.Contains("off")));
        }

        [Test]
        public void TurnOff_NoOutput()
        {
            _powertube.TurnOff();
            _output.OutputLine(Arg.Any<string>());
        }

        [Test]
        public void TurnOnTwice_DisplayException()
        {
            _powertube.TurnOn(50);
            Assert.Throws<System.ApplicationException>(() => _powertube.TurnOn(60));
        }

        [Test]
        public void TurnOnNegativePower_DisplayException()
        {
            Assert.Throws<System.ArgumentOutOfRangeException>(() => _powertube.TurnOn(-1));
        }

        [Test]
        public void TurnOnOverHundred_DisplayException()
        {
            Assert.Throws<System.ArgumentOutOfRangeException>(() => _powertube.TurnOn(101));
        }

        [Test]
        public void TurnOnZero_DisplayException()
        {
            Assert.Throws<System.ArgumentOutOfRangeException>(() => _powertube.TurnOn(0));
        }
    }
}