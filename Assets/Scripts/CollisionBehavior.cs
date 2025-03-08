using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionBehavior : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Collider":
                Debug.Log("Hit!!");
                ReloadLevel();
                break;
            case "Finish":
                Debug.Log("Finish");
                LoadNextLevel();
                break;
            default:
                Debug.Log("You crashed dummy");
                break;
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
}
