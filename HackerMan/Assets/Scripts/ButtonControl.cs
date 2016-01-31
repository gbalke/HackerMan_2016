using UnityEngine;
using System.Collections;

public class ButtonControl : MonoBehaviour {

    public enum buttonState {ON = 1, OFF = 2};

    public float buttonPos;

    public buttonState state;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        buttonPos = transform.position.z;

        if ( buttonPos <= -0.09 )
        {
            state = buttonState.ON;
        } 
        else
        {
            state = buttonState.OFF;
        }
	}
}
