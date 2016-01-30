using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MissionControl : MonoBehaviour {


    private LinkedListNode<Challenge> currentChallenge;

    public Challenge[] challenges;
    public LinkedList<Challenge> challengeList;
    public bool GameIsRunning;


	// Use this for initialization
	void Start () {

        challengeList = new LinkedList<Challenge>();
        
        for (int i = 0; i < challenges.Length; i++)
        {
            Challenge c = Instantiate(challenges[i]);
            if (c == null)
            {
                Debug.Log("why u no work");
            }
            c.goalReached += C_goalReached;
            c.failStateReached += C_failStateReached;
            challengeList.AddLast(c);
        }
        currentChallenge = challengeList.First;
        currentChallenge.Value.StartChallenge();
	}

    private void AttemptNextChallenge()
    {
        Destroy(currentChallenge.Value);
        currentChallenge = currentChallenge.Next;
        // check if there are any more challenges
        if (currentChallenge == null)
        {
            throw new NotImplementedException("TODO: NO MORE CHALLENGES");
        }
        else
        {   
            currentChallenge.Value.StartChallenge();
        }
        
    }

    private void C_failStateReached(object sender, EventArgs e)
    {
        throw new NotImplementedException("TODO: The Challenge has Failed -- TAKE DAMAGE OR END GAME");
    }

    private void C_goalReached(object sender, EventArgs e)
    {
        AttemptNextChallenge();
    }

    // Update is called once per frame
    void Update () {
        
	}
}
