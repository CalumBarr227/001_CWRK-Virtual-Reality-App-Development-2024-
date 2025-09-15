using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TouchButton : XRBaseInteractable
{
    public string buttonValue;
    public Material touchedMaterial;
    private Material normalMaterial;
    private Renderer buttonRenderer;
    //private Keypad keyPad;
    public NumPad numPad;

    protected override void Awake()
    {
        base.Awake();
        buttonRenderer = GetComponent<Renderer>();
        normalMaterial = buttonRenderer.material;
    }

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        buttonRenderer.material = touchedMaterial;
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
        buttonRenderer.material = normalMaterial;
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        Debug.Log("Button pressed: " + buttonValue);
        if (numPad != null)
        {
            numPad.PressButton(buttonValue);
        }
    }
}
