using UnityEngine;

public class CreepyGhostGirl : MonoBehaviour
{
    [SerializeField] Animator animator;
    void Start()
    {
        animator.enabled = false;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RoomBShadow()
    {
        if (animator != null) 
        {
            gameObject.SetActive(true);

            animator.enabled = true;
            animator.Play("RoomBGhostCross");
            Destroy(gameObject, 1f);
        }
    }
}
