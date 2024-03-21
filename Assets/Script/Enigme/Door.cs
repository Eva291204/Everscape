using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator _animator;
    public void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void OnTriggerEnter(Collider collider)
    {
        if (GameManager.Instance.DoorOpen)
        {
            _animator.SetBool("OpenDoor", true);
            GameManager.Instance.GetKey = false;
        }
    }
}
