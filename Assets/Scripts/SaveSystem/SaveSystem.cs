using System.IO;
using UnityEngine;

public class SaveSystem
{
    public Data Data;
    private static SaveSystem _instance;

    private SaveSystem()
    {
        LoadData();
    }

    public static SaveSystem GetInstance()
    {
        if (_instance == null) _instance = new SaveSystem();
        return _instance;
    }

    public void SaveData()
    {
        string path = Application.persistentDataPath + "/Data.json";
        File.WriteAllText(path, JsonUtility.ToJson(Data));
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/Data.json";
        if (File.Exists(path))
        {
            Data = JsonUtility.FromJson<Data>(
                File.ReadAllText(path));
        }
        else
        {
            Data = new Data();
        }
    }
}