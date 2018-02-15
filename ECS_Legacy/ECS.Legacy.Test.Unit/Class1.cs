using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ECS.Legacy.Test.Unit
{
    [TestFixture]
    public class ESCUnitTest
    {
        [Test]
        public void TestTemperature()
        {
            TestTempSensor uut = new TestTempSensor();
            Assert.That(uut.GetTemp(), Is.EqualTo(25));
        }

        [Test]
        public void TestHeaterOn()
        {
            TestHeater uut = new TestHeater();
            uut.TurnOn();
            Assert.That(uut._on, Is.EqualTo(1));
        }

        [Test]
        public void TestHeaterOff()
        {
            TestHeater uut = new TestHeater();
            uut.TurnOff();
            Assert.That(uut._on, Is.EqualTo(0));
        }

        [Test]
        public void TestHeaterSelfTest()
        {
            TestHeater uut = new TestHeater();
            Assert.That(uut.RunSelfTest, Is.EqualTo(true));
        }

        [Test]
        public void TestTempSensorSelfTest()
        {
            TestTempSensor uut = new TestTempSensor();
            Assert.That(uut.RunSelfTest, Is.EqualTo(true));
        }
    }
}
