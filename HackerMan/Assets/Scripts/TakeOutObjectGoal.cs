using UnityEngine;
using System.Collections;
using System;

public class TakeOutObjectGoal : GoalState
{

    public GameObject container;
    public GameObject objectInContainer;

    private bool isTheObjectIn = true;

    public override bool CheckIfStateIsReached()
    {
        return !isTheObjectIn;
    }
    
    void Start()
    {
        container.GetComponent<OnLeaveBehavior>().objectHit += TakeOutObjectGoal_objectHit;
    }

    private void TakeOutObjectGoal_objectHit(object sender, EventArgs e)
    {
        isTheObjectIn = false;
    }
}
