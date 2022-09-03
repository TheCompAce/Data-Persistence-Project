using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public static MenuManager Instance;

    public int HighScore;
    public string HighName;
    public string lastName;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadDataInfo();
    }

    public void SaveDataInfo()
    {
        SaveData data = new SaveData();
        data.HighScore = HighScore;
        data.HighName = HighName;
        data.lastName = lastName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadDataInfo()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScore = data.HighScore;
            HighName = data.HighName;
            lastName = data.lastName;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public int HighScore;
        public string HighName;
        public string lastName;
    }



}
