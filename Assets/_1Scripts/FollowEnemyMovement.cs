using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemyMovement : MonoBehaviour {

    public Transform[] currentwavepath;
    public List<WayPoints> pathnodes;
    public float pathPercentage;
    public float speedmultiplier;
    public float initialPercentage;

    private void Start()
    {
        pathPercentage = initialPercentage; 
    }

    private void Update()
    {
        pathPercentage += (speedmultiplier / 10 * Time.deltaTime) / currentwavepath.Length;
        iTween.PutOnPath(gameObject, currentwavepath, pathPercentage);
        if(pathPercentage > 1) {
            Destroy(gameObject);
        }
    }
}
