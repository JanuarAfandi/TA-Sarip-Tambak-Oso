using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Scene]
    public string sceneName = string.Empty;

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
