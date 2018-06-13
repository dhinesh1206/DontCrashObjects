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
    public int score,enemyPrefabCount;
    public Transform[] currentwaypath;


    private void Start()
    {
      
    }

    private void OnEnable()
    {
        GameEvents.instance.OnGameStart += OnGameStart;
        GameEvents.instance.OnEnemyCreation += OnEnemyCreation;
        GameEvents.instance.OnScoreAdd += OnScoreAdd;
    }

    private void OnDisable()
    {
        GameEvents.instance.OnGameStart -= OnGameStart;
        GameEvents.instance.OnEnemyCreation -= OnEnemyCreation;
        GameEvents.instance.OnScoreAdd -= OnScoreAdd;
    }

    private void OnScoreAdd(Collider other)
    {
        score += 1;
        if(score == 2)
        {
            enemyPrefabCount += 1;
        }
        if(score == 4)
        {
            enemyPrefabCount += 1;
        }
        if(score == 8)
        {
            enemyPrefabCount += 1;
        }
        if(score == 12)
        {
            enemyPrefabCount += 1;
        }
        //if(score == 15)
        //{
        //    enemyPrefabCount += 1;
        //}
        //if(score == 18)
        //{
        //    enemyPrefabCount += 1;
        //}
        //if (score == 20)
        //{
        //    enemyPrefabCount += 1;
        //}
    }

    private void OnGameStart()
    {
        OnEnemyCreation();
    }

    void OnEnemyCreation()
    {
        GameObject createdObject = Instantiate(enemyPrefab[Random.Range(0, enemyPrefabCount)], parent, false);
        if(score < 20)
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
        } else if ( score >= 20)
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

