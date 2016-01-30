using System;
using UnityEngine;

public class TimeFail : FailState {

    public float countdownTime = 30;

    private float counter;
<<<<<<< HEAD

    // TODO true if time has passed
=======
    
>>>>>>> b622d96d0db8b7a32db9d1330412248a633dd231
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
        counter += Time.deltaTime;
    }
}
