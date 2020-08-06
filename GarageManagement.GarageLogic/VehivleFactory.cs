namespace Ex03.GarageLogic
{
    public static class VehicleFactory
    {
        private const float k_CarFuelTankSize = 60f;
        private const float k_MotorcycleFuelTankSize = 7f;
        private const float k_TruckFuelTankSize = 120f;
        private const float k_CarBatteryCapacity = 2.1f;
        private const float k_MotorcycleBatteryCapacity = 1.2f;

        public static Vehicle CreateVehicle(eVehicleType i_TypeToCreate, string i_Model, string i_LicNum, float i_CurAirPressure, string i_Manufacturer)
        {
            Vehicle i_VehicleToReturn = null;
            switch (i_TypeToCreate)
            {
                case eVehicleType.FuelMotorcycle:
                    {
                        i_VehicleToReturn = new Motorcycle(i_Model, i_LicNum, i_Manufacturer, i_CurAirPressure);
                        i_VehicleToReturn.Engine = new Fuel(k_MotorcycleFuelTankSize, eFuelType.Octan95);
                        break;
                    }

                case eVehicleType.ElectricMotorcycle:
                    {
                        i_VehicleToReturn = new Motorcycle(i_Model, i_LicNum, i_Manufacturer, i_CurAirPressure);
                        i_VehicleToReturn.Engine = new Electric(k_MotorcycleBatteryCapacity);
                        break;
                    }

                case eVehicleType.FuelCar:
                    {
                        i_VehicleToReturn = new Car(i_Model, i_LicNum, i_Manufacturer, i_CurAirPressure);
                        i_VehicleToReturn.Engine = new Fuel(k_CarFuelTankSize, eFuelType.Octan96);
                        break;
                    }

                case eVehicleType.ElectricCar:
                    {
                        i_VehicleToReturn = new Car(i_Model, i_LicNum, i_Manufacturer, i_CurAirPressure);
                        i_VehicleToReturn.Engine = new Electric(k_CarBatteryCapacity);
                        break;
                    }

                case eVehicleType.Truck:
                    {
                        i_VehicleToReturn = new Truck(i_Model, i_LicNum, i_Manufacturer, i_CurAirPressure);
                        i_VehicleToReturn.Engine = new Fuel(k_TruckFuelTankSize, eFuelType.Soler);
                        break;
                    }
            }

            return i_VehicleToReturn;
        }
    }
}