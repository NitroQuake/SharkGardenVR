using StarterAssets;
using UnityEngine;
using static OVRInput;

[RequireComponent(typeof(StarterAssetsInputs))]
public class VRThirdPersonController : MonoBehaviour
{

    StarterAssetsInputs sInput;
    [SerializeField] private Controller controllerLeft;
    [SerializeField] private Controller controllerRight;

    private void Start()
    {
        sInput = GetComponent<StarterAssetsInputs>();
    }

    private void Update()
    {
        //Movement
        Vector2 leftJoystickAxis = OVRInput.Get(Axis2D.PrimaryThumbstick, controllerLeft);
        sInput.MoveInput(leftJoystickAxis);

        //Jump
        bool aButton = OVRInput.Get(Button.One);
        sInput.JumpInput(aButton);

        //Sprint
        bool thumbstickDown = OVRInput.Get(Button.PrimaryThumbstick);
        float trigger = OVRInput.Get(Axis1D.PrimaryIndexTrigger);

        sInput.SprintInput(thumbstickDown || trigger >= 0.2f);

    }

}