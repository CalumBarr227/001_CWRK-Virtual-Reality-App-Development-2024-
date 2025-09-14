using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Door : XRBaseInteractable
{

    public Transform DraggedTransform; 
    public Vector3 LocalDragDirection; 
    public float DragDistance; 
    public int DoorWeight = 20;

   
    private Vector3 m_StartPosition;
    private Vector3 m_EndPosition;
    private Vector3 m_WorldDragDirection;


    private void Start()
    {
        m_WorldDragDirection = transform.TransformDirection(LocalDragDirection).normalized;

        m_StartPosition = DraggedTransform.position;
        m_EndPosition = m_StartPosition + m_WorldDragDirection * DragDistance;
    }

    
    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if (isSelected && interactorsSelecting.Count > 0)
        {
            var interactorTransform = interactorsSelecting[0].transform;
            Vector3 selfToInteractor = interactorTransform.position - transform.position;

            
            float dotProduct = Vector3.Dot(selfToInteractor.normalized, m_WorldDragDirection);

            
            float speed = Mathf.Abs(dotProduct) * DoorWeight;

            
            float distance = Mathf.Clamp(dotProduct, 0f, DragDistance);
            Vector3 newPosition = m_StartPosition + m_WorldDragDirection * distance;
            DraggedTransform.position = Vector3.MoveTowards(DraggedTransform.position, newPosition, speed * Time.deltaTime);
        }
    }


}
