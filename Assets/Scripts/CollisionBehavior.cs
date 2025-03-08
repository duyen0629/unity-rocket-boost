using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionBehavior : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;

    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Collider":
                StartCrashSequence();
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                Debug.Log("You crashed dummy");
                break;
        }


    }

    void StartSuccessSequence()
    {
        Debug.Log("Finish");
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void StartCrashSequence()
    {
        Debug.Log("Hit!!");
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    void LoadNextLevel()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }
        SceneManager.LoadScene(nextScene);
    }
}
