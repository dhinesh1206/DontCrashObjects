using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour {

    public GameObject glassCrackPrefab ;
    public Transform crackParent;
    bool cubecracked;

    private void OnEnable()
    {
        GameEvents.instance.OnPlayerDeath += OnPlayerDeath;
    }

    private void OnDisable()
    {
        GameEvents.instance.OnPlayerDeath -= OnPlayerDeath;
    }

    private void OnPlayerDeath(Collider other)
    {
        if (!cubecracked)
        {
            cubecracked = true;
            print(other.transform.GetComponentInParent<Transform>().position);
            crackParent.transform.position = other.transform.GetComponentInParent<Transform>().position;
            GameObject crack = Instantiate(glassCrackPrefab, crackParent, false);
            crack.transform.localScale = new Vector3(5, 5, 5);
            crack.transform.SetParent(null);
            crack.transform.position = new Vector3(crack.transform.position.x, crack.transform.position.y, 0);
        }
    }
}
