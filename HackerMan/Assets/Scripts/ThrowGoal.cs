using UnityEngine;
using System.Collections;
using System;

public class ThrowGoal : GoalState
{
    public GameObject objectToThrow;
    public GameObject targetObject;

    public float distanceToThrowObject = 10f;

    private Rigidbody targetRB;
    private Rigidbody grabbedRB;

    void Start()
    {
        objectToThrow = GameObject.Find(objectToThrow.name);
        if (targetObject != null)
        {
            targetObject = GameObject.Find(targetObject.name);
            targetRB = targetObject.GetComponent<Rigidbody>();
            grabbedRB = objectToThrow.GetComponent<Rigidbody>();
        }
    }

    public override bool CheckIfStateIsReached()
    {
        // We have a target that must we must throw something at
        if (targetObject != null)
        {
            // TODO: target throw not implemented
            // what if mulitple objects to throw?

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
