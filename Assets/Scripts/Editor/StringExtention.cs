using System.Collections;
using System.Collections.Generic;

public class StringExtention
{

    public static string[] SplitWithString(string sourceString, string splitString)
    {

        List<string> arrayList = new List<string>();
        string s = string.Empty;
        while (sourceString.IndexOf(splitString) > -1)
        {
            s = sourceString.Substring(0, sourceString.IndexOf(splitString));
            sourceString = sourceString.Substring(sourceString.IndexOf(splitString) + splitString.Length);
            arrayList.Add(s);
        }
        arrayList.Add(sourceString);
        return arrayList.ToArray();
    }
}