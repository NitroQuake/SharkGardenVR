using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnPlantMonsterra : InteractableParent
{
    public Sprite monstera;

    public override void interact(Collider other)
    {
        gameManager.setText("Monstera", "Monstera is a tropical plant known for its large, glossy, and deeply lobed or perforated leaves. Belonging to the Araceae family, Monstera is native to Central and South America. Monstera thrives in bright, indirect light and humid conditions, making it a popular houseplant.");
        gameManager.setImage(monstera);
        gameManager.openTaskBook();
    }
}
