using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem
{
    public Data Data;
    
    private static SaveSystem _instance;

    private SaveSystem()
    {
        Load();
    }

    public static SaveSystem GetInstance()
    {
        if (_instance == null)
            _instance = new SaveSystem();
        return _instance;
    }

    
    public void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Data.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, Data);
        stream.Close();
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/Data.fun";
        Debug.Log(path);
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            Data = formatter.Deserialize(stream) as Data;
        }
        else
        {
            Debug.Log("Data not found" + path);
        }
    }
}