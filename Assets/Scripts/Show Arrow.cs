using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ShowArrow : MonoBehaviour
{
    [SerializeField] DecalProjector showArrow;

    private void Start()
    {
        showArrow.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            showArrow.enabled = true;
        }
    }
}
