using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public int score;
    public Text scoreText;

    private void OnEnable()
    {
        GameEvents.instance.OnScoreAdd += OnScoreAdd;
        GameEvents.instance.OnPlayerDeath += OnPlayerDeath;
    }

    private void OnDisable()
    {
        GameEvents.instance.OnScoreAdd -= OnScoreAdd;
        GameEvents.instance.OnPlayerDeath += OnPlayerDeath;
    }

    private void OnScoreAdd(Collider other)
    {
        score += 1;
        scoreText.text = score.ToString();
    }

    private void OnPlayerDeath(Collider other)
    {
        score = 0;
        scoreText.text = score.ToString();
    }

}
