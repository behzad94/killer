using UnityEngine;
using UnityEngine.Audio;

public class Explosion : MonoBehaviour
{
    [SerializeField] float radius = 5f;
    [SerializeField] int damage = 3;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Explode();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void Explode()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        Debug.Log("Explode");
        audioSource.Play();
        foreach (Collider hitCollider in hitColliders)
        {
            PlayerHealth playerHealth = hitCollider.GetComponent<PlayerHealth>();
            Debug.Log(playerHealth + "playerHealth");
            if (!playerHealth) continue;
            playerHealth.TakeDamage(damage);
            break;
        }
    }
}