using UnityEngine;

public class Interact : MonoBehaviour
{
    public GameObject Item;

    public void OnTriggerEnter(Collider collision)
    {
        GameManager.Instance.CanPickUpItem = true;
        Item = collision.gameObject;
    }

    public void OnTriggerExit(Collider collision)
    {
        GameManager.Instance.CanPickUpItem = false;
    }

    public void PickUpItem()
    {
        Debug.Log("PickItem");
        Inventory.Instance.AddItem(Item);
    }
}
