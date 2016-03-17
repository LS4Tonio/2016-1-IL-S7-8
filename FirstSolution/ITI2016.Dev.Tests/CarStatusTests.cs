using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ITI2016.Dev.Tests
{
    [TestFixture]
    public class CarStatusTests
    {
        [Test]
        public void CarStatus_basic_flags()
        {
            var s = CarStatus.IsRunning | CarStatus.IsBrakePedal;
            Assert.That((s & CarStatus.IsRunning) != 0, "The car is running.");
            Assert.That((s & CarStatus.IsClutchPedal) == 0, "The clutch pedal is NOT pressed.");

            s = s & ~CarStatus.IsRunning;
            Assert.That((s & CarStatus.IsRunning) == 0, "The car is stopped.");
        }

        [Test]
        public void CarStatus_gear_management()
        {
            // Gear 1
            var s = CarStatus.IsRunning | (CarStatus)(1 << 5);
            Assert.That(s.GetGear(), Is.EqualTo(CarGear.First));
            Assert.That((Int32)s.GetGear(), Is.EqualTo(1));

            // Speed 3
            s = s.SetGear(CarGear.Third);
            Assert.That(s.GetGear(), Is.EqualTo(CarGear.Third));

            // Speed 5
            s = s.SetGear(5);
            Assert.That(s.GetGear(), Is.EqualTo(CarGear.Fifth));
        }

        [Test]
        public void CarStatus_status_check()
        {
            var s = CarStatus.IsRunning;
            Assert.That(s.HasStatus(CarStatus.IsRunning), Is.True, "running");

            s = s | CarStatus.IsBrakePedal;
            Assert.That(s.HasStatus(CarStatus.IsBrakePedal), Is.True, "brake pedal");

            s = s.ToggleStatus(CarStatus.IsBrakePedal);
            Assert.That(s.HasStatus(CarStatus.IsBrakePedal), Is.False, "brake pedal");
        }
    }
}