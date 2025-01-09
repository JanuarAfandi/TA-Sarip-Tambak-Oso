using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class PlayableDirectorEvent : MonoBehaviour
{
    public PlayableDirector playableDirector = null;

    public UnityEvent onCompleted = new UnityEvent();

    private void Start()
    {
        if (playableDirector != null)
        {
            playableDirector.stopped += OnPlayableCompleted;
        }
    }

    private void OnDestroy()
    {
        if (playableDirector != null)
        {
            playableDirector.stopped -= OnPlayableCompleted;
        }
    }

    private void OnPlayableCompleted(PlayableDirector director)
    {
        if (director != playableDirector) return;

        Debug.Log("Playable Director is completed!");

        onCompleted.Invoke();
    }
}
