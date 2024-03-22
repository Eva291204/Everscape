using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("GameManager is null");
            }
            return _instance;
        }
    }
    public void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public bool CanPickUpItem;
    public bool GetKey;
    public bool DoorOpen;
    public bool CanZoom;
    public bool Zoom;
    public bool GetMiniKey;
    public int NumberDetectObject;
    public int NeedNumberDetect;

    [SerializeField] public List<GameObject> _door = new List<GameObject>();
    public Animator _doorAnimator;
    
    public void OpenDoor()
    {
        if (NumberDetectObject == NeedNumberDetect)
        {
            _doorAnimator = _door[0].GetComponent<Animator>();
            _doorAnimator.SetBool("OpenDoor", true);
        }
    }
    public void OpenDoor2()
    {
        if (NumberDetectObject == NeedNumberDetect)
        {
            _doorAnimator = _door[1].GetComponent<Animator>();
            _doorAnimator.SetBool("OpenDoor", true);
        }
    }

}
