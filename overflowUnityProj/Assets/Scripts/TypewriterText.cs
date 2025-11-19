using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypewriterText : MonoBehaviour
{
    public TextMeshPro textMeshPro;
    public float typingSpeed = 0.02f;

    public void ShowText(string message)
    {
        Debug.Log("ShowText was called with message: " + message);
        StartCoroutine(TypeText(message));
    }

    private IEnumerator TypeText(string message)
    {
        textMeshPro.text = "";
        foreach (char c in message)
        {
            textMeshPro.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}