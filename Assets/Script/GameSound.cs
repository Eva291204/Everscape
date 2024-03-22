using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSound : MonoBehaviour
{
    private static GameSound _instanceSound;
    public static GameSound Instance
    {
        get
        {
            if (_instanceSound == null)
            {
                Debug.Log("GameSound is null");
            }
            return _instanceSound;
        }
    }
    public void Awake()
    {
        if (_instanceSound != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instanceSound = this;
        }
    }

    [SerializeField] public AudioSource _audioSource;
    public bool changeSound;
    public Scene ActiveScene;

    public void Start()
    {
        DontDestroyOnLoad(gameObject);
        _audioSource.GetComponent<AudioSource>();
        _audioSource.Play();
    }
}
