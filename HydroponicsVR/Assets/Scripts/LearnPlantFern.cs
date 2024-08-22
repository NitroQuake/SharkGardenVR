using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnPlantFern : InteractableParent
{
    public Sprite fern;

    public override void interact(Collider other)
    {
        gameManager.setText("Fern", "A fern is a non-flowering plant belonging to the group known as Pteridophyta. Ferns have feathery, divided leaves called fronds, which unfurl from curled-up structures known as fiddleheads. Ferns thrive in moist, shaded environments, often seen in forests, swamps, and as ornamental plants in gardens.");
        gameManager.setImage(fern);
        gameManager.openTaskBook();
    }
}
