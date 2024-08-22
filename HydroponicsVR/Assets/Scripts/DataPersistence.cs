using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class DataPersistence : MonoBehaviour
{
    public static DataPersistence Instance;

    public int currentObjective;
    public int taskObjective;
    public Vector3 playerPos;

    [System.Serializable]
    class SaveData
    {
        public int currentObjective;
        public int taskObjective;
        public Vector3 playerPos;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        loadData();
    }

    public void saveData(Vector3 playerPos)
    {
        SaveData data = new SaveData();
        data.currentObjective = currentObjective;
        data.taskObjective = taskObjective;
        data.playerPos = playerPos;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void loadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            currentObjective = data.currentObjective;
            taskObjective = data.taskObjective;
            playerPos = data.playerPos;
        }
        else
        {
            playerPos = new Vector3(168, 4, 3);
        }
    }
}
