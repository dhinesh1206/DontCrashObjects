using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnenmyMovement : MonoBehaviour 
{
    public Transform[] currentwavepath;
    public float pathPercentage;
    public float initialPercentage;
    public float speedmultiplier;
    public float nextenemycreationpercentage;
    public bool nextcalled;
    public int enemyNumber;
    public Transform lookAtTransform;

	void Start () 
    {
        pathPercentage = initialPercentage;
	}
	
	void Update () 
    {
        pathPercentage += (speedmultiplier / 10 * Time.deltaTime) / currentwavepath.Length;
        iTween.PutOnPath(gameObject, currentwavepath, pathPercentage);
        if(pathPercentage >1 ) 
        {
            Destroy(gameObject);
        }
        if(lookAtTransform)
        {
            transform.LookAt(lookAtTransform);
        }
        if(pathPercentage > nextenemycreationpercentage/100 && enemyNumber != 0) 
        {
            if(nextcalled == false) 
            {
                nextcalled = true;
                GameEvents.instance.EnemyCreation();
            }
        }
    }
}
