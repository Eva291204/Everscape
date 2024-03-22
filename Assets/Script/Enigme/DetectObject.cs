using UnityEngine;

public class DetectObject : MonoBehaviour
{
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("PushItem"))
        {
            GameManager.Instance.NumberDetectObject++;
            GameManager.Instance.OpenDoor();
        }
    }
}