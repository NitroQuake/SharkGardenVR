using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnPlantAgapanthus : InteractableParent
{
    public Sprite agapanthus;

    public override void interact(Collider other)
    {
        gameManager.setText("Agapanthus", "Agapanthus, commonly known as the African lily or Lily of the Nile, is a perennial plant native to South Africa. It belongs to the Amaryllidaceae family and features strap-like leaves and tall stems topped with clusters of trumpet-shaped flowers. Agapanthus thrives in well-drained soil and full sun to partial shade.");
        gameManager.setImage(agapanthus);
        gameManager.openTaskBook();
    }
}
