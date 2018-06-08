using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    public Transform parent;
    public GameObject[] enemyPrefab;
    public List<Transform> waypoints;
    public List<FollowEnemyList> enemyfollowLists;

    private void Start()
    {
        OnEnemyCreation();
    }

    private void OnEnable()
    {
        GameEvents.instance.onEnemyCreation += OnEnemyCreation;
        GameEvents.instance.onEnemyFollow += OnEnemyFollow;
    }

    private void OnDisable()
    {
        GameEvents.instance.onEnemyCreation -= OnEnemyCreation;
        GameEvents.instance.onEnemyFollow -= OnEnemyFollow;
    }

    void OnEnemyCreation()
    {
        GameObject createdObject = Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], parent, false);
        createdObject.GetComponent<EnenmyMovement>().currentwavepath = GetMyRoute(createdObject.GetComponent<EnenmyMovement>().pathnodes[Random.Range(0, createdObject.GetComponent<EnenmyMovement>().pathnodes.Count)].path);
    }

    public Transform[] GetMyRoute(List<int> list)
    {
        List<Transform> result = new List<Transform>();
        foreach (int item in list)
        {
            result.Add(waypoints[item]);
        }
        return result.ToArray();
    }

    void OnDrawGizmos()
    {
        foreach (var item in waypoints)
        {
            Handles.Label(item.position, waypoints.IndexOf(item).ToString());
        }
    }

    void OnEnemyFollow(int enemynumber, int followenemynumber, List<WayPoints> pathnodes, Transform[] currentwaYpath)
    {
        foreach (var obj in enemyfollowLists)
        {
            if (enemynumber == obj.enemynumber)
            {
                GameObject createFollowObject = Instantiate(obj.enemyfollow[followenemynumber], parent, false);
                createFollowObject.GetComponent<FollowEnemyMovement>().pathnodes = pathnodes;
                //createFollowObject.GetComponent<FollowEnemyMovement>().currentwavepath = GetMyRoute(createFollowObject.GetComponent<FollowEnemyMovement>().pathnodes[Random.Range(0, createFollowObject.GetComponent<FollowEnemyMovement>().pathnodes.Count)].path);
                createFollowObject.GetComponent<FollowEnemyMovement>().currentwavepath = currentwaYpath;
            }
        }

    }
}



[System.Serializable]
public class Waypaths 
{
    public string pathName;
    public List<int> waypoints;
}


[System.Serializable]
public class WayPoints
{
    public List<int> path;
}

[System.Serializable]
public class FollowEnemyList
{
    public int enemynumber;
    public GameObject[] enemyfollow;
}

