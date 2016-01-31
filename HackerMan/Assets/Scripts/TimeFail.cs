using System;
using UnityEngine;

public class TimeFail : FailState {

    public float countdownTime = 30;

    private float counter;
    
    public override bool CheckIfStateIsReached()
    {
        if (counter >= countdownTime)
        {
            return true;
        }
        return false;
    }

    // Use this for initialization
    void Start () {
        counter = 0;
    }

    void Update()
    {
        //Debug.Log("updaing");
        counter += Time.deltaTime;
    }
}
