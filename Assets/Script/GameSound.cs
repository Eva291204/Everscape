using UnityEngine;

public class GameSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        _audioSource.GetComponent<AudioSource>();
        _audioSource.Play();
    }
}
