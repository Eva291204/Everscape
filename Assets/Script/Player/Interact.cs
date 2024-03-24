using UnityEngine;

public class Interact : MonoBehaviour
{
    public GameObject Item;

    private ZoomItem _zoomItem;
    private Animator _animator;
    private OpenChestAnimation _openChestAnimation;

    public string ChestName;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("PickItem") || collision.CompareTag("Key") || collision.CompareTag("MiniKey"))
        {
            GameManager.Instance.CanPickUpItem = true;
            Item = collision.gameObject;
        }
        if (collision.CompareTag("ZoomItem"))
        {
            GameManager.Instance.CanZoom = true;
            _zoomItem = collision.GetComponent<ZoomItem>();

            if(collision.name == ChestName)
            {
                RewardAnimation(collision);
            }
        }
        if (collision.CompareTag("Feuille"))
        {
            _animator = collision.GetComponent<Animator>();
            _animator.SetBool("Depop", true);
        }
    }

    public void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("PickItem") || collision.CompareTag("Key"))
        {
            GameManager.Instance.CanPickUpItem = false;
        }
        if (collision.CompareTag("ZoomItem") && GameManager.Instance.Zoom == false)
        {
            GameManager.Instance.CanZoom = false;
        }
    }

    public void PickUpItem()
    {
        Inventory.Instance.AddItem(Item);
    }

    public void ZoomItem()
    {
        _zoomItem.OnInteract();
    }
    public void DeZoomItem()
    {
        _zoomItem.OnReInteract();
    }

    public void RewardAnimation(Collider collision)
    {
        if (GameManager.Instance.GetMiniKey)
        {
            _openChestAnimation = collision.GetComponent<OpenChestAnimation>();
            StartCoroutine(_openChestAnimation.OpenChest());
        }
    }
}
