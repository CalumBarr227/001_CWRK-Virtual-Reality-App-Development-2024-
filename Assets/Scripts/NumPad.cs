

using UnityEngine;
using UnityEngine.UI;

public class NumPad : MonoBehaviour
{
    public string[] correctSequence = { "1", "2", "3", "4" }; 
    public Transform keycardSpawnLocation; 
    public GameObject keycardPrefab; 
    public DisplayCode displayCode; 

    private string enteredNumber = ""; 

 
    private void UpdateCodeDisplay()
    {
        displayCode.UpdateCode(enteredNumber);
    }

    public void PressButton(string buttonValue)
    {
        enteredNumber += buttonValue; 
        UpdateCodeDisplay(); 

        if (enteredNumber.Length == correctSequence.Length)
        {
            CheckSequence();
        }
    }

    private void CheckSequence()
    {
        bool sequenceCorrect = true;
        for (int i = 0; i < correctSequence.Length; i++)
        {
            if (enteredNumber[i] != correctSequence[i][0]) 
            {
                sequenceCorrect = false;
                break;
            }
        }

        if (sequenceCorrect)
        {
         
            Debug.Log("keycard spawned");

        }
        else
        {
           
            enteredNumber = "";
            UpdateCodeDisplay(); 
        }
    }
}

