using Sirenix.OdinInspector;
using SOGameEvents;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [BoxGroup("Events")]
    public GameEventNoParam restartGameEvent = null;

    private void OnEnable()
    {
        restartGameEvent.AddListener(RestartGame);
    }

    private void OnDisable()
    {
        restartGameEvent.RemoveListener(RestartGame);
    }


    private void RestartGame()
    {
        SceneManager.LoadScene(gameObject.scene.name);
    }
}
