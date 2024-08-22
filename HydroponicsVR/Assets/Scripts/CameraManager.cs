using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject activeCamera;
    [SerializeField] private List<Transform> cameraPositions;
    public Transform playerPos;
    public Transform cameraRot;
    public bool transition;

    void Start()
    {
        transition = true;

        if (cameraPositions[0] == null)
        {
            Debug.LogWarning("Uh oh, no cameras! Please add at least one camera");
        }

        if (activeCamera == null)
        {
            activeCamera.transform.position = cameraPositions[0].position;
        }
    }

    private void Update()
    {
        float minDist = Mathf.Infinity;
        Transform closestCamPos = null;
        for (int i = 0; i < cameraPositions.Count; i++)
        {
            float distance = Vector3.Distance(playerPos.position, cameraPositions[i].position);
            if (distance < minDist)
            {
                minDist = distance;
                closestCamPos = cameraPositions[i];
            }
        }

        if(activeCamera.transform.position != closestCamPos.position && transition)
        {
            StopCoroutine(timerCamera());
            activeCamera.transform.position = closestCamPos.position;
            Vector3 direction = new Vector3(playerPos.position.x, activeCamera.transform.position.y, playerPos.position.z) - activeCamera.transform.position;
            activeCamera.transform.rotation = Quaternion.LookRotation(direction);
            float newRot = activeCamera.transform.eulerAngles.y - cameraRot.localEulerAngles.y;
            activeCamera.transform.rotation = Quaternion.Euler(activeCamera.transform.eulerAngles.x, newRot, activeCamera.transform.eulerAngles.z);
            transition = false;
            StartCoroutine(timerCamera());
        }
    }

    public GameObject getActiveCamera()
    {
        return activeCamera;
    }

    public void setActiveCamera(int index)
    {
        try
        {
            activeCamera.transform.position = cameraPositions[index].position;
        } 
        catch (IndexOutOfRangeException ex)
        {
            Debug.LogError("Couldn't set camera, invalid index! " + ex);
        }
    }

    public IEnumerator timerCamera()
    {
        yield return new WaitForSeconds(3);
        transition = true;
    }
}
