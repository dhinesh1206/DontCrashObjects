using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnenmyMovement : MonoBehaviour 
{
    public Transform[] currentwavepath;
    public List<WayPoints> pathnodes;
    public float pathPercentage;
    public float initialPercentage;
    public float speedmultiplier;
    public float nextenemycreationpercentage;
    public bool nextcalled,child1called = false,child2called = false,child3called = false,child4called= false;
    public int enemyNumber;
    public Transform gameCreator;

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
        if(enemyNumber == 1) 
        {
            if( pathPercentage > 0.1f && !child1called) {
                child1called = true;
                GameEvents.instance.FollowEnemy(1, 0,pathnodes, currentwavepath );
            }
            if(pathPercentage > 0.2f && !child2called) {
                child2called = true;
                GameEvents.instance.FollowEnemy(1, 1,pathnodes, currentwavepath);
            }

        }
        if(enemyNumber == 2) 
        {
            if(pathPercentage > 0.03f && !child1called) 
            {
                child1called = true;
                GameEvents.instance.FollowEnemy(2, 0, pathnodes, currentwavepath);
            }
            if(pathPercentage > 0.06f && !child2called)
            {
                child2called = true;
                GameEvents.instance.FollowEnemy(2, 1, pathnodes, currentwavepath);
            }
            if (pathPercentage > 0.09f && !child3called)
            {
                child3called = true;
                GameEvents.instance.FollowEnemy(2, 2, pathnodes, currentwavepath);
            }
           
        }
	}
}
