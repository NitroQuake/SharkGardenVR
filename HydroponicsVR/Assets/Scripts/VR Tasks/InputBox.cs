using JetBrains.Annotations;
using Meta.WitAi;
using Oculus.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputBox : MonoBehaviour
{
    public List<InputObject> requiredObjects;
    public List<GameObject> showObjects;

    int collected = 0;

    private void Start()
    {
        //Hide everything
        foreach (var obj in showObjects)
        {
            obj.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject gameObj = other.gameObject;
        InputObject inObj = gameObj.GetComponent<InputObject>();

        if (inObj == null)
        {
            Debug.Log("No Input Object");
            return;
        }

        if (!requiredObjects.Contains(inObj)) //Not a required object
        {
            return;
        }

        if (inObj.RequiresOther() && !inObj.requireOther.IsCollected()) //Dependent object is not yet collected
        {
            return;
        }

        //Now you can collect
        inObj.Collect();
        gameObj.SetActive(false);
        ShowObject(inObj);

        collected += 1;

        if (IsAllCollected())
        {
            //Show everything
            showObjects.ForEach(o => o.SetActive(true));
            StartCoroutine(LoadGameScene());
        }
    }

    private void ShowObject(InputObject inObj)
    {
        int i = requiredObjects.IndexOf(inObj);

        if (i < showObjects.Count) //Ensure index is in bounds
        {
            showObjects[i].SetActive(true);
        }
    }

    private bool IsAllCollected()
    {
        return collected >= requiredObjects.Count;
    }

    IEnumerator LoadGameScene()
    {
        yield return new WaitForEndOfFrame();

        SceneManager.LoadSceneAsync(1);

        yield return new WaitForSecondsRealtime(5);
    }

}
