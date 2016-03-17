using System;

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

    /// <summary>
    /// The differents gear of the car.
    /// </summary>
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
        /// <summary>
        /// Gets the current gear of the car.
        /// </summary>
        /// <param name="status">[this] Current car status.</param>
        /// <returns>The current CarGear of the car.</returns>
        public static CarGear GetGear(this CarStatus status)
        {
            return (CarGear)((Int32)status >> 5);
        }

        /// <summary>
        /// Sets the current gear of the car.
        /// </summary>
        /// <param name="status">[This] Current car status.</param>
        /// <param name="gear">Gear to set.</param>
        /// <returns>The car status with the gear set.</returns>
        public static CarStatus SetGear(this CarStatus status, CarGear gear)
        {
            return SetGear(status, (Int32)gear);
        }

        /// <summary>
        /// Sets the current gear of the car.
        /// </summary>
        /// <param name="status">[This] Current car status.</param>
        /// <param name="gear">
        /// Value of the gear to set :
        /// - No gear selected = 0
        /// - 1 to 5 : value of the gear to set
        /// - 6 : backward gear.
        /// </param>
        /// <returns>The car status with the gear set.</returns>
        public static CarStatus SetGear(this CarStatus status, Int32 gear)
        {
            if (gear < 0 || gear > 6) throw new ArgumentOutOfRangeException();
            return (status & ~CarStatus.GearMask) | (status | (CarStatus)(gear << 5));
        }

        /// <summary>
        /// Toggles the given status on the current car status.
        /// </summary>
        /// <param name="status">[This] Current car status.</param>
        /// <param name="statusToChange">Status to toggle. It can't be the gear status.</param>
        /// <returns>The car status with the status toggled.</returns>
        public static CarStatus ToggleStatus(this CarStatus status, CarStatus statusToChange)
        {
            if (statusToChange.Equals(CarStatus.GearMask)) throw new ArgumentException();
            return status ^ statusToChange;
        }

        /// <summary>
        /// Checks if the car status has the given status at 1.
        /// </summary>
        /// <param name="status">[This] Current car status.</param>
        /// <param name="s">Status to check.</param>
        /// <returns>True if the status is different of 0.</returns>
        public static Boolean HasStatus(this CarStatus status, CarStatus s)
        {
            return (status & s) != 0;
        }
    }
}