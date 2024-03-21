using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, PlayerInputController.IPlayerActions
{
    [SerializeField] private int _playerSpeed;
    private Vector3 _directionPlayer;

    private Interact _interact;
    private AudioSource _audioSourceCoin;
    private Animator _animator;

    public void Start()
    {
        _interact = GetComponent<Interact>();
        _audioSourceCoin = GetComponent<AudioSource>(); 
        _animator = GetComponent<Animator>();
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
        if(GameManager.Instance.GetKey)
        {
            GameManager.Instance.DoorOpen = true;
        }
        
    }
    void Update()
    {
        if (!GameManager.Instance.Zoom)
        {
            gameObject.transform.Translate(_directionPlayer * (_playerSpeed * Time.deltaTime)); //player move
        }
        //if(Input.GetKeyDown("D"))
        //{
        //    _animator.SetBool("IsWalk", true);

        //}
        //if(Input.GetKeyDown("A") || Input.GetKeyDown("Q"))
        //{
        //    _animator.SetBool("IsWalk", true);

        //}
    }
}
