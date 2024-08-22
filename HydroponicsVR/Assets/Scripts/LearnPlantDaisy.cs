using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnPlantDaisy : InteractableParent
{
    public Sprite daisy;

    public override void interact(Collider other)
    {
        gameManager.setText("Daisy", "A daisy plant is a flowering plant belonging to the Asteraceae family. Daisies are known for their simple beauty and resilience, often found in gardens and wildflower meadows. They thrive in well-drained soil and full sunlight, blooming from late spring to early autumn.");
        gameManager.setImage(daisy);
        gameManager.openTaskBook();
    }
}
