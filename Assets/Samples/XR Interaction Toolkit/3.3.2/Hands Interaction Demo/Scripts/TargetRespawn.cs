
using UnityEngine;
using System.Collections;

public class TargetRespawn : MonoBehaviour
{
    private Renderer targetRenderer;
    private Collider targetCollider;

    public float respawnTime = 3f;

    private bool isRespawning = false;

    private void Start()
    {
        targetRenderer = GetComponent<Renderer>();
        targetCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet") && !isRespawning)
        {
            Destroy(other.gameObject);
            StartCoroutine(RespawnTarget());
        }
    }

    private IEnumerator RespawnTarget()
    {
        isRespawning = true;

        targetRenderer.enabled = false;
        targetCollider.enabled = false;

        yield return new WaitForSeconds(respawnTime);

        targetRenderer.enabled = true;
        targetCollider.enabled = true;

        isRespawning = false;
    }
}

