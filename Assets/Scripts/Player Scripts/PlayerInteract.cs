using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] UI ui;
    [SerializeField] CreepyGhostGirl ghostScript;
    [SerializeField] float interactDistance = 2f;
    [SerializeField] GameObject ghostShadowTrigger;
    
    
    DoorHandle currentHandle;
    Key currentKey;

    private void Start()
    {
        if (ghostShadowTrigger != null)
        {
            ghostShadowTrigger.SetActive(false);
        }
    }

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
                ui.ShowInterCrosshair();
                return;
            }

            if (hit.collider.TryGetComponent(out Key key))
            {
                currentKey = key;
                ui.ShowInterCrosshair();
                return;
            }
            //if (hit.collider.TryGetComponent(out TriggerEvent trigger))
            //{
            //    if (ghostScript != null)
            //    {
            //        ghostScript.RoomBShadow();
            //        return;
            //    }
            //    else
            //    {
            //        if (ghostShadowTrigger != null)
            //        {
            //            ghostShadowTrigger.SetActive(false);
            //        }
            //    }
            //    return;
            //}
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
            if (ghostShadowTrigger != null)
            {
                ghostShadowTrigger.SetActive(true);
            }
    }
    }
}