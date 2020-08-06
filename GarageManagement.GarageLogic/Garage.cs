using System;
using System.Collections.Generic;
namespace Ex03.GarageLogic
{
    public class Garage
    {

        // $G$ NTT-999 (-3) This kind of field should be readonly.
        private Dictionary<int, Customer> m_Shop;

        public Garage()
        {
            this.m_Shop = new Dictionary<int, Customer>();
        }

        public Dictionary<int, Customer> Shop
        {
            get
            {
                return this.m_Shop;
            }
        }

        public Customer CheckCustomerExist(string i_LicNum)
        {
            Customer i_CustomerToReturn = null;
            if (m_Shop.ContainsKey(i_LicNum.GetHashCode()))
            {
                i_CustomerToReturn = m_Shop[i_LicNum.GetHashCode()];
            }

            return i_CustomerToReturn;
        }

        public void AddCustomer(Customer i_CustomerToAdd)
        {
            i_CustomerToAdd.Status = eStatus.InRepair;
            this.m_Shop.Add(i_CustomerToAdd.CustomerVehicle.LicenseNumber.GetHashCode(), i_CustomerToAdd);
        }

        public List<string> ReturnAllCustomers()
        {
            List<string> i_ListToReturn = new List<string>();
            i_ListToReturn.AddRange(ReturnCustomerByStatus(eStatus.InRepair));
            i_ListToReturn.AddRange(ReturnCustomerByStatus(eStatus.Fixed));
            i_ListToReturn.AddRange(ReturnCustomerByStatus(eStatus.Paid));
            return i_ListToReturn;
        }

        public List<string> ReturnCustomerByStatus(eStatus i_Status)
        {
            List<string> i_ListToReturn = new List<string>();
            foreach (KeyValuePair<int, Customer> C in m_Shop)
            {
                if (C.Value.Status == i_Status)
                {
                    i_ListToReturn.Add(C.Value.CustomerVehicle.LicenseNumber);
                }

            }

            return i_ListToReturn;
        }

        public void ChangeStatus(string i_LicNum, eStatus i_Status)
        {
            if (CheckCustomerExist(i_LicNum) != null)
            {
                m_Shop[i_LicNum.GetHashCode()].Status = i_Status;
            }
        }

        public bool FillWheelsAirToMax(string i_LicNum)
        {
            bool v_FillingSucceeded = false;
            Customer i_CustVehicleToFillAir = CheckCustomerExist(i_LicNum);
            if (i_CustVehicleToFillAir != null)
            {
                List<Wheel> i_Wheels = i_CustVehicleToFillAir.CustomerVehicle.Wheels;
                foreach (Wheel w in i_Wheels)
                {
                    w.FillAirToMax();
                }

                v_FillingSucceeded = true;
            }

            return v_FillingSucceeded;
        }

        public void FillFuel(string i_LicNum, eFuelType i_TypeOfFuel, float i_AmountToFill)
        {
            Customer i_CustVehicle = this.m_Shop[i_LicNum.GetHashCode()];
            if (i_CustVehicle.CustomerVehicle.Engine is Fuel)
            {
                ((Fuel)i_CustVehicle.CustomerVehicle.Engine).FillFuel(i_TypeOfFuel, i_AmountToFill);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void ChargeBattrey(string i_LicNum, float i_AmountToCharge)
        {
            Customer i_CostVehicle = CheckCustomerExist(i_LicNum);
            if (i_CostVehicle.CustomerVehicle.Engine is Electric)
            {
                ((Electric)i_CostVehicle.CustomerVehicle.Engine).ChargeBattrey(i_AmountToCharge);
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}