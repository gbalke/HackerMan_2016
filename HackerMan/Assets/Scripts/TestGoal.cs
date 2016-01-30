using UnityEngine;
using System.Collections;
using System;


// example goal
public class TestGoal : GoalState
{
    int test = 0;

    public override bool CheckIfStateIsReached()
    {
        if (test == 5)
        {
            return true;
        }
        return false;
    }

    public void Update()
    {
        test++;
    }
}