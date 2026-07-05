using UnityEditor;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    [SerializeField] GameObject[] objectToActive;
    [SerializeField] float[] second;
    [SerializeField] AudioSource audioToPlay;

    bool hasTrigged = false;
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && !hasTrigged)
        {
            hasTrigged = true;
            if (objectToActive != null && objectToActive.Length > 0)
            {
                foreach (GameObject obj in objectToActive)
                {
                    if (obj != null)
                    {
                        obj.SetActive(true);
                        Destroy(objectToActive[0], second[0]);
                    }
                }
            }

            if (audioToPlay != null)
            {
                audioToPlay.Play();
            }

            Destroy(gameObject, 10f);
        }
    }
}
