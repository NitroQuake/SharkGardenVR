using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeStayInPos : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(0, -0.05f, 0.23f);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
}
