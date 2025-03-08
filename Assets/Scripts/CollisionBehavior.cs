using UnityEngine;

public class CollisionBehavior : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Collider":
                Debug.Log("Hit!!");
                break;
            case "Finish":
                Debug.Log("Finish");
                break;
            default:
                Debug.Log("You crashed dummy");
                break;
        }
    }
}
