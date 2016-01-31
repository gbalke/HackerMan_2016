using UnityEngine;
using System.Collections;

public enum leverState { ON = 1, OFF = 2, NA = 3 };

public class LeverControl : MonoBehaviour {

	public GameObject[] interacts;
    public bool up = false;

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
        leverAng = transform.localRotation.x;

		if ( leverAng >= 0.8f ) 
		{
			trig = leverState.ON;
            if (up)
            {
                On();
            }
            else
            {
                Off();
            }
		} 
		else if ( leverAng <= 0.5f ) 
		{
			trig = leverState.OFF;
            if (up)
            {
                Off();
            }
            else
            {
                On();
            }
        } 
		else 
		{
			trig = leverState.NA;
            if (up)
            {
                On();
            }
            else
            {
                Off();
            }
        }
	}

    void Off()
    {
        for (int i = 0; i < interacts.Length; i++)
        {
            interacts[i].gameObject.SetActive(false);
        }
    }

    void On()
    {
        for (int i = 0; i < interacts.Length; i++)
        {
            interacts[i].gameObject.SetActive(true);
        }
    }
}
