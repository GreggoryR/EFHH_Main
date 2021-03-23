using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystemSerialize
    
{
    public static void SaveGame(GameManager manager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.game";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameDataPlayerPrefs data = null; //come back to fi

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameDataPlayerPrefs LoadGame()
    {
        string path = Application.persistentDataPath + "/player.game";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameDataPlayerPrefs data = formatter.Deserialize(stream) as GameDataPlayerPrefs;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("");
            return null;
        }
    }
}
