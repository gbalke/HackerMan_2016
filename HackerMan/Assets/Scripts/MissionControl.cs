using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MissionControl : MonoBehaviour {

    private int descriptionIndex = 0;
    private LinkedListNode<Challenge> currentChallenge;

    public GameObject computerScreen;
    public Challenge[] challenges;
    public GameObject[] challengeDesciptions;
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
        displayChallengeDescription();
        currentChallenge.Value.StartChallenge();
	}

    private void displayChallengeDescription()
    {
        // TODO: if not the first challenge, move the current message down
        GameObject message = challengeDesciptions[descriptionIndex++];

        Vector3 size = message.GetComponent<MeshRenderer>().bounds.size;
        Vector3 spawnLocation = computerScreen.transform.position;


        MeshRenderer computerRend = computerScreen.GetComponent<MeshRenderer>();
        MeshRenderer messageRend = message.GetComponent<MeshRenderer>();

        // scale the message
        //message.transform.localScale = computerScreen.GetComponent<Renderer>().bounds.size;

        // Move the message
        //spawnLocation += -computerScreen.transform.right * messageRend.bounds.size.x / 2;// + computerRend.bounds.size.x / 2 * -computerScreen.transform.right;
        //spawnLocation += computerScreen.transform.forward * computerRend.bounds.size.y / 2 - computerScreen.transform.forward * messageRend.bounds.size.y / 2;
        spawnLocation += computerScreen.transform.up * 0.001f;

        Instantiate(message, spawnLocation, computerScreen.transform.rotation); 
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
