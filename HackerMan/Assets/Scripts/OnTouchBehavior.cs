using UnityEngine;
using System.Collections;
using System;

public class OnTouchBehavior : MonoBehaviour {

    //public GameObject targetName;

    public event EventHandler objectHit;

    void OnCollisionEnter(Collision other)
    {
        //Debug.Log(other.gameObject.tag);
        //Debug.Log(objectHit);
        if (objectHit != null)
        {
            Debug.Log("invoking");
            objectHit.Invoke(other.gameObject, EventArgs.Empty);
        }
            
    }

    void OnTriggerEnter(Collider other)
    {
        if (objectHit != null)
            objectHit.Invoke(other.gameObject, EventArgs.Empty);
    }
}
