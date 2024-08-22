using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableParent : MonoBehaviour
{
    public GameManager gameManager;
    public bool isInteracted;
    public InteractableParent nextInteractable;
    public bool isObjectiveChanger;
    public bool completed;
    public bool specialInteractable;

    public virtual void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        completed = false;
    }

    public virtual void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && OVRInput.Get(OVRInput.Button.Two) && !isInteracted && (gameManager.isSelectedInteractable(this) || completed || specialInteractable))
        {
            if (DataPersistence.Instance.taskObjective < gameManager.selectedInteractable.Length && !completed && gameManager.isSelectedInteractable(this))
            {
                gameManager.setNextBeacon();
                if (isObjectiveChanger)
                {
                    gameManager.incrementNextObjective();
                    isObjectiveChanger = false;
                    gameManager.playRewardAudio(transform.position);
                }
                completed = true;
            }

            interact(other);
            StartCoroutine(resetInteract());
            isInteracted = true;
        }
    }

    public abstract void interact(Collider other);

    public IEnumerator resetInteract()
    {
        yield return new WaitForSeconds(1);
        isInteracted = false;
    }

    public virtual void setCompletedState()
    {
        completed = true; 
        isObjectiveChanger = false;
    }
}
