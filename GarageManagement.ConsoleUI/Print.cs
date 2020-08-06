using System;
using System.Collections.Generic;
using System.Text;

internal static class Print
{
    public static string PrintMessageAndGetString(string i_MessageToPrint)
    {
        Console.WriteLine(i_MessageToPrint);
        return Console.ReadLine();
    }

    public static void PrintMessage<T>(T i_Message)
    {
        Console.WriteLine(i_Message);
    }

    public static string PrintArray(string[] i_Messages)
    {
        foreach(string str in i_Messages)
        {
            Console.WriteLine(str);
        }

        return Console.ReadLine();
    }
}
