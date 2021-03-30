using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // References for UI elements
    public GameObject popUp;
    public TextMeshProUGUI textMessage;
    public GameObject retryButton;
    public TextMeshProUGUI buttonText;

    // Reference to Codey
    public GameObject player;

    // A reference to a checkpoint with an initial value of the start of the level
    public Vector3 checkPoint = new Vector3(-4.7f, 0.6f, 0);
    

    void Start()
    {
        // make sure the pop up is not active
        popUp.SetActive(false);

        // delete any previous lives data
        PlayerPrefs.DeleteKey("LIVES_LEFT");
    }

    private void Update()
    {

    }

    // Set the game over text and display the popup
    public void GameOver()
    {
        textMessage.text = "Keep Trying!";
        retryButton.GetComponent<Button>().onClick.AddListener(delegate { Reset("Level1"); });
        buttonText.text = "Click to try again";
        popUp.SetActive(true);
        PlayerPrefs.DeleteKey("LIVES_LEFT");
    }

    // Set the success text and display the popup
    public void TeleportOpen(string nextScene)
    {
        textMessage.text = "Good Job!";
        retryButton.GetComponent<Button>().onClick.AddListener(delegate { Reset(nextScene); });
        buttonText.text = "Click to continue";
        popUp.SetActive(true);
        if(nextScene == "Level1")
        {
            PlayerPrefs.DeleteKey("LIVES_LEFT");
        }
    }

    // teleport the player to the checkpoint
    public void moveToCheckPoint()
    {
        player.transform.position = checkPoint;
    }

    public void UpdateCheckPoint(Vector3 newCheckPoint)
    {
        
    }

    // load the specified scene
    public void Reset(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
