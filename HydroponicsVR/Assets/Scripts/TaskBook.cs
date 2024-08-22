
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskBook : InteractableParent
{

    public override void interact(Collider other)
    {
        gameManager.updateBook();
        gameManager.openTaskBook();
    }

    public override void setCompletedState()
    {
        isObjectiveChanger = false;
    }
}
