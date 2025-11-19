using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FactorialNumber : MonoBehaviour
{
    public int currentValue = 3;   // starting number
    private TMP_Text textComponent;

    void Start()
    {
        textComponent = GetComponent<TMP_Text>();
        UpdateText();
    }

    public void ApplyFactorial()
    {
        currentValue = Factorial(currentValue);
        UpdateText();
    }

    int Factorial(int n)
    {
        int result = 1;
        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }

    void UpdateText()
    {
        textComponent.text = currentValue.ToString();
    }
}
