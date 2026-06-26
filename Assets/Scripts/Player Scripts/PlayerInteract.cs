using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] UI ui;
    [SerializeField] float interactDistance = 2f;
    
    
    DoorHandle currentHandle;
    Key currentKey;

    void Update()
    {
        CheckLook();

        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }

        Debug.DrawRay(transform.position, transform.forward * interactDistance, Color.red);
    }

    void CheckLook()
    {
        currentHandle = null;
        currentKey = null;


        ui.HideInterText();

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, interactDistance))
        {
            if (hit.collider.TryGetComponent(out DoorHandle handle))
            {
                currentHandle = handle;
                ui.ShowInterText("[E] Open Door");
                return;
            }

            if (hit.collider.TryGetComponent(out Key key))
            {
                currentKey = key;
                ui.ShowInterText("[E] Pickup");
                return;
            }
        }
    }

    void TryInteract()
    {
        if (currentHandle != null)
        {
            if (currentHandle.IsUnlocked(player))
            {
                currentHandle.Interact();
            }
            else
            {
                ui.ShowTalkText("Locked! Need Keys");
            }
        }

        if (currentKey != null)
        {
            currentKey.Interact(player);
        }
    }
}