using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MissionControl : MonoBehaviour {

    private int descriptionIndex = 0;

    public GameObject computerScreen;

    public LinkedList<Challenge> challengeList;
    public LinkedListNode<Challenge> currentChallenge;
    public bool GameIsRunning;


	// Use this for initialization
	void Start () {
        challengeList = new LinkedList<Challenge>();
        Challenge[] challenges = FindObjectsOfType<Challenge>();

        for (int i = 0; i < challenges.Length; i++)
        {

            Challenge c = challenges[i];
            //c.enabled = false;
            c.goalReached += C_goalReached1;
            c.failStateReached += C_failStateReached1;
            challengeList.AddLast(c);
        }

        displayChallengeDescription();
        Debug.Log(++currentChal);
        currentChallenge = challengeList.First;
        //currentChallenge.Value.enabled = true;
        currentChallenge.Value.StartChallenge();
        GameIsRunning = true;
	}

    private void C_failStateReached1(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void C_goalReached1(object sender, EventArgs e)
    {
        AttemptNextChallenge();
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

    int currentChal = 0;
    private void AttemptNextChallenge()
    {
        currentChallenge.Value.enabled = false;
        Destroy(currentChallenge.Value);
        currentChallenge = currentChallenge.Next;
        // check if there are any more challenges
        if (currentChallenge == null)
        {
            throw new NotImplementedException("TODO: YOU WIN TEH GAME");
        }
        else
        {
            Debug.Log(++currentChal);
            //currentChallenge.Value.enabled = true;
            currentChallenge.Value.StartChallenge();
        }
        
    }
}
