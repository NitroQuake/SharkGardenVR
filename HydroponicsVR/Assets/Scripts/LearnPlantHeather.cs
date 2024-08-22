using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnPlantHeather : InteractableParent
{
    public Sprite heather;

    public override void interact(Collider other)
    {
        gameManager.setText("Heather", "Heather is a flowering evergreen shrub belonging to the Ericaceae family, commonly found in Europe and Asia. It features small, scale-like leaves and clusters of tiny bell-shaped flowers, which can be pink, purple, white, or red. Heather plants are hardy and thrive in acidic, well-drained soils, often in heathlands, moors, and garden landscapes.");
        gameManager.setImage(heather);
        gameManager.openTaskBook();
    }
}
