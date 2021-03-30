using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonContinue : MonoBehaviour
{
    // Asks the SceneManager to load the scene at index 0
    // Based on File -> Build Settings -> "Scenes In Build"
    public void Reset()
    {
        SceneManager.LoadScene(0);
    }

    // Asks the SceneManager to load the scene with the specific name of "Level1_A"
    public void Sublevel()
    {
        SceneManager.LoadScene("Level1_A", LoadSceneMode.Single);
    }
}
