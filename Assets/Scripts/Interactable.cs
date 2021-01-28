
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 5f;

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
