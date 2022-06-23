using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour
{
    bool isFocus = false;
    bool hasInteracted = false;
    Transform player;
    public float radius = 3f;

    public virtual void Interact() {
        Debug.Log("Interacting with" + " " + transform.name);
    }
    private void Update()
    {
        if (isFocus &&!hasInteracted) {
            float distance = Vector3.Distance(player.position, transform.position);
                if (distance <= radius) {
                Interact();
                hasInteracted = true;
            }
        }
    }
    private void OnDrawGizmosSelected() {      
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    public void OnFocused(Transform playerTransform) {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }
    public void OnDeFocused() {
        isFocus = false; ;
        player = null;
        hasInteracted = false;
    }
}

