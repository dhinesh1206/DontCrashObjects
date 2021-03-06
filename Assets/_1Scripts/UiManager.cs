﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour 
{
    public GameObject gameoverScreen,mainScreen,PlayerScreen;

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
        PlayerScreen.SetActive(false);
        StartCoroutine(DeathScreen());
    }

    IEnumerator DeathScreen()
    {
        yield return new WaitForSeconds(1.5f);
        gameoverScreen.SetActive(true);
    }

    public void StartGame() 
    {
        mainScreen.SetActive(false);
        PlayerScreen.SetActive(true);
        Time.timeScale = 1;
        GameEvents.instance.GameStart();
    }

    public void Restart()
    {
        gameoverScreen.SetActive(false);
        SceneManager.LoadScene("Scene1", LoadSceneMode.Single);
    }
}