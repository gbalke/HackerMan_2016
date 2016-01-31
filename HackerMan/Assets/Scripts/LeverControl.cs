using UnityEngine;
using System.Collections;

public class LeverControl : MonoBehaviour {

	public enum leverState {ON = 1, OFF = 2, NA = 3};

	// 0 is off and 1 is on.
	public leverState trig;

	// The current angle of the lever.
	public float leverAng;

    Light lt;
    GameObject lights;

	// Use this for initialization
	void Start () {
        lt = GetComponentInChildren<Light>();
        lights = lt.gameObject;
	}
	
	// Update is called once per frame
	void Update () 
	{
        leverAng = transform.localRotation.x;

		if ( leverAng >= 0.8f ) 
		{
			trig = leverState.ON;
            lights.gameObject.SetActive(true);
		} 
		else if ( leverAng <= 0.5f ) 
		{
			trig = leverState.OFF;
            lights.gameObject.SetActive(false);
        } 
		else 
		{
			trig = leverState.NA;
            lights.gameObject.SetActive(false);
        }
	}
}
