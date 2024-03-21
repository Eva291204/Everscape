using UnityEngine;

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

    [SerializeField] public GameObject _door;
    private Animator _doorAnimator;
    public void Start()
    {
        _doorAnimator = _door.GetComponent<Animator>();
    }
    public void OpenDoor()
    {
        _doorAnimator.SetBool("OpenDoor", true);
    }
}
