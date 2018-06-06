using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    public Transform[] outerWayPoints, innerWayPoints,currentWayPoint;
    public bool playing;
    public iTween.EaseType easeType;
    public float pathPercentage, initialPathPercent, speedMultiplier, nextPathDistance, newPercentage;
    public Vector3 pointonPath,pointonNextPath;

    private void OnEnable()
    {
        GameEvents.instance.onGameStart += StartGame;
        GameEvents.instance.onPlayerSwitch += SwitchLanes;
    }

    private void OnDisable()
    {
        GameEvents.instance.onGameStart -= StartGame;
        GameEvents.instance.onPlayerSwitch -= SwitchLanes;
    }

    void StartGame () 
    {
        playing = true;
        currentWayPoint = outerWayPoints;
        pathPercentage = initialPathPercent;
    }
	
	void Update () 
    {
        if(playing == true) 
        {
            pathPercentage += (speedMultiplier / 10 *Time.deltaTime) / outerWayPoints.Length;
            iTween.PutOnPath(gameObject, currentWayPoint, pathPercentage);
            if(pathPercentage > 1) 
            {
                pathPercentage = 0;
            }
        }
	}

    private void OnDrawGizmos()
    {
        iTween.DrawPath(outerWayPoints);
        iTween.DrawPath(innerWayPoints);
    }
    public void SwitchLanes() 
    {
        playing = false;
        iTween.Stop(gameObject);
        pointonPath = iTween.PointOnPath(currentWayPoint,pathPercentage);
        newPercentage = pathPercentage + nextPathDistance;
        if(currentWayPoint == outerWayPoints) 
        {
            pointonNextPath = iTween.PointOnPath(innerWayPoints, newPercentage);
            currentWayPoint = innerWayPoints;
        } else 
        {
            pointonNextPath = iTween.PointOnPath(outerWayPoints, newPercentage);
            currentWayPoint = outerWayPoints;
        }
        iTween.MoveTo(gameObject, iTween.Hash("position", pointonNextPath, "time", speedMultiplier/10*Time.deltaTime, "easetype", easeType,"oncomplete","PathSwitched"));
    }

    void PathSwitched() 
    {
        pathPercentage = newPercentage;
        playing = true;
    }
}
