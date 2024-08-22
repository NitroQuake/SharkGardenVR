using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFruitsnVegtables : InteractableParent
{
    public override void interact(Collider other)
    {
        Destroy(gameObject);
    }

    public override void setCompletedState()
    {
        base.setCompletedState();
        interact(null);
    }
}
