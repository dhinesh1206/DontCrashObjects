using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour {

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
        Time.timeScale = 0;
    }
}
