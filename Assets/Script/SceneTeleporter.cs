using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneTeleporter : MonoBehaviour
{
    [Scene]
    public string scene = null;

    public LayerMask playerMask = 0;

    public UnityEvent onTeleported = new UnityEvent();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerMask == (playerMask | (1 << collision.gameObject.layer)))
        {
            onTeleported.Invoke();

            SceneManager.LoadScene(scene);
        }
    }
}
