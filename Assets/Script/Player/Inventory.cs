using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private static Inventory _instanceInventory;
    public static Inventory Instance
    {
        get
        {
            if (_instanceInventory == null)
            {
                Debug.Log("GameManager is null");
            }
            return _instanceInventory;
        }
    }
    public void Awake()
    {
        if (_instanceInventory != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instanceInventory = this;
        }
    }

    public List<GameObject> _inInventory = new List<GameObject>();
    [SerializeField] private bool _alreadyInInventory;

    public void AddItem(GameObject newItem)
    {
        for (int i = 0; i < _inInventory.Count; i++)
        {
            if (newItem.name == _inInventory[i].name)
            {
                _alreadyInInventory = true;
            }
        }
        if (!_alreadyInInventory)
        {
            _inInventory.Add(newItem);
            newItem.SetActive(false);
            GameManager.Instance.CanPickUpItem = false;

            if (newItem.CompareTag("MiniKey"))
            {
                GameManager.Instance.GetMiniKey = true;
            }
        }
        _alreadyInInventory = false;

        CheckItem(newItem);
    }

    public void CheckItem(GameObject newItem)
    {
        if (newItem.CompareTag("Key"))
        {
            GameManager.Instance.GetKey = true;
        }
    }
}
