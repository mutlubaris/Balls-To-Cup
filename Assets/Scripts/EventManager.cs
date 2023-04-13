using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    public static BallThrowEvent onAllBallsThrown = new BallThrowEvent();

    public class BallThrowEvent : UnityEvent<int> { }
}
