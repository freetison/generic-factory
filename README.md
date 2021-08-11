# generic-factory
Generic factory implementation

GenericEnumFactory<T>   
Use:
    public enum VehicleType { Car, Truck, Motorcycle };

    public interface IVehicle
    {
        void SpeedUp();
    }

    public class Car: IVehicle
    {
        public void SpeedUp()
        {
            Console.WriteLine($"I`m a {this.GetType().Name} at full speed");
        }
    }

    public class Motorcycle : IVehicle
    {
        public void SpeedUp()
        {
            Console.WriteLine($"I`m a {this.GetType().Name} at full speed");
        }
    }

    public class Truck : IVehicle
    {
        public void SpeedUp()
        {
            Console.WriteLine($"I`m a {this.GetType().Name} at full speed");
        }
    }

    GenericEnumFactory<IVehicle> factory = new GenericEnumFactory<IVehicle>();
    factory.Register(VehicleType.Car, () => new Car());
    factory.Register(VehicleType.Truck, () => new Truck());
    factory.Register(VehicleType.Motorcycle, () => new Motorcycle());

    var vehicle = factory.Get(VehicleType.Car);
    vehicle.SpeedUp();
    Console.ReadLine();


--------------------------------------------------------------------------------------
 GenericFactory<T, TK>
 Use:

    var Factory = new GenericFactory<int, IVehicle>();
    Factory.Register(1, () => new Car());
    Factory.Register(2, () => new Truck());
    Factory.Register(3, () => new Motorcycle());

    var vehicle = gFactory.Get(2);
    vehicle.SpeedUp();

    var Factory = new GenericFactory<string, IVehicle>();
    Factory.Register("car", () => new Car());
    Factory.Register("truck", () => new Truck());
    Factory.Register("motorcycle", () => new Motorcycle());

    var vehicle = Factory.Get("motorcycle");
    vehicle.SpeedUp();

