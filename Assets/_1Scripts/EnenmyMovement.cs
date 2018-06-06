using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnenmyMovement : MonoBehaviour 
{
    public Transform[] currentwavepath;
    public List<int> path;
    public float pathPercentage;
    public float initialPercentage;
    public float speedmultiplier;
    public float nextenemycreationpercentage;
    public bool nextcalled;

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
        if(pathPercentage > nextenemycreationpercentage/100) 
        {
            if(nextcalled == false) 
            {
                nextcalled = true;
                GameEvents.instance.EnemyCreation();
            }
        }
	}
}
