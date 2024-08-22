using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InputObject : MonoBehaviour
{
    [Header("Optional")]
    public InputObject requireOther;
    bool collected = false;

    public void Collect()
    {
        collected = true;
    }

    public bool IsCollected()
    {
        return collected;
    }

    public bool RequiresOther()
    {
        return requireOther != null;
    }
}
