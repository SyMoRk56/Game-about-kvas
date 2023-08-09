using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class DataBase : MonoBehaviour
{
    static string Path = Application.persistentDataPath + "/inv.path";
    static BinaryFormatter binaryFormatter = new BinaryFormatter();

    public static void Save()
    {
        saveInventory();
    }

    private static void saveInventory()
    {
        
        FileStream stream = new FileStream(Path, FileMode.Create);
        
        binaryFormatter.Serialize(stream, KvasManager.instance.kvasList);
        
        stream.Close();
    }

    public static List<InventoryCell> LoadInv()
    {
        if(File.Exists(Path))
        {
            FileStream stream = new FileStream(Path,FileMode.Open);
            Debug.Log("C");
            stream.Flush();
            List<InventoryCell> items = (List<InventoryCell>)binaryFormatter.Deserialize(stream);
            Debug.Log("C");
            stream.Close();
            return items;

        }
        else
        {
            List<InventoryCell> startItems = new List<InventoryCell>();
            startItems.Add(new InventoryCell());
            startItems.Add(new InventoryCell());
            startItems.Add(new InventoryCell());

            return startItems;
        }
    }
}
