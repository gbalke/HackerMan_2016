using UnityEngine;
using System.Collections;
using System;

public class OnTouchBehavior : MonoBehaviour {

    public GameObject targetName;

    public event EventHandler objectHit;

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
        Debug.Log(targetName.name);
        if (other.gameObject.name.Equals(targetName.name))
        {
            Debug.Log("does invoke");
            objectHit.Invoke(this, EventArgs.Empty);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        Debug.Log(targetName.name);
        if (other.gameObject.name == targetName.name)
        {
            Debug.Log("Does Invoke");
            objectHit.Invoke(this, EventArgs.Empty);
        }
    }
}
