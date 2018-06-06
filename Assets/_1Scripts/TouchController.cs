using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HedgehogTeam.EasyTouch;

public class TouchController : MonoBehaviour 
{
    private void OnEnable()
    {
        EasyTouch.On_SimpleTap += On_SimpleTap;
    }

    private void OnDisable()
    {
        EasyTouch.On_SimpleTap -= On_SimpleTap;
    }

    void On_SimpleTap(Gesture gesture)
    {
        GameEvents.instance.PlayerSwitch();
    }

}
