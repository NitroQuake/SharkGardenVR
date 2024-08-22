using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject taskBook;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public Image image;
    public string[] titles;
    public string[] descriptions;

    public InteractableParent[] selectedInteractable;

    public Light sun;
    public Material daySkybox;
    public Material nightSkybox;
    private bool isDay;
    public GameObject light;

    public GameObject beacon;
    public GameObject player;
    public AudioSource audioSrc;

    private void Start()
    {
        initalizeBookText();
        title.text = titles[DataPersistence.Instance.currentObjective];
        description.text = descriptions[DataPersistence.Instance.currentObjective];
        isDay = true;

        beacon = Instantiate(Resources.Load<GameObject>("Prefabs/Beacon"));
        beacon.transform.position = new Vector3(selectedInteractable[DataPersistence.Instance.taskObjective].transform.position.x, beacon.transform.localScale.y - 1, selectedInteractable[DataPersistence.Instance.taskObjective].transform.position.z);
        beacon.SetActive(true);

        for(int i = 0; i < DataPersistence.Instance.taskObjective; i++)
        {
            selectedInteractable[i].setCompletedState();
        }

        DataPersistence.Instance.loadData();
        player.transform.position = DataPersistence.Instance.playerPos;
    }

    public void openTaskBook()
    {
        taskBook.SetActive(true);
    }

    public void closeTaskBook()
    {
        image.enabled = false;
        taskBook.SetActive(false);
    }

    public void turnOffBeacon()
    {
        beacon.SetActive(false);
    }

    public void setNextBeacon()
    {
        DataPersistence.Instance.taskObjective += 1;
        beacon.transform.position = new Vector3(selectedInteractable[DataPersistence.Instance.taskObjective].transform.position.x, beacon.transform.localScale.y - 1, selectedInteractable[DataPersistence.Instance.taskObjective].transform.position.z);
        beacon.SetActive(true);
        DataPersistence.Instance.saveData(getPlayerPosition());
    }

    public bool isSelectedInteractable(InteractableParent interactable)
    {
        return selectedInteractable[DataPersistence.Instance.taskObjective] == interactable;
    }

    public void incrementNextObjective()
    {
        DataPersistence.Instance.currentObjective += 1;
        title.text = titles[DataPersistence.Instance.currentObjective];
        description.text = descriptions[DataPersistence.Instance.currentObjective];
        DataPersistence.Instance.saveData(getPlayerPosition());
    }

    public void updateBook()
    {
        image.enabled = false;
        title.text = titles[DataPersistence.Instance.currentObjective];
        description.text = descriptions[DataPersistence.Instance.currentObjective];
    }

    public Vector3 getPlayerPosition()
    {
        return player.transform.position;
    }

    public void playRewardAudio(Vector3 pos)
    {
        audioSrc.transform.position = pos;
        audioSrc.Play();
    }

    public void initalizeBookText()
    {
        titles = new string[5];
        titles[0] = "Solar Panel Objective";
        titles[1] = "Gardening Objective";
        titles[2] = "Harvesting Objective";
        titles[3] = "Flower Learning Objective";
        titles[4] = "Bee Objective";
        descriptions = new string[5];
        descriptions[0] = "Collect the necessary equipment to build the solar panels to power the garden lights\nPlace the solar panels around the garden";
        descriptions[1] = "Find the shed holding the gardening equipment\nPlant the seeds in the garden";
        descriptions[2] = "Harvest the crops in the garden";
        descriptions[3] = "Learn about at least 5 different flowers in the garden and their role in the environment";
        descriptions[4] = "You will become a Bee and help pollinate the flowers in the garden";
    }

    public void setText(string title, string description)
    {
        this.title.text = title;
        this.description.text = description;
    }

    public void setImage(Sprite image)
    {
        this.image.sprite = image;
        this.image.enabled = true;
    }

    public void changeTime()
    {
        if(isDay)
        {
            RenderSettings.skybox = nightSkybox;
            sun.intensity = 0.41f;
            DynamicGI.UpdateEnvironment();
            isDay = false;
        }
        else
        {
            RenderSettings.skybox = daySkybox;
            sun.intensity = 1.0f;
            DynamicGI.UpdateEnvironment();
            isDay = true;
        }
    }
}
