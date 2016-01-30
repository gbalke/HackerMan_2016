using UnityEngine;
using System.Collections;
using System;

public class ThrowGoal : GoalState
{
    public GameObject objectToThrow;
    public GameObject targetObject;

    public float distanceToThrowObject = 10f;

<<<<<<< HEAD
=======
    private bool targetHit = false;
>>>>>>> b622d96d0db8b7a32db9d1330412248a633dd231
    private Rigidbody targetRB;
    private Rigidbody grabbedRB;

    void Start()
    {
        objectToThrow = GameObject.Find(objectToThrow.name);
        if (targetObject != null)
        {
            targetObject = GameObject.Find(targetObject.name);
<<<<<<< HEAD
=======
            targetObject.GetComponent<OnTouchBehavior>().objectHit += ThrowGoal_objectHit;
>>>>>>> b622d96d0db8b7a32db9d1330412248a633dd231
            targetRB = targetObject.GetComponent<Rigidbody>();
            grabbedRB = objectToThrow.GetComponent<Rigidbody>();
        }
    }

<<<<<<< HEAD
    public override bool CheckIfStateIsReached()
    {
        // We have a target that must we must throw something at
        if (targetObject != null)
        {
            // TODO: target throw not implemented
            // what if mulitple objects to throw?

=======
    private void ThrowGoal_objectHit(object sender, EventArgs e)
    {
        targetHit = true;
    }

    public override bool CheckIfStateIsReached()
    {
        // We have a target that must we must throw something at
        if (targetObject != null && targetHit)
        {
            return true;
>>>>>>> b622d96d0db8b7a32db9d1330412248a633dd231
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
