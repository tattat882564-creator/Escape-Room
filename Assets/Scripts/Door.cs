using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] bool isOpen;
    [SerializeField] bool isUnlocked;
    [SerializeField] string requiredKeyID;
    [SerializeField] float rotationSpeed = 6;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip openSound;
    [SerializeField] AudioClip closeSound;

    Quaternion openRotation;
    Quaternion closedRotation;

    private void Start()
    {
        closedRotation = transform.rotation;

        openRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 90, 0));
    }

    private void Update()
    {
        Quaternion targetRotation = isOpen ? openRotation : closedRotation;

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public void Interact()
    {
        if (isUnlocked)
        {
            isOpen = !isOpen;

            if (isOpen)
            {
                audioSource.PlayOneShot(openSound);
            }
            else
            {
                audioSource.Stop();
                audioSource.PlayOneShot(closeSound);
            }
        }
    }
    

    public bool IsUnlocked(Player player)
    {
        isUnlocked = player.HasKey(requiredKeyID);
        return isUnlocked;
    }
}
