using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public static class GameFileManager {

    public static GameFile GameFile;

    public static void Save()
    {
        Save(GameFile, GameFile.Name);
    }

  


    public static void Save<T>(T data,string name)
    {

        BinaryFormatter bf = GetBinaryFormatter();

        FileStream file = File.Create(Application.persistentDataPath + "/" + name + ".witchWorld");
        bf.Serialize(file, data);
        file.Close();
    }

    public static T Load<T>(string name)
    {
        BinaryFormatter bf = GetBinaryFormatter();

        FileStream file = File.OpenRead(Application.persistentDataPath + "/" + name + ".witchWorld");
        T data = (T)bf.Deserialize(file);
        file.Close();

        return data;
    }

    public static bool Exists(string name)
    {
        Debug.Log(Application.persistentDataPath);
        return File.Exists(Application.persistentDataPath + "/" + name + ".witchWorld");
    }

    public static BinaryFormatter GetBinaryFormatter()
    {
        BinaryFormatter bf = new BinaryFormatter();

        SurrogateSelector surrogateSelector = new SurrogateSelector();

        Vector3IntSerializationSurrogate vector3SS = new Vector3IntSerializationSurrogate();
        surrogateSelector.AddSurrogate(typeof(Vector3Int), new StreamingContext(StreamingContextStates.All), vector3SS);
        ColorSerializationSurrogate colour3SS = new ColorSerializationSurrogate();
        surrogateSelector.AddSurrogate(typeof(Color), new StreamingContext(StreamingContextStates.All), colour3SS);

        bf.SurrogateSelector = surrogateSelector;

        return bf;
    }
}
