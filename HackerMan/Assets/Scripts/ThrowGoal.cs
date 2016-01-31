using UnityEngine;
using System.Collections;
using System;

public class ThrowGoal : GoalState
{
    public GameObject objectToThrow;
    public GameObject targetObject;

    public float distanceToThrowObject = 10f;

    private bool targetHit = false;
    private Rigidbody targetRB;
    private Rigidbody grabbedRB;

    void Start()
    {
        objectToThrow = GameObject.Find(objectToThrow.name);
        if (targetObject != null)
        {
            Debug.Log(targetObject.name);
            targetObject.GetComponent<OnTouchBehavior>().objectHit += ThrowGoal_objectHit;
            targetRB = targetObject.GetComponent<Rigidbody>();
            grabbedRB = objectToThrow.GetComponent<Rigidbody>();
        }
        else
        {
            Debug.Log("target is null");
        }
    }

    public void ThrowGoal_objectHit(object sender, EventArgs e)
    {
        targetHit = true;
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
            float distance = Vector3.Distance(objectToThrow.transform.position, Camera.main.transform.position);
            if (distance >= distanceToThrowObject)
            {
                return true;
            }
        }
        return false;
    }
}
