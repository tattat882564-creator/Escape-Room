using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ShowArrow : MonoBehaviour
{
    [SerializeField] DecalProjector showArrow;
    [SerializeField] DecalProjector showText;

    private void Start()
    {
        showArrow.enabled = false;
        showText.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (showArrow != null && showText != null)
            {
                showArrow.enabled = true;
                showText.enabled = true;
            }
        }
    }
}
