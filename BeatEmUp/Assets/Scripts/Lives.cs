using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{

    [SerializeField]
    private int maxLives = 3;
    [SerializeField]
    private int minLives = 0;
    [SerializeField]
    private int currentLives;
    [SerializeField]
    private Text livesText;
    public int MaxLives
    {
        get
        {
            return maxLives;
        }
        
    }
    public int CurrentLives
    {
        get
        {
            return currentLives;
        }
        set
        {
            currentLives = value;
        }
    }
    public Text LivesText
    {
        get
        {
            return livesText;
        }
        set
        {
            livesText = value;
        }
    }

    void Awake()
    {
        currentLives = maxLives;
        livesText.text = "x" + currentLives.ToString();
       
    }

    public void GameOver()
    {
        if(currentLives <= minLives)
        {
            Debug.Log("GAME OVER!");
        }
    }
    public void LoseLife()
    {
        currentLives--;
       if(CurrentLives <= minLives)
        {
            currentLives = minLives;
            GameOver();
        }
        livesText.text = "x" + currentLives.ToString();
    }
    public void AddLife()
    {
        currentLives++;
        if(currentLives >= maxLives)
        {
            currentLives = maxLives;
        }
        livesText.text = "x" + currentLives.ToString();
    }


}
