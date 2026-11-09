using UnityEditor;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    [SerializeField] GameObject[] objectToActive;
    [SerializeField] CreepyGhostGirl ghostGirl;
    [SerializeField] float[] second;
    [SerializeField] AudioSource audioToPlay;

    bool hasTrigged = false;

    private void Start()
    {
        if (objectToActive != null)
        {
            foreach (GameObject obj in objectToActive) 
            { 
                obj.SetActive(false); 
            }
        }
    }
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
                    }
                }
            }
            if (ghostGirl != null)
            {
                ghostGirl.RoomBShadow();
            }                       

            if (audioToPlay != null)
            {
                audioToPlay.Play();
            }

            Destroy(gameObject, 10f);
        }
    }
}
