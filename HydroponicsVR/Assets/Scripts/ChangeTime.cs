using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTime : InteractableParent
{
    public override void interact(Collider other)
    {
        gameManager.changeTime();
    }
}
