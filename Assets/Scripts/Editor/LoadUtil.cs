using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public static class LoadUtil
{
    public static T[]  LoadAsset<T>(string path, string pattern) where T : Object
    {
        string objPath = Application.dataPath + path;
        string[] directoryEntries;
        List<T> objList = new List<T>();
        try
        {
            directoryEntries = System.IO.Directory.GetFileSystemEntries(objPath);

            for (int i = 0; i < directoryEntries.Length; i++)
            {
                string p = directoryEntries[i];
                string[] tempPaths = StringExtention.SplitWithString(p, "/Assets/");
                if (tempPaths[1].EndsWith("." + pattern))
                {
                    T tempTex = AssetDatabase.LoadAssetAtPath("Assets/" + tempPaths[1], typeof(T)) as T;
                    if (tempTex != null)
                        objList.Add(tempTex);
                }

            }
        }
        catch (System.IO.DirectoryNotFoundException)
        {
            Debug.Log("The path encapsulated in the " + objPath + "Directory object does not exist.");
        }
        if (objList.Count > 0)
            return objList.ToArray();
        return null;
    }
}