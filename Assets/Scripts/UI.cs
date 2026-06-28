using System.Collections;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject interactCrosshair;
    [SerializeField] private TextMeshProUGUI talkingText;

    public void ShowInterCrosshair()
    {
        interactCrosshair.SetActive(true);
    }

    public void HideInterText()
    {
        interactCrosshair.SetActive(false);
    }

    public void ShowTalkText(string text) 
    {
        talkingText.text = text;
        talkingText.gameObject.SetActive(true);

        StopAllCoroutines();
        StartCoroutine(HideTalkTextAfterTime());
    }

    IEnumerator HideTalkTextAfterTime()
    {
        yield return new WaitForSeconds(5f);
        talkingText.gameObject.SetActive(false);
    }
}
