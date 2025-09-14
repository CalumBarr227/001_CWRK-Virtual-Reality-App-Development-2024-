using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class Scanner : XRGrabInteractable
{
    [Header("Scanner Data")]
    public Animator animator;
    public LineRenderer laserRenderer;
    public TextMeshProUGUI targetName; 
    public TextMeshProUGUI targetPosition; 

    private void Start()
    {
        animator.SetBool("Opened", true); 
    }
    private void ScannerActivated(bool isActivated)
    {
        laserRenderer.gameObject.SetActive(isActivated);
        targetName.gameObject.SetActive(isActivated);
        targetPosition.gameObject.SetActive(isActivated);
    }
    protected override void Awake()
    {
        base.Awake();
        ScannerActivated(false);
    }
    protected override void OnActivated(ActivateEventArgs args)
    {
        base.OnActivated(args);
        ScannerActivated(true);
    }
    protected override void OnDeactivated(DeactivateEventArgs
    args)
    {
        base.OnDeactivated(args);
        ScannerActivated(false);
    }
    private void ScanForObjects() 
    {
        RaycastHit hit;

        if (Physics.Raycast(laserRenderer.transform.position, laserRenderer.transform.forward, out hit))
        {

            targetName.SetText(hit.collider.name); 
            targetPosition.SetText(hit.collider.transform.position.ToString()); 
        }
    }
    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);
        if (laserRenderer.gameObject.activeSelf) 
        {
            ScanForObjects();
        }

    }

}
