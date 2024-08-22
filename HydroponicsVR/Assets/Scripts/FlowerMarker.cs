using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerMarker : InteractableParent
{
    public override void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !isInteracted && gameManager.isSelectedInteractable(this))
        {
            if (DataPersistence.Instance.taskObjective < gameManager.selectedInteractable.Length && gameManager.isSelectedInteractable(this))
            {
                Debug.Log("FlowerMarker: OnTriggerStay: setting next beacon");

                gameManager.setNextBeacon();
                if (isObjectiveChanger)
                {
                    gameManager.incrementNextObjective();
                    isObjectiveChanger = false;
                }
                completed = true;
            }

            interact(other);
            isInteracted = true;
        }
    }

    public override void interact(Collider other)
    {
        //
    }
}
