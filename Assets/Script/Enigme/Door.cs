using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator _animator;
    public void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void OnTriggerEnter(Collider collsion)
    {
        if(GameManager.Instance.GetKey && GameManager.Instance.Interact)
        {
            _animator.SetBool("OpenDoor", true);
            GameManager.Instance.GetKey = false;
        }
    }
}
