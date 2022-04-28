using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
    {
        public static Data Data;
        
        public static void Save()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/Data.fun";
            FileStream stream = new FileStream(path, FileMode.Create);
            
            formatter.Serialize(stream, Data);
            stream.Close();
        }

        public static void Load()
        {
            string path = Application.persistentDataPath + "/Data.fun";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);
                Data =  formatter.Deserialize(stream) as Data;
            }
            else
            {
                Debug.Log("Data not found" + path);
            }
        }
    }
