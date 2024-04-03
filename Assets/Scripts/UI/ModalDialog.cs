using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModalDialog : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;
    public TextMeshProUGUI text;

    private Action<int> callback;

    public void Show(Action<int> callback, string message, string button1text, string button2text = null, string button3text = null)
    {
        gameObject.SetActive(true);
        text.text = message;
        SetButtonText(button1, button1text);
        SetButtonText(button2, button2text);
        SetButtonText(button3, button3text);
        this.callback = callback;
    }

    private void SetButtonText(Button button, string text)
    {
        if (text == null)
        {
            button.gameObject.SetActive(false);
            return;
        }

        button.gameObject.SetActive(true);
        button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = text;
    }

    public void OnButtonClicked(int buttonNumber)
    {
        gameObject.SetActive(false);
        callback(buttonNumber);
    }
}
