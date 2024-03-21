using UnityEngine;

public class Interact : MonoBehaviour
{
    public GameObject Item;

    private ZoomItem _zoomItem;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("PickItem") || collision.CompareTag("Key"))
        {
            GameManager.Instance.CanPickUpItem = true;
            Item = collision.gameObject;
        }
        if(collision.CompareTag("ZoomItem"))
        {
            GameManager.Instance.CanZoom = true;
            _zoomItem = collision.GetComponent<ZoomItem>();
        }
    }

    public void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("PickItem") || collision.CompareTag("Key"))
        {
            GameManager.Instance.CanPickUpItem = false;
        }
    }

    public void PickUpItem()
    {
        Inventory.Instance.AddItem(Item);
    }

    public void ZoomItem()
    {
        GameManager.Instance.Zoom = true;
        _zoomItem.OnInteract();
    }
    public void DeZoomItem()
    {
        GameManager.Instance.Zoom = false;
        _zoomItem.OnReInteract();
    }
}
