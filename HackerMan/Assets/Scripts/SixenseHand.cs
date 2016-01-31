
//
// Copyright (C) 2013 Sixense Entertainment Inc.
// All Rights Reserved
//

using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class SixenseHand : MonoBehaviour
{
	public SixenseHands	m_hand;
	public SixenseInput.Controller m_controller = null;
    public float GripStrength;

    //Animator 	m_animator;
    Vector3 LVelocity, RVelocity;
	Vector3		m_initialPosition, LprevPosition, RprevPosition;
	Quaternion 	m_initialRotation;
    bool LTrig = false, RTrig = false;
    GameObject lastLeft, lastRight;
    GameObject LObject = null, RObject = null;


    protected void Start() 
	{
		// get the Animator
		//m_animator = gameObject.GetComponent<Animator>();
		m_initialRotation = transform.localRotation;
		m_initialPosition = transform.localPosition;
	}


    protected void Update()
    {
        if (m_controller == null)
        {
            m_controller = SixenseInput.GetController(m_hand);
        }

        // calculate velocity for left then right controller
        LVelocity = CalcVelocity(0);
        RVelocity = CalcVelocity(1);

        //handles input from hydra buttons and triggers
        


	}

    void FixedUpdate()
    {
        for (int i = 0; i < 2; i++)
        {

            HandleInput(i);
        }
    }
	
	
	// Updates the animated object from controller input.
	protected void HandleInput(int i)
	{
        
           if(SixenseInput.Controllers[i].GetButton(SixenseButtons.TRIGGER))
            {
                //if left controller presses trigger down
                if(i == 0)
                {
                    //print(LVelocity + " left");
                    LTrig = true;
                }
                

            //if right controller presses trigger down
                if (i == 1)
                {
                    //print(RVelocity + "right");
                    RTrig = true;
                }
            }
            else
            {
               //if left controller releases trigger
              if (i == 0)
              {
                 LTrig = false;
              }
               //if right controller releases trigger
              else if (i == 1)
              {
                 RTrig = false;
              }
            }

        if (SixenseInput.Controllers[i].GetButtonDown(SixenseButtons.BUMPER))
        {
            InputTracking.Recenter();
        }

       // test which triggers are pressed
       // print("TRIGGERS" + LTrig + " " + RTrig);
    }

    Vector3 CalcVelocity(int i)
    {
        
        Vector3 velocity; 

        //calculates velocity for left controller
        if(i == 0)
        {
            velocity = (SixenseInput.Controllers[i].Position - LprevPosition) / Time.deltaTime;
            LprevPosition = SixenseInput.Controllers[i].Position;
        }
        //calculates velocity for right controller
        else
        {
            velocity = (SixenseInput.Controllers[i].Position - RprevPosition) / Time.deltaTime;
            RprevPosition = SixenseInput.Controllers[i].Position;
        }
        
        return velocity;
    }


    public Quaternion InitialRotation
	{
		get { return m_initialRotation; }
	}
	
	public Vector3 InitialPosition
	{
		get { return m_initialPosition; }
	}






    void OnTriggerStay(Collider col)
    {
       
        //pickup and throw gameobjects with Left hand
        if (LTrig && gameObject.name == "left" && col.tag == "Throwable")
            {
            gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;

            if(LObject == null)
            {
                LObject = col.gameObject;
            }
            

                if(lastLeft == LObject)
                {
                    Vector3 dist = gameObject.transform.position - LObject.transform.position;

                    LObject.GetComponent<Rigidbody>().AddForce(dist * GripStrength);
                    if (LObject.GetComponent<Rigidbody>().useGravity == true)
                    {
                        LObject.transform.rotation = gameObject.transform.rotation;
                    }

                    LObject.GetComponent<Rigidbody>().velocity = LVelocity / 750;
                }
            
            }
            else if (!LTrig && gameObject.name == "left")
            {
                LObject = null;
            gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
            }


        //pickup and throw gameobjects with Right hand
        if (RTrig && gameObject.name == "right" && col.tag == "Throwable")
            {
            gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;

            if (RObject == null)
            {
                RObject = col.gameObject;
            }
                if(lastRight == RObject)
                {
                    Vector3 dist = gameObject.transform.position - RObject.transform.position;

                    RObject.GetComponent<Rigidbody>().AddForce(dist * GripStrength);
                    if (RObject.GetComponent<Rigidbody>().useGravity == true)
                    {
                        RObject.transform.rotation = gameObject.transform.rotation;
                    }
                    RObject.GetComponent<Rigidbody>().velocity = RVelocity / 750;
                }

            
            
            }
            else if (!RTrig && gameObject.name == "right")
            {
                RObject = null;
            gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
            }

        
            lastLeft = LObject;
            lastRight = RObject;
        
        

    }
      
}



