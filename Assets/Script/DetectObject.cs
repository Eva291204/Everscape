using UnityEngine;

public class DetectObject : MonoBehaviour
{
    public void OnTriggerEnter(Collider collider)
    {
        for(int i = 0; i < Inventory.Instance._inInventory.Count; i++) 
        {
            if(Inventory.Instance._inInventory[i].gameObject.CompareTag("NeedToOpenDoor"))
            {
                Inventory.Instance._inInventory[i].gameObject.transform.position = this.transform.position;
                Inventory.Instance._inInventory[i].gameObject.SetActive(true);

                GameManager.Instance.DoorOpen = true;
                Inventory.Instance._inInventory.Remove(Inventory.Instance._inInventory[i]);
            }
        }
    }
}
