using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{

    int score = 0;

    // Setup for Singleton pattern
    static ScoreKeeper instance;

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        // If the instance is already assigned, we can destroy this newly created instance
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        // This instance doesn't exist, create it and tell Unity not to destroy it on load
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void ModifyScore(int value)
    {
        score = Mathf.Clamp(score += value, 0, int.MaxValue);
    }

    public void ResetScore()
    {
        score = 0;
    }
}
