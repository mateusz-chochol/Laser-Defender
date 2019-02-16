using UnityEngine;

public class Asteroid : MonoBehaviour {

    private Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();

        rb.AddForce(Vector3.back * 100);
        rb.MoveRotation(Random.rotation);
    }
}
