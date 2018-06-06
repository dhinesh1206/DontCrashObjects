using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    public Transform parent;
    public GameObject enemyPrefab;
    public List<Transform> waypoints;

    private void Start()
    {
        OnEnemyCreation();
    }

    private void OnEnable()
    {
        GameEvents.instance.onEnemyCreation += OnEnemyCreation;
    }

    private void OnDisable()
    {
        GameEvents.instance.onEnemyCreation -= OnEnemyCreation;
    }

    void OnEnemyCreation()
    {
        GameObject createdObject = Instantiate(enemyPrefab, parent,false);
        createdObject.GetComponent<EnenmyMovement>().currentwavepath = GetMyRoute(createdObject.GetComponent<EnenmyMovement>().path);
        createdObject.GetComponent<EnenmyMovement>().speedmultiplier = 50;
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
}

[System.Serializable]
public class Waypaths 
{
    public string pathName;
    public List<int> waypoints;
}
