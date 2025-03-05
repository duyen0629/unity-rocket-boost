using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] float thrustStrength = 1000f;
    Rigidbody rb;
    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable() {
        thrust.Enable();
    }

    private void FixedUpdate() {
        if (thrust.IsPressed()) {
            Debug.Log("Pressed");
            rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
        }
    }

}
