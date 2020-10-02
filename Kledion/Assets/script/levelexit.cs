using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelexit : MonoBehaviour
{
    
    [SerializeField] float LevelLoadDelay = 0.5f;
    //inform collider as a trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        //if touch the collider then start LoadNextLEvel() code
        StartCoroutine(LoadNextLevel());
    }
    IEnumerator LoadNextLevel()    
    {
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        //inform SceneManagement tool 
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //load scene + 1 = next scene 
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
