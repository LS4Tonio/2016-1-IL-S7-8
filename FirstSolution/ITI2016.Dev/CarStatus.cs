using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ITI2016.Dev
{
    /// <summary>
    /// A Car can be in multiple states:
    /// - The engine is running or not.
    /// - There may be a speed engaged(typically 5 speeds)
    /// - The clutch pedal can be pressed or not.
    /// - The gas pedal can be pressed or not.
    /// - The brake pedal can be pressed or not.
    /// - The hand brake can be set or not.
    /// </summary>
    public enum CarStatus : byte
    {
        IsRunning = 1 << 0,
        IsClutchPedal = 1 << 1,
        IsGasPedal = 1 << 2,
        IsBrakePedal = 1 << 3,
        IsHandBrake = 1 << 4,
        GearMask = 7 << 5
    }
    
    public enum CarGear
    {
        None = 0,
        First = 1,
        Second = 2,
        Third = 3,
        Fourth = 4,
        Fifth = 5,
        Backward = 6
    }
    
    public static class CarStatusExtension
    {
        public static CarGear GetGear(this CarStatus status)
        {
            return (CarGear)((Int32)status >> 5);
        }

        public static CarStatus SetGear(this CarStatus status, CarGear gear)
        {
            return SetGear(status, (Int32)gear);
        }

        public static CarStatus SetGear(this CarStatus status, Int32 gear)
        {
            if (gear < 0 || gear > 6) throw new ArgumentOutOfRangeException();
            return (status & ~CarStatus.GearMask) | (status | (CarStatus)(gear << 5));
        }

        public static CarStatus ToggleStatus(this CarStatus status, CarStatus statusToChange)
        {
            return status ^ statusToChange;
        }

        public static Boolean HasStatus(this CarStatus status, CarStatus s)
        {
            return (status & s) != 0;
        }
    }
}