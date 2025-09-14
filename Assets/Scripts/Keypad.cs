using UnityEngine;

public class Keypad : MonoBehaviour
{
    public int[] correctCode = { 1, 2, 3, 4 }; 

 
    private int inputIndex = 0;


    public void ButtonHovered(int buttonNumber)
    {
        Debug.Log(buttonNumber + " hovered over");
        
    }


    public void ButtonPressed(int buttonNumber)
    {
     
        if (buttonNumber == correctCode[inputIndex])
        {
            inputIndex++;


            if (inputIndex == correctCode.Length)
            {
                Debug.Log("correct code");

                ResetInput();
            }
        }
        else
        {
            Debug.Log("invalid code");
         
            ResetInput();
        }
    }


    private void ResetInput()
    {
        inputIndex = 0;
    }
}