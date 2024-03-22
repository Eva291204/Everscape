using System.Collections;
using UnityEngine;

public class OpenChestAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _coffreCloseUI;
    [SerializeField] private GameObject _coffreOpenUI;
    [SerializeField] private GameObject _coffresMap;
    public IEnumerator OpenChest()
    {
        yield return new WaitForSeconds(1);
        _coffreCloseUI.SetActive(false);
        _coffreOpenUI.SetActive(true);

        _animator.SetBool("ShowReward", true);

        GameManager.Instance.GetKey = true;
        Inventory.Instance._inInventory.Clear();
        GameManager.Instance.GetMiniKey = false;

        _coffresMap.transform.GetChild(0).gameObject.SetActive(false);
        _coffresMap.transform.GetChild(1).gameObject.SetActive(true);

        yield return new WaitForSeconds(3);
        _animator.SetBool("ShowReward", false);
        GameManager.Instance.Zoom = false;
    }
}
