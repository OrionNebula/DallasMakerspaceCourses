namespace Alzaitu.Introduction.Cars
{
    public class Sedan : Car
    {
        public override double MilesPerUnit => 30; //mpg
        public override double MaxSpeed => 170; //mph
        public override double TankSize => 12; //gal
        public override FuelType FuelType => FuelType.Petrol;

        protected override double DegradeCondition(double distance, double speed) => distance * (1 - speed / MaxSpeed) / 50000; //max 50000 miles
    }
}
