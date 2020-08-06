using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

// $G$ DSN-999 (-5) It's not an object oriented programming to use only public methods

internal class UI
{
    public static void Start()
    {
        Garage i_Garage = new Garage();
        int i_NumOfFunc = 0;
        string i_StrNumOfFunc;
        while (i_NumOfFunc != 8)
        {
            try
            {
                i_StrNumOfFunc = Print.PrintArray(Messages.sr_MainMenu);
                i_NumOfFunc = int.Parse(i_StrNumOfFunc);
                if (i_NumOfFunc > 8 || i_NumOfFunc < 1)
                {
                    Print.PrintMessage(Messages.sr_InvalidInput);
                }
                else
                {
                    menuFunction(i_NumOfFunc, i_Garage);
                }
            }
            catch (FormatException)
            {
                Print.PrintMessageAndGetString(Messages.sr_InvalidInput);
            }
        }
    }

    
    private static void menuFunction(int i_NumOfFunc, Garage i_Garage)
    {
        switch ((eFunction)i_NumOfFunc)
        {
            case eFunction.EnterCustomer:
                enterCustomer(i_Garage);
                break;
            case eFunction.ShowCustomerInGarage:
                showCustomerInGarage(i_Garage);
                break;
            case eFunction.ChangeStatus:
                changeStatus(i_Garage);
                break;
            case eFunction.FillAirToMax:
                fillAirToMax(i_Garage);
                break;
            case eFunction.FillFuel:
                fillFuel(i_Garage);
                break;
            case eFunction.ChargeBattery:
                chargeBattery(i_Garage);
                break;
            case eFunction.DisplayCustomerDetails:
                displayCustumerDetails(i_Garage);
                break;
            case eFunction.Quit:
                break;
        }
    }

    private static void displayCustumerDetails(Garage i_Garage)
    {
        string i_LicNum = Print.PrintMessageAndGetString(Messages.sr_EnterLicNum);
        Customer i_CustToShow = i_Garage.CheckCustomerExist(i_LicNum);
        if (i_CustToShow != null)
        {
            Print.PrintMessage(i_CustToShow.ToString());
        }
        else
        {
            Print.PrintMessage(Messages.sr_CustDoesNotExist);
        }
    }

    private static void chargeBattery(Garage i_Garage)
    {
        try
        {
            string i_LicNum = Print.PrintMessageAndGetString(Messages.sr_EnterLicNum);
            if (i_Garage.CheckCustomerExist(i_LicNum) == null)
            {
                Print.PrintMessage(Messages.sr_VehicleDoesNotExist);
                return;
            }

            string i_StrMinutesToCharge = Print.PrintMessageAndGetString(Messages.sr_EnterAmountToCharge);
            float i_HoursToCharge = float.Parse(i_StrMinutesToCharge);
            i_HoursToCharge /= 60;
            i_Garage.ChargeBattrey(i_LicNum, i_HoursToCharge);
        }
        catch(ArgumentException)
        {
            Print.PrintMessage(Messages.sr_ErrorEngineType);
        }
        catch(FormatException)
        {
            Print.PrintMessage(Messages.sr_InvalidInput);
        }
        catch(ValueOutOfRangeException ex)
        {
            Print.PrintMessage(string.Format(Messages.sr_RangeError, Messages.sr_Battery, ex.MinValue * 60, ex.MaxValue * 60, Messages.sr_Minutes));
        }
    }
    
    private static void fillFuel(Garage i_Garage)
    {
        try
        {
            string i_LicNum = Print.PrintMessageAndGetString(Messages.sr_EnterLicNum);
            if (i_Garage.CheckCustomerExist(i_LicNum) == null)
            {
                Print.PrintMessage(Messages.sr_VehicleDoesNotExist);
                return;
            }

            string i_FuelType = Print.PrintArray(Messages.sr_TypeFuelArr);
            eFuelType i_TypeOfFuel = (eFuelType)EnumExceptionClass.EnumException(typeof(eFuelType), i_FuelType);
            string i_StrAmountToFill = Print.PrintMessageAndGetString(Messages.sr_EnterAmountToFill);
            float i_AmountToFill = float.Parse(i_StrAmountToFill);
            i_Garage.FillFuel(i_LicNum, i_TypeOfFuel, i_AmountToFill);
        }
        catch (ArgumentException)
        {
            Print.PrintMessage(Messages.sr_ErrorEngineType);
        }
        catch (FormatException)
        {
            Print.PrintMessage(Messages.sr_InvalidInput);
        }
        catch (ValueOutOfRangeException ex)
        {

            Print.PrintMessage(string.Format(Messages.sr_RangeError, Messages.sr_Fuel, ex.MinValue, ex.MaxValue, Messages.sr_Liter));
        }
    }

    private static void fillAirToMax(Garage i_Garage)
    {
        string i_LicNum = Print.PrintMessageAndGetString(Messages.sr_EnterLicNum);
        if(!i_Garage.FillWheelsAirToMax(i_LicNum))
        {
            Print.PrintMessage(Messages.sr_VehicleDoesNotExist);
        }
    }

    private static void changeStatus(Garage i_Garage)
    {
        try
        {
            string i_LicNum = Print.PrintMessageAndGetString(Messages.sr_EnterLicNum);
            if (i_Garage.CheckCustomerExist(i_LicNum) == null)
            {
                Print.PrintMessage(Messages.sr_VehicleDoesNotExist);
                return;
            }

            string i_StrNewStatus = Print.PrintArray(Messages.sr_StatusArr);
            eStatus i_NewStatus = (eStatus)EnumExceptionClass.EnumException(typeof(eStatus), i_StrNewStatus);
            i_Garage.ChangeStatus(i_LicNum, i_NewStatus);
        }
        catch(FormatException)
        {
            Print.PrintMessage(Messages.sr_InvalidInput);
        }
    }

    private static void showCustomerInGarage(Garage i_Garage)
    {
        bool v_IsValid = false;
        List<string> i_ListToPrint = null;
        while(!v_IsValid)
        {
            string i_FilterByStatus = Print.PrintMessageAndGetString(Messages.sr_FilterByStatus);
            if(i_FilterByStatus == "N")
            {
                i_ListToPrint = i_Garage.ReturnAllCustomers();
                v_IsValid = true;
            }
            else if(i_FilterByStatus == "Y")
            {
                bool v_IsValidStatus = false;
                while(!v_IsValidStatus)
                {
                    try
                    {
                        string i_StrStatusToShow = Print.PrintArray(Messages.sr_StatusArr);
                        eStatus i_StatusToShow = (eStatus)EnumExceptionClass.EnumException(typeof(eStatus), i_StrStatusToShow);
                        i_ListToPrint = i_Garage.ReturnCustomerByStatus(i_StatusToShow);
                        v_IsValidStatus = true;
                    }
                    catch(FormatException)
                    {
                        Print.PrintMessage(Messages.sr_InvalidInput);
                    }
                }

                v_IsValid = true;
            }
            else
            {
                Print.PrintMessage(Messages.sr_InvalidInput);
            }
        }

        PrintList(i_ListToPrint);
    }

    public static void PrintList<T>(List<T> i_ListToPrint)
    {
        if(i_ListToPrint == null)
        {
            Print.PrintMessage(Messages.sr_EmptyList);
        }
        else
        {
            foreach(T i in i_ListToPrint)
            {
                Print.PrintMessage(i);
            }
        }
    }

    private static void enterCustomer(Garage i_Garage)
    {
        string i_LicNum = Print.PrintMessageAndGetString(Messages.sr_EnterLicNum);
        Customer i_CustomerVehicle = i_Garage.CheckCustomerExist(i_LicNum);
        if(i_CustomerVehicle != null)
        {
            Print.PrintMessage(Messages.sr_CustomerDoesExist);
            i_CustomerVehicle.Status = eStatus.InRepair;
        }
        else
        {
            Customer i_NewCust = createNewCustomer(i_LicNum);
            i_Garage.AddCustomer(i_NewCust);
        }
    }

    private static Customer createNewCustomer(string i_NewLicNum)
    {
        string i_OwnerName = Print.PrintMessageAndGetString(Messages.sr_OwnerName);
        string i_OwnerPhone = Print.PrintMessageAndGetString(Messages.sr_OwnerPhone);
        string i_Model = Print.PrintMessageAndGetString(Messages.sr_EnterModel);
        Vehicle i_Veicle = createVehicle(i_NewLicNum, i_Model);
        return new Customer(i_OwnerName, i_OwnerPhone, i_Veicle);
    }

    private static Vehicle createVehicle(string i_LicNum, string i_Model)
    {
        Vehicle i_Vehicle = null;
        while(i_Vehicle == null)
        {
            try
            {
                string i_StrVehicleType = Print.PrintArray(Messages.sr_TypesOfVehiclesArr);
                eVehicleType i_TypeOfVehicle = (eVehicleType)EnumExceptionClass.EnumException(typeof(eVehicleType), i_StrVehicleType);
                string i_Manufacturer = Print.PrintMessageAndGetString(Messages.sr_EnterWheelManufacturer);
                i_Vehicle = VehicleFactory.CreateVehicle(i_TypeOfVehicle, i_Model, i_LicNum, 0, i_Manufacturer);
            }
            catch(FormatException)
            {
                Print.PrintMessage(Messages.sr_InvalidInput);
            }
        }

        wheelDetails(i_Vehicle);
        vehicleCurrentPowerSourceState(i_Vehicle);
        additionalDetailsByVehicleType(i_Vehicle);
        return i_Vehicle;
    }


    private static void additionalDetailsByVehicleType(Vehicle i_Vehicle)
    {
        if(i_Vehicle is Car)
        {
            carAdditionalDetails(i_Vehicle as Car);
        }
        else if(i_Vehicle is Motorcycle)
        {
            motorcycleAdditionalDetails(i_Vehicle as Motorcycle);
        }
        else
        {
            truckAdditionalDetails(i_Vehicle as Truck);
        }
    }

    private static void vehicleCurrentPowerSourceState(Vehicle i_Vehicle)
    {
        bool v_IsAmoutCurrect = false;
        while(!v_IsAmoutCurrect)
        {
            try
            {
                if(i_Vehicle.Engine is Fuel)
                {
                    string i_CurrentAmountOfFuel = Print.PrintMessageAndGetString(Messages.sr_EnterCurAmountOfFuel);
                    (i_Vehicle.Engine as Fuel).CurAmountOfFuel = float.Parse(i_CurrentAmountOfFuel);
                }
                else
                {
                    string i_CurrentAmountOfBattery = Print.PrintMessageAndGetString(Messages.sr_EnterCurTimeBatteryUse);
                    (i_Vehicle.Engine as Electric).CurTimeOfBatteryUse = float.Parse(i_CurrentAmountOfBattery);
                }

                v_IsAmoutCurrect = true;
            }

            catch(FormatException)
            {
                Print.PrintMessage(Messages.sr_InvalidInput);
            }
            catch(ValueOutOfRangeException ex)
            {
                if(i_Vehicle.Engine is Fuel)
                {
                    Print.PrintMessage(string.Format(Messages.sr_RangeError, Messages.sr_CurFuel, ex.MinValue, ex.MaxValue, Messages.sr_Liter));
                }
                else
                {
                    Print.PrintMessage(string.Format(Messages.sr_RangeError, Messages.sr_CurBattey, ex.MinValue, ex.MaxValue, Messages.sr_Hours));
                }
            }
        }
    }

    private static void carAdditionalDetails(Car i_Car)
    {
        bool v_IsValid = false;
        while(!v_IsValid)
        {
            try
            {
                string i_StrDoorsNumber = Print.PrintMessageAndGetString(Messages.sr_EnterNumberOfDoors);
                eNumOfDoors i_NumOfDoors = (eNumOfDoors)EnumExceptionClass.EnumException(typeof(eNumOfDoors), i_StrDoorsNumber);
                string i_StrCarColor = Print.PrintArray(Messages.sr_ColorArr);
                eColor i_CarColor = (eColor)EnumExceptionClass.EnumException(typeof(eColor), i_StrCarColor);
                i_Car.CarColor = i_CarColor;
                i_Car.DoorsNumber = i_NumOfDoors;
                v_IsValid = true;
            }

            catch(FormatException)
            {
                Print.PrintMessage(Messages.sr_InvalidInput);
            }
        }
    }

    private static void motorcycleAdditionalDetails(Motorcycle i_Motorcycle)
    {
        bool v_IsValid = false;
        while(!v_IsValid)
        {
            try
            {
                string i_StrEngineCapacity = Print.PrintMessageAndGetString(Messages.sr_EnterEngineCapacity);
                int i_EngineCapacity = int.Parse(i_StrEngineCapacity);
                i_Motorcycle.EngineCapacity = i_EngineCapacity;
                string i_StrTypeOfLicense = Print.PrintArray(Messages.sr_LicTypeArr);
                eLicenseType i_TypeOfLicense = (eLicenseType)EnumExceptionClass.EnumException(typeof(eLicenseType), i_StrTypeOfLicense);
                i_Motorcycle.TypeOfLicense = i_TypeOfLicense;
                v_IsValid = true;
            }
            catch (ValueOutOfRangeException ex)
            {
                Print.PrintMessage(string.Format(Messages.sr_SizeLowerError, Messages.sr_EngineCapacity, ex.MinValue));
            }
            catch (FormatException)
            {
                Print.PrintMessage(Messages.sr_InvalidInput);
            }
        }
    }

    private static void truckAdditionalDetails(Truck i_Truck)
    {
        bool v_IsValid = false;
        while(!v_IsValid)
        {
            try
            {
                string i_StrDeliversDangerousChemicals = Print.PrintMessageAndGetString(Messages.sr_EnterIfDeliversDangerousChemicals);
                bool i_DeliversDangerousChemicals;
                if(i_StrDeliversDangerousChemicals == "Y")
                {
                    i_DeliversDangerousChemicals = true;
                }
                else if(i_StrDeliversDangerousChemicals == "N")
                {
                    i_DeliversDangerousChemicals = false;
                }
                else
                {
                    Print.PrintMessage(Messages.sr_InvalidInput);
                    continue;
                }

                string i_StrTrunkSize = Print.PrintMessageAndGetString(Messages.sr_EnterTrunkSize);
                float i_TrunkSize = float.Parse(i_StrTrunkSize);
                i_Truck.DeliversDangerousChemicals = i_DeliversDangerousChemicals;
                i_Truck.TrunkSize = i_TrunkSize;
                v_IsValid = true;
            }
            catch(ValueOutOfRangeException ex)
            {
                Print.PrintMessage(string.Format(Messages.sr_SizeLowerError, Messages.sr_Trunk, ex.MinValue));
            }
            catch(FormatException)
            {
                Print.PrintMessage(Messages.sr_InvalidInput);
            }
        }
    }

    private static void wheelDetails(Vehicle i_Vehicle)
    {
        bool v_PressureIsValid = false;
        while(!v_PressureIsValid)
        {
            try
            {
                string i_StrAirPressure = Print.PrintMessageAndGetString(Messages.sr_EnterWheelCurAirPressure);
                float i_CurAirPressure = float.Parse(i_StrAirPressure);
                i_Vehicle.UpdateAirPressure(i_CurAirPressure);
                v_PressureIsValid = true;
            }
            catch(FormatException)
            {
                Print.PrintMessage(Messages.sr_InvalidInput);
            }
            catch(ValueOutOfRangeException ex)
            {
                Print.PrintMessage(string.Format(Messages.sr_RangeError, Messages.sr_CurAir, ex.MinValue, ex.MaxValue, Messages.sr_Psi));
            }
        }
    }

}