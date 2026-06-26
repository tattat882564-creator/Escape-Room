using System.Collections;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI interactText;
    [SerializeField] private TextMeshProUGUI talkingText;

    public void ShowInterText(string text)
    {
        interactText.text = text;
        interactText.gameObject.SetActive(true);
    }

    public void HideInterText()
    {
        interactText.gameObject.SetActive(false);
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
