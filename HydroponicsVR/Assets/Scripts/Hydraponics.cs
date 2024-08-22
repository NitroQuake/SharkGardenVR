using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hydraponics : InteractableParent
{
    public GameObject brokenPiece;
    public GameObject plants;
    public GameObject indicator;

    public override void interact(Collider other)
    {
        indicator.SetActive(false);
        brokenPiece.SetActive(true);
        StartCoroutine(grow());
    }

    public IEnumerator grow()
    {
        yield return new WaitForSeconds(3);
        plants.SetActive(true);
    }

    public override void setCompletedState()
    {
        base.setCompletedState();
        indicator.SetActive(false);
        brokenPiece.SetActive(true);
        plants.SetActive(true);
    }
}
