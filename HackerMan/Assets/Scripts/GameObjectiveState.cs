using UnityEngine;
using System.Collections;
using System;

abstract public class GameObjectiveState : MonoBehaviour {

    public abstract bool CheckIfStateIsReached();
}



abstract public class GoalState : GameObjectiveState { }



abstract public class FailState : GameObjectiveState { }



