using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public GameObject head;
    public GameObject rightHand;

    public float flySpeed = 10;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        flyIfFlying();

        if(transform.position.y < 3.9f)
        {
            transform.position = new Vector3(transform.position.x, 3.9f, transform.position.z);
        }
    }

    private void flyIfFlying()
    {
        if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
        {
            Vector3 flyDirection = rightHand.transform.position - head.transform.position;
            rb.velocity = flyDirection.normalized * flySpeed;

        } else if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            Vector3 flyDirection = head.transform.position - rightHand.transform.position;
            rb.velocity = flyDirection.normalized * flySpeed;
        }
    }
}
