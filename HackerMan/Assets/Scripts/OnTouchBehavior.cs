using UnityEngine;
using System.Collections;
<<<<<<< HEAD
=======
using System;
>>>>>>> b622d96d0db8b7a32db9d1330412248a633dd231

public class OnTouchBehavior : MonoBehaviour {

    public string targetName;

<<<<<<< HEAD
=======
    public event EventHandler objectHit;

>>>>>>> b622d96d0db8b7a32db9d1330412248a633dd231
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
<<<<<<< HEAD
            Debug.Log("YESSSSS");
=======
            objectHit.Invoke(this, EventArgs.Empty);
>>>>>>> b622d96d0db8b7a32db9d1330412248a633dd231
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
