
//
// Copyright (C) 2013 Sixense Entertainment Inc.
// All Rights Reserved
//

using UnityEngine;
using System.Collections;

public class SixenseHand : MonoBehaviour
{
	public SixenseHands	m_hand;
	public SixenseInput.Controller m_controller = null;

    //Animator 	m_animator;
    Vector3 LVelocity, RVelocity;
	Vector3		m_initialPosition, LprevPosition, RprevPosition;
	Quaternion 	m_initialRotation;


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


        LVelocity = CalcVelocity(0);
        RVelocity = CalcVelocity(1);

        
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
                print(LVelocity + " left");
                
            }
                //if right controller presses trigger down
                else
                {
                print(RVelocity + "right");
            }
            



        }
	}

    Vector3 CalcVelocity(int i)
    {
        //finish velocity work!!!
        Vector3 velocity; 

        if(i == 0)
        {
            velocity = (SixenseInput.Controllers[i].Position - LprevPosition) / Time.deltaTime;
            LprevPosition = SixenseInput.Controllers[i].Position;
        }
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
}

