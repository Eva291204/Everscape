using System.Collections.Generic;
using UnityEngine;

public class ZoomItem : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void OnInteract()
    {
        _animator.SetBool("Zoom", true);
    }
    public void OnReInteract()
    {
        _animator.SetBool("Zoom", false);
    }
}
