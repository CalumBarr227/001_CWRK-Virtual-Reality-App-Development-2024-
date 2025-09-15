using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Door : MonoBehaviour
{
    public Transform doorTransform;
    public XRSimpleInteractable DoorHandle;
    public Vector3 LocalSlideDirection = Vector3.right;
    public float MaxSlideDistance = 1.5f;
    public float SlideDamping = 10f;
    public bool IsLocked = true;
    private Vector3 startLocalPos;
    private Vector3 worldSlideDir;
    private bool isBeingGrabbed = false;
    private Transform grabbingHand;
    private Vector3 handleStartOffset;
    private Vector3 grabStartHandPos;

    void Start()
    {
        startLocalPos = doorTransform.localPosition;
        worldSlideDir = transform.TransformDirection(LocalSlideDirection).normalized;

        // Store initial offset of handle relative to the door
        handleStartOffset = DoorHandle.transform.position - doorTransform.position;

        DoorHandle.onSelectEntered.AddListener(OnHandleGrabbed);
        DoorHandle.onSelectExited.AddListener(OnHandleReleased);

        DoorHandle.enabled = !IsLocked;
    }

    void Update()
    {
        if (IsLocked) return;
        if (isBeingGrabbed && grabbingHand != null)
        {
            Vector3 handDelta = grabbingHand.position - grabStartHandPos;
            float slideAmount = Vector3.Dot(handDelta, worldSlideDir);
            slideAmount = Mathf.Clamp(slideAmount, 0f, MaxSlideDistance);

            Vector3 targetPos = startLocalPos + LocalSlideDirection.normalized * slideAmount;
            doorTransform.localPosition = Vector3.Lerp(doorTransform.localPosition, targetPos, Time.deltaTime * SlideDamping);
        }

        DoorHandle.transform.position = doorTransform.position + handleStartOffset;

    }

    private void OnHandleGrabbed(XRBaseInteractor interactor)
    {
        if (IsLocked) return;

        isBeingGrabbed = true;
        grabbingHand = interactor.attachTransform != null ? interactor.attachTransform : interactor.transform;

        handleStartOffset = DoorHandle.transform.position - doorTransform.position;
    }

    private void OnHandleReleased(XRBaseInteractor interactor)
    {
        isBeingGrabbed = false;
        grabbingHand = null;
    }

    public void UnlockDoor()
    {
        IsLocked = false;
        DoorHandle.enabled = true;
    }

    public void LockDoor()
    {
        IsLocked = true;
        doorTransform.localPosition = startLocalPos;
        DoorHandle.enabled = false;
    }
}
