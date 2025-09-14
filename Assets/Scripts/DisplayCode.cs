using UnityEngine;
using UnityEngine.UI;

public class DisplayCode : MonoBehaviour
{
    public Text displayText;

    public void UpdateCode(string code)
    {
        displayText.text = code;
    }
}