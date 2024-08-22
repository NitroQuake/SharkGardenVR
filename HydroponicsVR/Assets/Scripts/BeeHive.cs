using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeHive : InteractableParent
{
    public GameObject cameraManager;
    public GameObject cameras;

    public GameObject bee;
    public GameObject flightRig;
    public GameObject flightHud;
    public GameObject player;
    public bool isPlayerBee;

    public GameObject vrCameraRig;
    public Transform vrCameraRigCenter;
    public Transform directionPlaceHolder;

    public override void Start()
    {
        base.Start();
        isPlayerBee = false;
    }

    public override void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && OVRInput.Get(OVRInput.Button.Two) && !isInteracted && (gameManager.isSelectedInteractable(this) || completed || specialInteractable))
        {
            if (DataPersistence.Instance.taskObjective < gameManager.selectedInteractable.Length && !completed && gameManager.isSelectedInteractable(this) && !isPlayerBee)
            {
                gameManager.setNextBeacon();
                if (isObjectiveChanger)
                {
                    gameManager.incrementNextObjective();
                    isObjectiveChanger = false;
                }
            } 
            else if (!completed && gameManager.isSelectedInteractable(this) && isPlayerBee)
            {
                //game is done
                completed = true;
                gameManager.turnOffBeacon();
                gameManager.playRewardAudio(transform.position);
            }

            interact(other);
            StartCoroutine(resetInteract());
            isInteracted = true;
        }
    }

    public override void interact(Collider other)
    {
        if(!isPlayerBee)
        {
            cameraManager.SetActive(false);
            cameras.SetActive(false);
            player.SetActive(false);
            bee.SetActive(true);

            //vrCameraRig.transform.position = new Vector3(vrCameraRig.transform.position.x - vrCameraRigCenter.position.x, vrCameraRigCenter.position.y - vrCameraRigCenter.position.y, vrCameraRig.transform.position.z - vrCameraRigCenter.position.z);
            bee.transform.position = vrCameraRigCenter.position;
            bee.transform.parent = vrCameraRigCenter;

            Vector3 direction = new Vector3(directionPlaceHolder.position.x, vrCameraRig.transform.position.y, directionPlaceHolder.position.z) - vrCameraRig.transform.position;
            vrCameraRig.transform.rotation = Quaternion.LookRotation(direction);
            float newRot = vrCameraRig.transform.eulerAngles.y - vrCameraRigCenter.localEulerAngles.y;
            vrCameraRig.transform.rotation = Quaternion.Euler(vrCameraRig.transform.eulerAngles.x, newRot, vrCameraRig.transform.eulerAngles.z);

            vrCameraRig.GetComponent<Fly>().enabled = true;
            isPlayerBee = true;
        }
        else
        {
            cameraManager.SetActive(true);
            cameras.SetActive(true);
            player.SetActive(true);
            bee.transform.position = new Vector3(56, 7, 61.5f);
            bee.SetActive(false);
            vrCameraRig.GetComponent<Fly>().enabled = false;
            isPlayerBee = false;
        }
    }

    public override void setCompletedState()
    {
        base.setCompletedState();
        gameManager.turnOffBeacon();
    }
}
