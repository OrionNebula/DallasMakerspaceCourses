using System;

namespace Alzaitu.Introduction.Cars
{
    public abstract class Car
    {
        public double FuelLeft { get; private set; }

        public double Condition { get; private set; } = 1;

        public abstract double MilesPerUnit { get; }

        public abstract double MaxSpeed { get; }

        public abstract double TankSize { get; }

        public abstract FuelType FuelType { get; }

        /// <summary>
        /// Drives a certain distace.
        /// </summary>
        /// <param name="distance">The distance to drive.</param>
        /// <param name="speed">The speed to drive at.</param>
        /// <returns>The time it took to drive that distance.</returns>
        public TimeSpan Drive(double distance, double speed)
        {
            if(speed > MaxSpeed)
                throw new ArgumentException("Car cannot go this fast.", nameof(speed));

            var gasUse = distance / MilesPerUnit;
            if(gasUse > FuelLeft)
                throw new ArgumentOutOfRangeException("Car cannot go this far.", nameof(distance));

            FuelLeft -= gasUse;

            Condition -= DegradeCondition(distance, speed);

            return TimeSpan.FromHours(distance / speed);
        }

        /// <summary>
        /// Add more fuel to this car.
        /// </summary>
        /// <returns>The ammount of fuel added.</returns>
        public double Refuel()
        {
            var delta = TankSize - FuelLeft;

            FuelLeft = TankSize;

            return delta;
        }

        /// <summary>
        /// The ammount of damage the car takes for a given distance and speed.
        /// </summary>
        /// <param name="distance">The distance the car has to drive.</param>
        /// <param name="speed">The speed the car drives at.</param>
        /// <returns>The percentage points removed from this car's condition.</returns>
        protected abstract double DegradeCondition(double distance, double speed);
    }
}
