using UnityEngine;
using System.Collections;

public class batteryHolder : MonoBehaviour {

    GameObject battery = null;
    public GameObject batterMold, Lightbulb, spotlight;

	// Use this for initialization
	void Start () {
        Lightbulb.gameObject.SetActive(false);
        spotlight.SetActive(false);
    }

    void Update()
    {
        if (battery != null)
        {

            battery.transform.position = batterMold.transform.position;
        }


    }

    // Update is called once per frame
    void OnTriggerStay(Collider col)
    {
        if(col.name == "Battery")
        {
            battery = col.gameObject;
            battery.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            battery.GetComponent<Rigidbody>().useGravity = false;
            battery.transform.rotation = batterMold.transform.rotation;
            Lightbulb.SetActive(true);
            spotlight.SetActive(true);
        }
    }
}
