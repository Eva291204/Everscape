using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Scene _sceneName;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        _audioSource.GetComponent<AudioSource>();
    }
    public void Update()
    {
        _sceneName = SceneManager.GetActiveScene();

        if (_sceneName.name == "Menu" || _sceneName.name == "Credits")
        {
            _audioSource.Stop();
        }
        else { _audioSource.Play();}
    }
}
