using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    private string savePath;

    private void Awake()
    {
        savePath = Application.persistentDataPath + "/savefile.json";
        Debug.Log("Save path: " + savePath);
        DontDestroyOnLoad(this.gameObject);
    }

    public void Save(SaveData data)
    {
        string json = JsonUtility.ToJson(data, true); // true = pretty format
        File.WriteAllText(savePath, json);
        Debug.Log("Saved!");
    }

    public SaveData Load()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            Debug.Log("Loaded!");
            return data;
        }
        else
        {
            Debug.LogWarning("No save file found!");
            return null;
        }
    }
}
