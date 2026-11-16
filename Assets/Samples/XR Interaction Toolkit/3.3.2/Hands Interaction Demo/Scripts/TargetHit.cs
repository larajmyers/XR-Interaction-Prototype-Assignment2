
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class TargetHit : MonoBehaviour
{
    private XRSimpleInteractable interactable;
    private AudioSource audioSource;

    void Awake()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        audioSource = GetComponent<AudioSource>();

        interactable.selectEntered.AddListener(OnHit);
    }

    void OnHit(SelectEnterEventArgs args)
    {
        if (audioSource != null && audioSource.clip != null)
        {
            AudioSource.PlayClipAtPoint(
                audioSource.clip,
                transform.position
            );
        }

        gameObject.SetActive(false);
    }

    void OnDestroy()
    {
        if (interactable != null)
            interactable.selectEntered.RemoveListener(OnHit);
    }
}

