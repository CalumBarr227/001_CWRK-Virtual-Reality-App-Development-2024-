using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeycardReader : MonoBehaviour
{
    public Transform readerStart;
    public Transform readerEnd;
    public float minSwipeDistance = 0.2f;
    public GameObject doorLock;
    public GameObject doorBar;
    private bool swipeSuccessful = false;
    public Door slidingDoor;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Keycard") && !swipeSuccessful)
        {
            float swipeDistance = readerStart.position.y - collider.transform.position.y;

            if (swipeDistance >= minSwipeDistance)
            {
                UnlockDoor();
                swipeSuccessful = true;
            }
        }
    }

    private void UnlockDoor()
    {
        if (doorLock != null)
            doorLock.SetActive(false);

        if (doorBar != null)
            doorBar.SetActive(false);

        if (slidingDoor != null)
            slidingDoor.UnlockDoor();

        Debug.Log("door unlocked");
    }
}
