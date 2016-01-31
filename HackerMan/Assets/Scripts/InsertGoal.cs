using UnityEngine;
using System.Collections;
using System;

public class InsertGoal : GoalState
{
    public GameObject objectsToInsert;
    public GameObject targetContainer;

    ConfigurableJoint targetJoint;

    private float maxDistance;

    private bool objectIsInContainer = false;

    void Start()
    {
        
        objectsToInsert = GameObject.Find(objectsToInsert.name);

        targetContainer = GameObject.Find(targetContainer.name);
        targetJoint = targetContainer.GetComponent<ConfigurableJoint>();

        targetContainer.GetComponent<OnTouchBehavior>().objectHit += InsertGoal_objectHit;

        maxDistance = targetJoint.linearLimit.limit;
        
    }

    private void InsertGoal_objectHit(object sender, EventArgs e)
    {
        objectIsInContainer = true;
    }

    public override bool CheckIfStateIsReached()
    {
        return objectIsInContainer;
    }
}
