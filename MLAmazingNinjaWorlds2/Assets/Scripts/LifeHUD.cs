using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeHUD : MonoBehaviour
{
    // create a reference for the hearts in the UI
    private GameObject[] hearts;
    // give Codey three lives
    private int lives = 3;
    // get a reference to the background object
    public GameObject background;

    public void Awake()
    {
        // find the game objects with the "heart" tag and store them in the hearts array
        hearts = GameObject.FindGameObjectsWithTag("heart");
        // if the player has lives, load that data and refresh the HUD
        if (PlayerPrefs.HasKey("LIVES_LEFT"))
        {
            lives = PlayerPrefs.GetInt("LIVES_LEFT");
            HUDRefresh();
        }

    }

    // if a player gets hurt, remove a life
    // save how many lives they have
    // and refresh the HUD
    public void HurtPlayer()
    {
        lives -= 1;
        saveData();
        HUDRefresh();
    }

    public void HUDRefresh()
    {
        // loop through each heart
        for (int heart = 0; heart < hearts.Length; heart++)
        {
            // if the heart index is less than the number of lives
            // then activate the heart
            if (heart < lives)
            {
                hearts[heart].SetActive(true);
            }
            // if the heart index is greater than or equal to the number of lives
            // disable the heart
            else
            {
                hearts[heart].SetActive(false);
            }
        }
        // if there are no more lives, display the game over screen
        if (lives <= 0)
        {
            background.GetComponent<GameManager>().GameOver();
        }
        
    }

    // save how many lives the player has left
    // this is used to preserve the number of lives across scenes
    public void saveData()
    {
        PlayerPrefs.SetInt("LIVES_LEFT", lives);
    }
}
