using Sirenix.OdinInspector;
using SOGameEvents;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [BoxGroup("Events")]
    public GameEventNoParam restartGameEvent = null;

    [BoxGroup("Events")]
    public GameEventBool pauseGameEvent = null;

    private void OnEnable()
    {
        restartGameEvent.AddListener(RestartGame);
        pauseGameEvent.AddListener(Pause);
    }

    private void OnDisable()
    {
        restartGameEvent.RemoveListener(RestartGame);
        pauseGameEvent.RemoveListener(Pause);
    }


    private void RestartGame()
    {
        SceneManager.LoadScene(gameObject.scene.name);
    }

    private void Pause(bool isPause)
    {
        Time.timeScale = isPause ? 0 : 1;
    }
}
