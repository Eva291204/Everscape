using UnityEngine;

public class ZoomItem : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void OnInteract()
    {
        GameManager.Instance.Zoom = true;
        _animator.SetBool("Zoom", true);
    }
    public void OnReInteract()
    {
        GameManager.Instance.Zoom = false;
        _animator.SetBool("Zoom", false);
    }
}
