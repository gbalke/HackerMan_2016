using UnityEngine;
using System.Collections;
using System;

public class LeverGoal : GoalState
{
    public GameObject lever;

    public leverState goal = leverState.OFF;

    public override bool CheckIfStateIsReached()
    {
        return lever.GetComponent<LeverControl>().trig == goal;
    }
}
