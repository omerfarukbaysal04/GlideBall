using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextDisplayManager : MonoBehaviour
{
    public List<string> messages;
    public TextMeshProUGUI uiText;
    private int currentIndex = 0;

    public void ShowNextMessages()
    {
        if (currentIndex < messages.Count)
        {
            uiText.text = messages[currentIndex];
            currentIndex++;
        }
    }
}
