using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI2016.Dev.Tests
{
    [TestFixture]
    public class CarStatusTests
    {
        [Test]
        public void CarStatus_basic_flags()
        {
            CarStatus s = CarStatus.IsRunning | CarStatus.IsBrakePedal;

            Assert.That( (s & CarStatus.IsRunning) != 0, "The Car is running!" );
            Assert.That( (s & CarStatus.IsClutchPedal) == 0, "The Clutch pedal is NOT pressed!" );

            // Now we want to stop the car...
            s = s & ~CarStatus.IsRunning;
            Assert.That( (s & CarStatus.IsRunning) == 0, "The Car is NO MORE running!" );
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
        }

        [Test]
        public void CarStatus_status_check()
        {
            CarStatus s = 0;
            Assert.That(s.HasStatus(CarStatus.IsRunning), Is.False, "not running");
            Assert.That(s.HasStatus(CarStatus.IsClutchPedal), Is.False, "cluthch pedal false");

            s = CarStatus.IsRunning;
            Assert.That(s.HasStatus(CarStatus.IsRunning), Is.True, "running");

            s = CarStatus.IsRunning | CarStatus.IsBrakePedal;
            Assert.That(s.HasStatus(CarStatus.IsBrakePedal), Is.True, "brake pedal true");

            s = CarStatus.IsRunning | CarStatus.IsClutchPedal | CarStatus.IsHandBrake;
            Assert.That(s.HasStatus(CarStatus.IsBrakePedal), Is.False, "brake pedal false");
            Assert.That(s.HasStatus(CarStatus.IsHandBrake), Is.True, "hand break true");
        }

        [Test]
        public void CarStatus_status_toggle()
        {
            var s = CarStatus.IsRunning;

            s = s.ToggleStatus(CarStatus.IsHandBrake);
            Assert.That(s.HasFlag(CarStatus.IsHandBrake), Is.True, "hand brake true");

            s = s.ToggleStatus(CarStatus.IsBrakePedal).ToggleStatus(CarStatus.IsHandBrake);
            Assert.That(s.HasFlag(CarStatus.IsHandBrake), Is.False);
            Assert.That(s.HasFlag(CarStatus.IsBrakePedal), Is.True);
        }
    }
}