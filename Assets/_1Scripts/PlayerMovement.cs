using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    public Transform[] outerWayPoints, innerWayPoints,currentWayPoint,middleWayaPoint;
    public bool playing, LeftSide, RightSide;
    public iTween.EaseType easeType;
    public float pathPercentage, initialPathPercent, speedMultiplier, nextPathDistance, newPercentage, nextInnerPathDistance, nextOuterPathDistance,dashTime, nextmiddlePathDistance;
    public Vector3 pointonPath,pointonNextPath;
    public int score, currentLaneIndex;

    private void OnEnable()
    {
        GameEvents.instance.OnGameStart += StartGame;
        GameEvents.instance.OnScoreAdd += OnScoreAdd;
        GameEvents.instance.OnPlayerLeft += OnPlayerLeft;
        GameEvents.instance.OnPlayerRight += OnPlayerRight;
        GameEvents.instance.OnPlayerDeath += OnPlayerDeath;
    }

    private void OnDisable()
    {
        GameEvents.instance.OnGameStart -= StartGame;
        GameEvents.instance.OnScoreAdd -= OnScoreAdd;
        GameEvents.instance.OnPlayerLeft -= OnPlayerLeft;
        GameEvents.instance.OnPlayerRight -= OnPlayerRight;
        GameEvents.instance.OnPlayerDeath += OnPlayerDeath;
    }

    void StartGame () 
    {
        playing = true;
        RightSide = true;
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

    private void OnPlayerDeath(Collider other)
    {
        playing = false;
    }

    public void OnPlayerRight()
    {
        if (LeftSide)
        {
            if(currentWayPoint == outerWayPoints)
            {
                playing = false;
                iTween.Stop(gameObject);
                pointonPath = iTween.PointOnPath(currentWayPoint, pathPercentage);
                newPercentage = pathPercentage + nextmiddlePathDistance;
                pointonNextPath = iTween.PointOnPath(middleWayaPoint, newPercentage);
                currentWayPoint = middleWayaPoint;
                iTween.MoveTo(gameObject, iTween.Hash("position", pointonNextPath, "time", (speedMultiplier / 10 * Time.deltaTime) / currentWayPoint.Length, "easetype", easeType, "oncomplete", "PathSwitched"));
            }
            else if( currentWayPoint ==  middleWayaPoint)
            {
                playing = false;
                iTween.Stop(gameObject);
                pointonPath = iTween.PointOnPath(currentWayPoint, pathPercentage);
                newPercentage = pathPercentage + nextInnerPathDistance;
                pointonNextPath = iTween.PointOnPath(innerWayPoints, newPercentage);
                currentWayPoint = innerWayPoints;
                iTween.MoveTo(gameObject, iTween.Hash("position", pointonNextPath, "time", (speedMultiplier / 10 * Time.deltaTime) / currentWayPoint.Length, "easetype", easeType, "oncomplete", "PathSwitched"));
            }
        }
        else if(RightSide)
        {
            if (currentWayPoint == innerWayPoints)
            {
                playing = false;
                iTween.Stop(gameObject);
                pointonPath = iTween.PointOnPath(currentWayPoint, pathPercentage);
                newPercentage = pathPercentage + nextmiddlePathDistance;
                pointonNextPath = iTween.PointOnPath(middleWayaPoint, newPercentage);
                currentWayPoint = middleWayaPoint;
                iTween.MoveTo(gameObject, iTween.Hash("position", pointonNextPath, "time", (speedMultiplier / 10 * Time.deltaTime) / currentWayPoint.Length, "easetype", easeType, "oncomplete", "PathSwitched"));
            }
            else if (currentWayPoint == middleWayaPoint)
            {
                playing = false;
                iTween.Stop(gameObject);
                pointonPath = iTween.PointOnPath(currentWayPoint, pathPercentage);
                newPercentage = pathPercentage + nextInnerPathDistance;
                pointonNextPath = iTween.PointOnPath(outerWayPoints, newPercentage);
                currentWayPoint = outerWayPoints;
                iTween.MoveTo(gameObject, iTween.Hash("position", pointonNextPath, "time", (speedMultiplier / 10 * Time.deltaTime) / currentWayPoint.Length, "easetype", easeType, "oncomplete", "PathSwitched"));
            }
        }
    }

    public void OnPlayerLeft()
    {
        if (LeftSide)
        {
            if (currentWayPoint == innerWayPoints)
            {
                playing = false;
                iTween.Stop(gameObject);
                pointonPath = iTween.PointOnPath(currentWayPoint, pathPercentage);
                newPercentage = pathPercentage + nextmiddlePathDistance;
                pointonNextPath = iTween.PointOnPath(middleWayaPoint, newPercentage);
                currentWayPoint = middleWayaPoint;
                iTween.MoveTo(gameObject, iTween.Hash("position", pointonNextPath, "time", (speedMultiplier / 10 * Time.deltaTime) / currentWayPoint.Length, "easetype", easeType, "oncomplete", "PathSwitched"));
            }
            else if (currentWayPoint == middleWayaPoint)
            {
                playing = false;
                iTween.Stop(gameObject);
                pointonPath = iTween.PointOnPath(currentWayPoint, pathPercentage);
                newPercentage = pathPercentage + nextInnerPathDistance;
                pointonNextPath = iTween.PointOnPath(outerWayPoints, newPercentage);
                currentWayPoint = outerWayPoints;
                iTween.MoveTo(gameObject, iTween.Hash("position", pointonNextPath, "time", (speedMultiplier / 10 * Time.deltaTime) / currentWayPoint.Length, "easetype", easeType, "oncomplete", "PathSwitched"));
            }
        }
        else if (RightSide)
        {
            if (currentWayPoint == outerWayPoints)
            {
                playing = false;
                iTween.Stop(gameObject);
                pointonPath = iTween.PointOnPath(currentWayPoint, pathPercentage);
                newPercentage = pathPercentage + nextmiddlePathDistance;
                pointonNextPath = iTween.PointOnPath(middleWayaPoint, newPercentage);
                currentWayPoint = middleWayaPoint;
                iTween.MoveTo(gameObject, iTween.Hash("position", pointonNextPath, "time", (speedMultiplier / 10 * Time.deltaTime) / currentWayPoint.Length, "easetype", easeType, "oncomplete", "PathSwitched"));
            }
            else if (currentWayPoint == middleWayaPoint)
            {
                playing = false;
                iTween.Stop(gameObject);
                pointonPath = iTween.PointOnPath(currentWayPoint, pathPercentage);
                newPercentage = pathPercentage + nextInnerPathDistance;
                pointonNextPath = iTween.PointOnPath(innerWayPoints, newPercentage);
                currentWayPoint = innerWayPoints;
                iTween.MoveTo(gameObject, iTween.Hash("position", pointonNextPath, "time", (speedMultiplier / 10 * Time.deltaTime) / currentWayPoint.Length, "easetype", easeType, "oncomplete", "PathSwitched"));
            }
        }
    }

    private void OnScoreAdd(Collider other)
    {
        score += 1;
    }

    private void OnDrawGizmos()
    {
        iTween.DrawPath(outerWayPoints);
        iTween.DrawPath(innerWayPoints);
        iTween.DrawPath(middleWayaPoint);
    }

    void PathSwitched() 
    {
        pathPercentage = newPercentage;
        playing = true;
    }
}
