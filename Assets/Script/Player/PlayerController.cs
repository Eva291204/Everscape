using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, PlayerInputController.IPlayerActions
{
    [SerializeField] private int _playerSpeed;
    private Vector3 _directionPlayer;

    private Interact _interact;
    private AudioSource _audioSourceCoin;
    private Animator _animator;

    private GameObject _defaultPose;
    private GameObject _playerSprite;
    private GameObject _playerSpriteLeft;

    public void Start()
    {
        _interact = GetComponent<Interact>();
        _audioSourceCoin = GetComponent<AudioSource>();
        _animator = GetComponentInChildren<Animator>();

        _playerSprite = gameObject.transform.GetChild(0).gameObject;
        _playerSpriteLeft = gameObject.transform.GetChild(1).gameObject;
        _defaultPose = gameObject.transform.GetChild(2).gameObject;
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
            if (GameManager.Instance.Zoom)
            {
                _interact.DeZoomItem();
            }
            else
            {
                _interact.ZoomItem();
            }
        }
        if (GameManager.Instance.GetKey)
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
    }

    public void AnimationMove()
    {
        if(_directionPlayer.x < 0)
        {
            _animator.SetBool("IsWalkLeft", true);
            _animator.SetBool("IsWalk", false);

            _playerSprite.transform.rotation = _playerSpriteLeft.transform.rotation;
        }
        if(_directionPlayer.x > 0)
        {
            _animator.SetBool("IsWalk", true);
            _animator.SetBool("IsWalkLeft", false);

            _playerSprite.transform.rotation = _defaultPose.transform.rotation;
        }
        if(_directionPlayer == Vector3.zero) 
        {
            _animator.SetBool("IsWalk", false);
            _animator.SetBool("IsWalkLeft", false);
        }
    }
}
