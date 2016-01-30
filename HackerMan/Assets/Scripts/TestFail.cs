using UnityEngine;
using System.Collections;

// example fail
public class TestFail : FailState
{

    int test = 0;

    public override bool CheckIfStateIsReached()
    {
        if (test == 10)
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