using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolShed : InteractableParent
{
    public override void interact(Collider other)
    {
        Destroy(GetComponent<Collider>().gameObject);
    }

    public override void setCompletedState()
    {
        base.setCompletedState();
        interact(null);
    }
}
