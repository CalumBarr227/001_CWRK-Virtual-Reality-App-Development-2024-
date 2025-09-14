using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TouchButton : XRBaseInteractable
{
    public int buttonNumber; 
    public Material touchedMaterial; 
    private Material normalMaterial; 
    private Renderer buttonRenderer; 
    private Keypad keypad; 

    protected override void Awake()
    {
        base.Awake();
        buttonRenderer = GetComponent<Renderer>();
        normalMaterial = buttonRenderer.material;
        keypad = GetComponentInParent<Keypad>(); 
    }

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        buttonRenderer.material = touchedMaterial;
        if (keypad != null)
        {
            keypad.ButtonHovered(buttonNumber); 
        }
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
        buttonRenderer.material = normalMaterial;
    }
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        Debug.Log(buttonNumber + " pressed"); 
        if (keypad != null)
        {
            keypad.ButtonPressed(buttonNumber); 
        }
    }
}