using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, PlayerInputController.IPlayerActions
{
    [SerializeField] private int _playerSpeed;
    private Vector3 _directionPlayer;

    private Interact _interact;

    public void Start()
    {
        _interact = GetComponent<Interact>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _directionPlayer = context.ReadValue<Vector3>();
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (GameManager.Instance.CanPickUpItem)
        {
            _interact.PickUpItem();
        }
        GameManager.Instance.Interact = true;
    }
    void Update()
    {
        gameObject.transform.Translate(_directionPlayer * (_playerSpeed * Time.deltaTime)); //player move
    }
}
