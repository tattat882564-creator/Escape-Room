using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] string keyID;


    public void Interact(Player player)
    {
        player.AddKey(keyID);
        Destroy(gameObject);
    }
}
