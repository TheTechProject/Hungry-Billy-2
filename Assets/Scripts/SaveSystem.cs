using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    /// <summary>
    /// Saves the ScoreData from ScoreManager to a binary save
    /// file at the persistantDataPath.
    /// </summary>
    /// <param name="score"></param>
    public static void SaveHighScore (ScoreManager score)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/score.sav";
        FileStream stream = new FileStream(path, FileMode.Create);

        ScoreData data = new ScoreData(score);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    /// <summary>
    /// Checks the persistantDataPath for a binary save file containing
    /// the ScoreData.
    /// </summary>
    /// <returns></returns>
    public static ScoreData LoadHighScore()
    {
        string path = Application.persistentDataPath + "/score.sav";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ScoreData data = formatter.Deserialize(stream) as ScoreData;
            stream.Close();

            return data;
        }
        else
        {
            // If the save file isn't found then the default data will be loaded.
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
