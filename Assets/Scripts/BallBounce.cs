using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class BallBounce : MonoBehaviour
{
    public float bouncePower = 3f;
    private float gravity = -9.31f;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 lv = rb.linearVelocity;
        rb.linearVelocity = new Vector3(lv.x, Mathf.Sqrt(-2f * gravity * bouncePower), lv.z);

        if (collision.collider.CompareTag("Win"))
        {
            LevelManager.RestartLevel(true);
            Destroy(gameObject);
        }
        else if (collision.collider.CompareTag("Danger"))
        {
            LevelManager.RestartLevel(false);
            Destroy(gameObject);
        }
    }
}
