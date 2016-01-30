using UnityEngine;
using System.Collections;
using System;

public class Challenge : MonoBehaviour {

    public event EventHandler goalReached;
    public event EventHandler failStateReached;


    public bool IsStarted = false;

    // Goal
    public GoalState goalState;
    // Fail State
    public FailState failState;

	// Use this for initialization
	void Start () {

        
    }


    // use this to initialize any game specific logic
    public void StartChallenge()
    {
        IsStarted = true;
        goalState = Instantiate(goalState);
        failState = Instantiate(failState);
        Debug.Log("chellege staert");
    }

	// Update is called once per frame
	void Update () {
        if (IsStarted && goalState.CheckIfStateIsReached())
        {
            Debug.Log("goal reached");
            goalReached.Invoke(this, EventArgs.Empty);
            Destroy(failState);
            Destroy(goalState);
            IsStarted = false;
        }
        if (IsStarted && failState.CheckIfStateIsReached())
        {
            Debug.Log("fail reached");
            failStateReached.Invoke(this, EventArgs.Empty);
            Destroy(failState);
            Destroy(goalState);
            IsStarted = false;
        }
    }

    protected virtual void OnGoalReached(EventArgs e)
    {
        EventHandler handler = goalReached;
        if (handler != null)
        {
            handler(this, e);
        }
    }

    protected virtual void OnFailStateReached(EventArgs e)
    {
        EventHandler handler = failStateReached;
        if (handler != null)
        {
            handler(this, e);
        }
    }
}
