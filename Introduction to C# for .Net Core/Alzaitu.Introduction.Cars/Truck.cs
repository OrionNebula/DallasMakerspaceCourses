namespace Alzaitu.Introduction.Cars
{
    public class Truck : Car
    {
        public override double MilesPerUnit => 23; //mpg
        public override double MaxSpeed => 105; //mph
        public override double TankSize => 25; //gal
        public override FuelType FuelType => FuelType.Diesel;

        protected override double DegradeCondition(double distance, double speed) =>
            distance * (1 - speed / MaxSpeed) / 25000;
    }
}
