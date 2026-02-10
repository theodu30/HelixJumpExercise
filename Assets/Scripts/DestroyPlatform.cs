using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{
    public GameObject DestroyParticle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (DestroyParticle)
            {
                Instantiate(DestroyParticle, transform.parent.position, Quaternion.identity);
            }
            Destroy(transform.parent.gameObject);
        }
    }
}
