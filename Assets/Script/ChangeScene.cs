using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string NewScene;

    public void OnChange()
    {
        SceneManager.LoadScene(NewScene);
    }

    public void OnTriggerEnter(Collider collider)
    {
        OnChange();
    }
}
