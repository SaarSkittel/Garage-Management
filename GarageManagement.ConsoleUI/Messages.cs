internal static class Messages
{
    // MainMenu
    public static readonly string sr_EnterVehicle = "1. Add a vehicle to the garage.";
    public static readonly string sr_ShowLicNum = "2. Show all license number in the garage.";
    public static readonly string sr_ChangeStatus = "3. Change status of an existing vehicle.";
    public static readonly string sr_FillAir = "4. Fill vehicle wheel to maximum.";
    public static readonly string sr_FillFuel = "5. Fill vehicle gas tank with fuel.";
    public static readonly string sr_ChargeBattery = "6. Charge elctric vehicle battery.";
    public static readonly string sr_ShowFullDetails = "7. Show vehicle full details.";
    public static readonly string sr_Exit = "8. Exit.";
    public static readonly string[] sr_MainMenu = { sr_EnterVehicle, sr_ShowLicNum, sr_ChangeStatus, sr_FillAir, sr_FillFuel, sr_ChargeBattery, sr_ShowFullDetails, sr_Exit};
    public static readonly string sr_EnterFunc = "Please enter function number:";
    public static readonly string sr_EnterLicNum = "Enter License Number:";

    // Create Customer
    public static readonly string sr_OwnerName = "Enter owner name:";
    public static readonly string sr_OwnerPhone = "Enter owner phone:";
    public static readonly string sr_EnterModel = "Enter Model:";
    public static readonly string sr_EnterTypeVehicle = "Enter type vehicle number:";
    public static readonly string sr_FuelCar = "1. Fuel car.";
    public static readonly string sr_ElectricCar = "2. Electric car.";
    public static readonly string sr_FuelMotorcycle = "3. Fuel motorcycle.";
    public static readonly string sr_ElectricMotorcycle = "4. Electric motorcycle.";
    public static readonly string sr_Truck = "5. Truck";
    public static readonly string[] sr_TypesOfVehiclesArr = {sr_FuelCar, sr_ElectricCar, sr_FuelMotorcycle, sr_ElectricMotorcycle,sr_Truck};

    //Car
    public static readonly string sr_EnterNumberOfDoors = "Enter number of doors (2, 3, 4, 5):";
    public static readonly string sr_EnterTypeEngine = "Enter vehicle engine";
    public static readonly string[] sr_TypeEngineArr = { sr_EnterTypeEngine, "1. Fuel", "2. Electric" };
    public static readonly string sr_EnterCarColor = "Enter car color :";
    public static readonly string sr_Red = "1. Red";
    public static readonly string sr_White = "2. White";
    public static readonly string sr_Black = "3. Black";
    public static readonly string sr_Silver = "4. Silver";
    public static readonly string[] sr_ColorArr = { sr_EnterCarColor, sr_Red, sr_White, sr_Black, sr_Silver };

    //Motorcycle
    public static readonly string sr_EnterEngineCapacity = "Enter engine capacity:";
    public static readonly string sr_EnterTypeLicense = "Enter type license:";
    public static readonly string sr_A = "1. A";
    public static readonly string sr_A1 = "2. A1";
    public static readonly string sr_AA = "3. AA";
    public static readonly string sr_B = "4. B";
    public static readonly string[] sr_LicTypeArr = { sr_EnterTypeLicense, sr_A, sr_A1, sr_AA, sr_B };
    public static readonly string sr_EngineCapacity = "engine capacity";

    //Truck
    public static readonly string sr_EnterTrunkSize = "Enter trunk size:";
    public static readonly string sr_EnterIfDeliversDangerousChemicals = "Enter if truck delivers dangerous chemicals (Y/N):";
    public static readonly string sr_Trunk = "trunk";
    //Wheels
    public static readonly string sr_EnterWheelCurAirPressure = "Enter current air pressure:";
    public static readonly string sr_EnterWheelManufacturer = "Enter wheels manufacturer:";
    public static readonly string sr_CurAir = "current air pressure";
    public static readonly string sr_Psi = "psi";

    //Fuel
    public static readonly string sr_EnterTypeFuel = "Enter type of fuel:";
    public static readonly string sr_Octan95 = "1. Octan95.";
    public static readonly string sr_Octan96 = "2. Octan96.";
    public static readonly string sr_Octan98 = "3. Octan98.";
    public static readonly string sr_Soler = "4. Soler.";
    public static readonly string[] sr_TypeFuelArr = { sr_EnterTypeFuel, sr_Octan95, sr_Octan96, sr_Octan98, sr_Soler };
    public static readonly string sr_EnterCurAmountOfFuel = "Enter current amount of fuel:";
    public static readonly string sr_EnterAmountToFill = "Enter amount of fuel to fill:";
    public static readonly string sr_Liter = "liter";
    public static readonly string sr_Fuel = "fuel";
    public static readonly string sr_CurFuel = "current amount of fuel";

    //Electric
    public static readonly string sr_EnterCurTimeBatteryUse = "Enter how much hours of use are left:";
    public static readonly string sr_CustomerDoesExist = "The customer exist in the system";
    public static readonly string sr_EnterAmountToCharge = "Enter amount of minutes to charge:";
    public static readonly string sr_Minutes = "minutes";
    public static readonly string sr_Battery = "battery";
    public static readonly string sr_CurBattey = "current battery time";
    public static readonly string sr_Hours = "hours";

    //Status
    public static readonly string sr_FilterByStatus = "Would you like to filter by status (Y/N)?";
    public static readonly string sr_EnterStatus = "Enter status:";
    public static readonly string sr_InRepair = "1. In Repair.";
    public static readonly string sr_Fixed = "2. Fixed.";
    public static readonly string sr_Paid = "3. Paid";
    public static readonly string[] sr_StatusArr = { sr_EnterStatus, sr_InRepair, sr_Fixed, sr_Paid };

    //Errors
    public static readonly string sr_InvalidInput = "Invalid input.";
    public static readonly string sr_VehicleDoesNotExist = "The vehicle does not exist in the system";
    public static readonly string sr_EmptyList = "There are no items to display";
    public static readonly string sr_CustDoesNotExist = "The customer does not exist in the system";
    public static readonly string sr_RangeError = "The {0} must be between {1} to {2} {3}";
    public static readonly string sr_ErrorEngineType = "Error type of engine.";
    public static readonly string sr_SizeLowerError = "The size of the {0} has to be bigger then {1}.";
}