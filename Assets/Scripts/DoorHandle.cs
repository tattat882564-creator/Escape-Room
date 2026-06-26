using UnityEngine;

public class DoorHandle : MonoBehaviour
{
    [SerializeField] Door door;

    public void Interact()
    {
        door.Interact();
    }

    public bool IsUnlocked(Player player)
    {
        return door.IsUnlocked(player);
    }
    
}
