using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour 
{
    public static GameEvents instance;
    public delegate void ParameterlessDelegate();
    public event ParameterlessDelegate OnGameStart, OnPlayerSwitch, OnEnemyCreation, OnPlayerLeft,OnPlayerRight;

    public delegate void CollisionDelegate(Collider other);
    public event CollisionDelegate OnPlayerDeath,OnScoreAdd;

    private void Awake()
    {
        instance = this;
    }

    public void GameStart() 
    {
        if (OnGameStart != null) 
        {
            OnGameStart();
        }   
    }

    public void PlayerSwitch() 
    {
        if(OnPlayerSwitch != null) 
        {
            OnPlayerSwitch();
        }  
    }

    public void EnemyCreation() 
    {
        if(OnEnemyCreation != null) 
        {
            OnEnemyCreation();
        }
    }

    public void PlayerDeath(Collider other)
    {
        if(OnPlayerDeath != null)
        {
            OnPlayerDeath(other);
        }
    }

    public void ScoreAdd(Collider other)
    {
        if(OnScoreAdd != null)
        {
            OnScoreAdd(other);
        }
    }
    
    public void LeftSidePressed ()
    {
        if(OnPlayerLeft != null)
        {
            OnPlayerLeft();
        }
    }

    public void RightSidePressed()
    {
        if (OnPlayerRight != null)
        {
            OnPlayerRight();
        }
    }
}
