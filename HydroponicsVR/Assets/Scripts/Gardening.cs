using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Gardening : InteractableParent
{
    public GameObject plants; 

    public override void interact(Collider other)
    {
        SceneManager.LoadScene(3); // VR Simulation Scene
    }

    public void grow()
    {
        if (plants.transform.position.y < 0)
        {
            plants.transform.Translate(Vector3.up * 0.2f);
        }
        else
        {
            CancelInvoke();
        }
    }

    public override void setCompletedState()
    {
        base.setCompletedState();
        InvokeRepeating("grow", 2, 0.5f);
    }
}
