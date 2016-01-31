using UnityEngine;
using System.Collections;
using System;

public class SliderGoal : GoalState
{
    public GameObject slider;

    public GameObject UpTrigger;
    public GameObject DownTrigger;
    
    public enum SliderDir
    {
        UP,
        DOWN,
        NONE
    }

    SliderDir currentSlide = SliderDir.NONE;

    public SliderDir sliderDirectionGoal = SliderDir.UP;

    public override bool CheckIfStateIsReached()
    {
        return currentSlide == sliderDirectionGoal;
    }

    void Start()
    {
        slider = GameObject.Find(slider.name);

        UpTrigger = GameObject.Find(UpTrigger.name);
        DownTrigger = GameObject.Find(DownTrigger.name);

        UpTrigger.GetComponent<OnTouchBehavior>().objectHit += SliderUpGoal_objectHit;
        DownTrigger.GetComponent<OnTouchBehavior>().objectHit += SliderDownGoal_objectHit;
    }

    private void SliderDownGoal_objectHit(object sender, EventArgs e)
    {
        
            currentSlide = SliderDir.DOWN;
        
    }

    private void SliderUpGoal_objectHit(object sender, EventArgs e)
    {
        Debug.Log("up hit");
            currentSlide = SliderDir.UP;
        
    }
}
