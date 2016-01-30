using UnityEngine;
using System.Collections;

public class OnTouchBehavior : MonoBehaviour {

    public string targetName;

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == targetName)
        {
            Debug.Log("YESSSSS");
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
