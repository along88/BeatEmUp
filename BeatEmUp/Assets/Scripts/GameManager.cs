using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public float currentHealth;
    public float maxHealth = 100.0f;
    public int currentLives;
    public int maxLives = 3;

   

    private GameManager()
    {

    }
    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }


    
}
