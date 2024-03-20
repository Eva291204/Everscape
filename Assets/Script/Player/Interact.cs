using UnityEngine;

public class Interact : MonoBehaviour
{
    public GameObject Item;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("PickItem") || collision.CompareTag("Key"))
        {
            GameManager.Instance.CanPickUpItem = true;
            Item = collision.gameObject;
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
}
