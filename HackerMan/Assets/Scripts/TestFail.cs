using UnityEngine;
using System.Collections;
using System;

// example fail
public class TestFail : FailState
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

    public override char GetTimeCharAt(int i)
    {
        return '\0';
    }

    public void Update()
    {
        counter += Time.deltaTime;
    }
}