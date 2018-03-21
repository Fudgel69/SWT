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
    public class DisplayToOutput
    {

        private IOutput _output;
        private IDisplay _display;

        [SetUp]
        public void SetUp()
        {
            _output = new Output();
            _display = new Display(_output);

        }

        [TestCase(0, 5)]
        [TestCase(1, 5)]
        [TestCase(12, 33)]
        public void ShowTime_DisplaysTime(int hr, int min)
        {
            _display.ShowTime(hr, min);
            _output.OutputLine(Arg.Is<string>(str => str.Contains($"{hr}:{min}")));

        }

        [TestCase(500)]
        [TestCase(1000)]
        public void ShowPower_DisplaysPower(int watt)
        {
            _display.ShowPower(watt);
            _output.OutputLine(Arg.Is<string>(str => str.Contains($"{watt} W")));
        }

        [Test]
        public void Clear_ClearsDisplay()
        {
            _display.Clear();
            _output.OutputLine(Arg.Is<string>(str => str.Contains("cleared")));

        }

    }
}
