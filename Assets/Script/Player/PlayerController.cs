using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, PlayerInputController.IPlayerActions
{
    [SerializeField] private int _playerSpeed;
    private Vector3 _directionPlayer;

    private Interact _interact;
    private AudioSource _audioSourceCoin;

    public void Start()
    {
        _interact = GetComponent<Interact>();
        _audioSourceCoin = GetComponent<AudioSource>(); 
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _directionPlayer = context.ReadValue<Vector3>();
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        _audioSourceCoin.Play();
        if (GameManager.Instance.CanPickUpItem)
        {
            _interact.PickUpItem();
        }
        if (GameManager.Instance.CanZoom)
        {
            if(GameManager.Instance.Zoom)
            {
                _interact.DeZoomItem();
            }
            else
            {
                _interact.ZoomItem();
            }
        }
        GameManager.Instance.Interact = true;
    }
    void Update()
    {
        if (!GameManager.Instance.Zoom)
        {
            gameObject.transform.Translate(_directionPlayer * (_playerSpeed * Time.deltaTime)); //player move
        }
    }
}
