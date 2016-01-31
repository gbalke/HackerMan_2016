using UnityEngine;
using System.Collections;
using System;

public class RaycastGoal : GoalState
{

    public GameObject sourceObject;
    public GameObject targetObject;
    public float durationOnTarget = 0f;
    public float rayRange = 50f;

    private float counter = 0;
    private bool isCompleted = false;

    public override bool CheckIfStateIsReached()
    {
        return isCompleted;
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(sourceObject.transform.position, sourceObject.transform.forward, out hit))
        {
            Debug.Log(hit.transform.gameObject.name);
            Debug.Log(targetObject.name);
            if (hit.transform.gameObject.name.Equals(targetObject.name))
            {
                Debug.Log(counter);
                counter += Time.deltaTime;
                if (counter >= durationOnTarget)
                {
                    isCompleted = true;
                }
            }
            else
            {
                counter = 0;
            }
        }
        else
        {
            counter = 0;
        }
    }
}
