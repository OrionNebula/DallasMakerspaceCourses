namespace Alzaitu.Introduction.Cars
{
    public class Tesla : Car
    {
        public override double MilesPerUnit => 305; //miles/kwh
        public override double MaxSpeed => 155; //mph
        public override double TankSize => 85; //kwh
        public override FuelType FuelType => FuelType.Electric;

        protected override double DegradeCondition(double distance, double speed) =>
            distance * (1 - speed / MaxSpeed) / 75000;
    }
}
