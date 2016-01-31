using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MissionControl : MonoBehaviour {

    public Challenge openningChallege;

    public GameObject computerScreen;
    //public GameObject challengeTextPrefab;

    public LinkedList<Challenge> challengeList;
    public LinkedListNode<Challenge> currentChallenge;
    public bool GameIsRunning;

    private int descriptionIndex = 5;
    private string currentDescription = "";

    public const int LINELENGTH = 13;
    public const int LINEHEIGHT = 7;
    private TextMesh computerTextMesh;

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
        //Challenge first = Instantiate(openningChallege);
        //first.goalReached += C_goalReached1;
        //first.failStateReached += C_failStateReached1;
        //challengeList.AddFirst(first);

        Debug.Log(++currentChal);
        currentChallenge = challengeList.First;
        computerTextMesh = computerScreen.transform.GetChild(0).GetComponent<TextMesh>();
        displayChallengeDescription();
        currentChallenge.Value.StartChallenge();

        GameIsRunning = true;
	}

    private void C_failStateReached1(object sender, EventArgs e)
    {
        GameIsRunning = false;
        currentDescription = "GAME OVER";
    }

    private void C_goalReached1(object sender, EventArgs e)
    {
        AttemptNextChallenge();
    }

    private void displayChallengeDescription()
    {
        currentDescription = currentChallenge.Value.challengeDescription;

        int length = currentDescription.Length;
        int maxChars = LINEHEIGHT * LINELENGTH;
        int range = maxChars - length;
        descriptionIndex = (int)Math.Floor(UnityEngine.Random.value * (range - 3) + 3);

        //int numberOfNewLine = (length + (descriptionIndex % LINELENGTH)) / LINELENGTH;
        ////int someIndex = descriptionIndex % LINELENGTH;
        ////int insertPos = LINELENGTH - someIndex;
        ////currentDescription = currentDescription.Insert(insertPos, "\n");

        ////Debug.Log(numberOfNewLine);

        //int overhead = -1;
        //int charsAdded = 0;
        //for (int i = 0; i < numberOfNewLine; ++i)
        //{
        //    int insertPos = LINELENGTH - (descriptionIndex % LINELENGTH) + 1;
        //    currentDescription = currentDescription.Insert(insertPos+++overhead, "\n");
        //    charsAdded += insertPos;
        //}

        //if (currentDescription != null) Destroy(currentDescription);

        // TODO: if not the first challenge, move the current message down
        //currentDescription = currentChallenge.Value.challengeDescription;

        // Vector3 size = challengeTextPrefab.GetComponent<MeshRenderer>().bounds.size;
        // Vector3 spawnLocation = computerScreen.transform.position;


        // MeshRenderer computerRend = computerScreen.GetComponent<MeshRenderer>();
        // MeshRenderer messageRend = challengeTextPrefab.GetComponent<MeshRenderer>();

        // scale the message
        // message.transform.localScale = computerScreen.GetComponent<Renderer>().bounds.size;

        // Move the message
        //spawnLocation += -computerScreen.transform.right * messageRend.bounds.size.x / 2;// + computerRend.bounds.size.x / 2 * -computerScreen.transform.right;
        // spawnLocation += computerScreen.transform.forward * computerRend.bounds.size.y / 2 - computerScreen.transform.forward * messageRend.bounds.size.y / 2;
        // spawnLocation += computerScreen.transform.up * 0.001f;

        // currentDescription = (GameObject)Instantiate(challengeTextPrefab, spawnLocation, computerScreen.transform.rotation);
        //currentDescription.transform.GetChild(0).GetComponent<TextMesh>().text = description;
    }

    int currentChal = 0;
    private void AttemptNextChallenge()
    {
        //currentChallenge.Value.enabled = false;
        Destroy(currentChallenge.Value);
        currentChallenge = currentChallenge.Next;
        // check if there are any more challenges
        if (currentChallenge == null)
        {
            GameIsRunning = false;
            currentDescription = "You have hacked in";
        }
        else
        {
            Debug.Log(++currentChal);
            //currentChallenge.Value.enabled = true;
            displayChallengeDescription();
            currentChallenge.Value.StartChallenge();
        }
        
    }

    void Update()
    {
        int tempCounter = 0;
        //string textToAppear = "";
        //for (int i = 0; i < LINEHEIGHT; ++i)
        //{
        //    for (int p = 0; p < LINELENGTH; ++p)
        //    {
        //        textToAppear += RandomLetter.GetLetter();
        //        tempCounter++;
        //    }
        //    textToAppear += "\n";
        //}
        string textToAppear = "";
        bool useDesc = false;
        int messageIndex = 0;
        for (int i = 0, size = LINELENGTH * LINEHEIGHT; i < size; ++i)
        {
            if (i == descriptionIndex)
            {
                useDesc = true;
            }
            if (useDesc && messageIndex >= currentDescription.Length)
            {
                useDesc = false;
            }
            else if (useDesc)
            {
                textToAppear += currentDescription[messageIndex++];
            }
            else if (i < 2)
            {
                textToAppear += "0";// currentChallenge.Value.GetTimeUntilFail(i); // TODO: Getting time not working
            }
            else
            {
                textToAppear += RandomLetter.GetLetter();
            }

            tempCounter++;
            if (tempCounter % LINELENGTH == 0)
            {
                textToAppear += "\n";
            }
        }
        if (GameIsRunning)
        {
            computerTextMesh.text = textToAppear;
        }
        
    }
}

static class RandomLetter
{
    static System.Random _rand = new System.Random();
    public static char GetLetter()
    {
        int num = _rand.Next(0, 25);
        char let = (char)('a' + num);
        return let;
    }
}