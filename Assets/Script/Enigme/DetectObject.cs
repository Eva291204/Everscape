using UnityEngine;

public class DetectObject : MonoBehaviour
{
    [SerializeField] private bool _door2;
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("PushItem"))
        {
            if (!_door2)
            {
                GameManager.Instance.NumberDetectObject++;
                GameManager.Instance.OpenDoor();
            }

            if (_door2)
            {
                GameManager.Instance.NumberDetectObject++;
                GameManager.Instance.OpenDoor2();
            }
        }
    }
}