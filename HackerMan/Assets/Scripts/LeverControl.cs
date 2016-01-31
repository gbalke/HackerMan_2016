using UnityEngine;
using System.Collections;

public class LeverControl : MonoBehaviour {

	public enum leverState {ON = 1, OFF = 2, NA = 3};

	// 0 is off and 1 is on.
	public leverState trig;

	// The current angle of the lever.
	public float leverAng;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		leverAng = transform.rotation.x;

		if ( leverAng >= 115 ) 
		{
			trig = leverState.ON;
		} 
		else if ( leverAng <= 55 ) 
		{
			trig = leverState.OFF;
		} 
		else 
		{
			trig = leverState.NA;
		}
	}
}
