using UnityEngine;
using System.Collections;
using System;

public class OnTouchBehavior : MonoBehaviour {

    public string targetName;

    public event EventHandler objectHit;

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == targetName && objectHit != null)
        {
            objectHit.Invoke(this, EventArgs.Empty);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == targetName)
        {
            Debug.Log("YESSSSS");
        }
    }
}
