using System;
namespace Ex03.GarageLogic
{

    public static class EnumExceptionClass
    {
        public static int EnumException(Type i_TypeOfEnum, string i_StrToCheck)
        {
            int i_NumToReturn = int.Parse(i_StrToCheck);
            if (Enum.GetName(i_TypeOfEnum, i_NumToReturn) == null)
            {
                throw new FormatException();
            }

            return i_NumToReturn;
        }
    }

}
