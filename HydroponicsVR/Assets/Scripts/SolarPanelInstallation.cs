using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarPanelInstallation : InteractableParent
{
    public GameObject solarPanelPrefab;
    public GameObject lights;

    public override void interact(Collider other)
    {
        int transfromCount = transform.childCount;
        for (int i = 0; i < transfromCount; i++)
        {
            GameObject solarPanel = Instantiate(solarPanelPrefab, transform.GetChild(i).transform.position, transform.GetChild(i).rotation);
            solarPanel.transform.SetParent(transform);
            Destroy(transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < lights.transform.childCount; i++)
        {
            foreach(Light light in lights.transform.GetChild(i).GetComponentsInChildren<Light>())
            {
                light.enabled = true;
            }
        }
        Destroy(GetComponent<BoxCollider>());
    }

    public override void setCompletedState()
    {
        base.setCompletedState();
        interact(null);
    }
}
