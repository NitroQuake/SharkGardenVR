using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject guide;
    public GameObject objectives;

    public void loadGameScene()
    {
        DataPersistence.Instance.currentObjective = 0;
        DataPersistence.Instance.taskObjective = 0;
        DataPersistence.Instance.playerPos = new Vector3(168, 4, 3);
        DataPersistence.Instance.saveData(DataPersistence.Instance.playerPos);
        SceneManager.LoadScene(1);
    }

    public void loadObjectiveTwo()
    {
        DataPersistence.Instance.currentObjective = 1;
        DataPersistence.Instance.taskObjective = 3;
        DataPersistence.Instance.playerPos = new Vector3(168, 4, 3);
        DataPersistence.Instance.saveData(DataPersistence.Instance.playerPos);
        SceneManager.LoadScene(1);
    }

    public void loadObjectiveThree()
    {
        DataPersistence.Instance.currentObjective = 2;
        DataPersistence.Instance.taskObjective = 13;
        DataPersistence.Instance.playerPos = new Vector3(168, 4, 3);
        DataPersistence.Instance.saveData(DataPersistence.Instance.playerPos);
        SceneManager.LoadScene(1);
    }

    public void loadObjectiveFour()
    {
        DataPersistence.Instance.currentObjective = 3;
        DataPersistence.Instance.taskObjective = 18;
        DataPersistence.Instance.playerPos = new Vector3(168, 4, 3);
        DataPersistence.Instance.saveData(DataPersistence.Instance.playerPos);
        SceneManager.LoadScene(1);
    }

    public void loadObjectiveFive()
    {
        DataPersistence.Instance.currentObjective = 4;
        DataPersistence.Instance.taskObjective = 24;
        DataPersistence.Instance.playerPos = new Vector3(168, 4, 3);
        DataPersistence.Instance.saveData(DataPersistence.Instance.playerPos);
        SceneManager.LoadScene(1);
    }

    public void openObjectives()
    {
        objectives.SetActive(true);
    }

    public void closeObjectives()
    {
        objectives.SetActive(false);
    }

    public void openGuide()
    {
        guide.SetActive(true);
    }

    public void closeGuide()
    {
        guide.SetActive(false);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
