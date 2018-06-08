using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour 
{
    public static GameEvents instance;
    public delegate void ParameterlessDelegate();
    public event ParameterlessDelegate onGameStart,onPlayerSwitch,onEnemyCreation;

    public delegate void FollowEnemyDelegate(int enemynumber, int followenemynumber, List<WayPoints> pathnodes, Transform[] currentwaypath);
    public event FollowEnemyDelegate onEnemyFollow;

    private void Awake()
    {
        instance = this;
    }

    public void GameStart() 
    {
        if (onGameStart != null) 
        {
            onGameStart();
        }   
    }

    public void PlayerSwitch() 
    {
        if(onPlayerSwitch != null) 
        {
            onPlayerSwitch();
        }  
    }

    public void EnemyCreation() 
    {
        if(onEnemyCreation != null) 
        {
            onEnemyCreation();
        }
    }

    public void FollowEnemy(int enemynumber, int followenemynumber, List<WayPoints> pathnodes, Transform[] currentwaypath) {
        if(onEnemyFollow != null){
            onEnemyFollow(enemynumber, followenemynumber , pathnodes, currentwaypath);
        }
    }
}
