using UnityEngine;
using System.Collections;
using System;


// example goal
public class TestGoal : GoalState
{
    public float countdown = 5f;

    private float counter = 0;

    public override bool CheckIfStateIsReached()
    {
        if (counter >= countdown)
        {
            return true;
        }
        return false;
    }

    public void Update()
    {
        counter += Time.deltaTime;
    }
}