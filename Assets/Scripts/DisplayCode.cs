using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCode : MonoBehaviour
{
    public TMP_Text displayText;

    private void Awake()
    {
        displayText = GetComponent<TMP_Text>();
    }
    public void UpdateCode(string code)
    {
        displayText.text = code;
    }

    public void ResetDisplay()
    {
        displayText.text = "";
    }
}