using UnityEngine;
using System.Collections;
using System;

public class ThrowGoal : GoalState
{
    public GameObject objectToThrow;
    public string throwableTagName = "";
    public GameObject targetObject;

    public float distanceToThrowObject = 10f;

    private bool targetHit = false;

    void Start()
    {
        if (throwableTagName.Length == 0)
        {
            objectToThrow = GameObject.Find(objectToThrow.name);
        }
        
        if (targetObject != null)
        {
            //Debug.Log(targetObject.name);
            targetObject.GetComponent<OnTouchBehavior>().objectHit += ThrowGoal_objectHit;
        }
        else
        {
            Debug.Log("target is null");
        }
    }

    public void ThrowGoal_objectHit(object sender, EventArgs e)
    {
        GameObject go = (GameObject)sender;
        Debug.Log(sender);
        if (go.tag == throwableTagName || (objectToThrow != null && objectToThrow.name.Equals(go.name)))
        {
            Debug.Log("does invoke");
            targetHit = true;
        }
    }

    public override bool CheckIfStateIsReached()
    {
        // We have a target that must we must throw something at
        if (targetObject != null && targetHit)
        {
            return true;
        }
        else // otherwise throw an object away a certain distance
        {
            if (objectToThrow != null)
            {
                float distance = Vector3.Distance(objectToThrow.transform.position, Camera.main.transform.position);
                if (distance >= distanceToThrowObject)
                {
                    return true;
                }
            }
            
        }
        return false;
    }
}
