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
    public float score;
    public Transform[] currentwaypath;

    private void Start()
    {
      
    }

    private void OnEnable()
    {
        GameEvents.instance.OnGameStart += OnGameStart;
        GameEvents.instance.OnEnemyCreation += OnEnemyCreation;
    }

    private void OnDisable()
    {
        GameEvents.instance.OnGameStart -= OnGameStart;
        GameEvents.instance.OnEnemyCreation -= OnEnemyCreation;
    }

    private void OnGameStart()
    {
        OnEnemyCreation();
    }

    void OnEnemyCreation()
    {
        GameObject createdObject = Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], parent, false);
        if(score < 30)
        {
            int index = Random.Range(0, createdObject.GetComponent<EnemyPathNodes>().pathnodes.Count);
            currentwaypath = GetMyRoute(createdObject.GetComponent<EnemyPathNodes>().pathnodes[index].path);
            foreach (Transform enemy in createdObject.transform)
            {
                foreach (EnenmyMovement obj in enemy.gameObject.GetComponentsInChildren<EnenmyMovement>())
                {
                    obj.currentwavepath = currentwaypath;
                }
            }
        } else if ( score >= 30)
        {
            foreach (Transform enemy in createdObject.transform)
            {
                int index = Random.Range(0, createdObject.GetComponent<EnemyPathNodes>().pathnodes.Count);
                currentwaypath = GetMyRoute(createdObject.GetComponent<EnemyPathNodes>().pathnodes[index].path);
                currentwaypath = GetMyRoute(createdObject.GetComponent<EnemyPathNodes>().pathnodes[index].path);
                foreach (EnenmyMovement obj in enemy.gameObject.GetComponentsInChildren<EnenmyMovement>())
                {
                    obj.currentwavepath = currentwaypath;
                }
            }
        }
       
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

