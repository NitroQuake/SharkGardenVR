using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VRTable : InteractableParent
{
    public override void interact(Collider other)
    {
        SceneManager.LoadScene(2); // VR Simulation Scene
    }
}
