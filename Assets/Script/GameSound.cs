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

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private bool _changeSound;
    [SerializeField] private Scene _activeScene;

    public void Start()
    {
        DontDestroyOnLoad(gameObject);
        _audioSource.GetComponent<AudioSource>();
        _audioSource.Play();
    }
    public void Update()
    {
        _activeScene = SceneManager.GetActiveScene();
        if (_changeSound && _activeScene.name != "Menu" || _changeSound && _activeScene.name != "Credits")
        {
            _audioSource.Play();
            _changeSound = false;
        }
        if (_activeScene.name == "Menu" || _activeScene.name == "Credits")
        {
            _audioSource.Stop();
            _changeSound = true;
        }
    }
}
