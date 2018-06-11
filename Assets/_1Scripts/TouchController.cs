using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HedgehogTeam.EasyTouch;

public class TouchController : MonoBehaviour 
{
   public void LeftClick()
    {
        GameEvents.instance.LeftSidePressed();
    }

    public void RightClick()
    {
        GameEvents.instance.RightSidePressed();
    }
}
