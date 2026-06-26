using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPoint : MonoBehaviour
{
    [SerializeField] GameObject playerController;
    [SerializeField] GameObject fadeOut;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerController.GetComponent<Player>().enabled = false;
            fadeOut.SetActive(true);
            StartCoroutine(AfterWin());
        }
    }

    IEnumerator AfterWin()
    {
        yield return new WaitForSeconds(3);
        
        SceneManager.LoadScene("MainMenu");
    }
}
