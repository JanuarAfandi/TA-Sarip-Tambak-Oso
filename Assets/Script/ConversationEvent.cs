using DialogueEditor;
using UnityEngine;
using UnityEngine.Events;

public class ConversationEvent : MonoBehaviour
{
    public UnityEvent onConversationStarted = new UnityEvent();
    public UnityEvent onConversationFinished = new UnityEvent();

    private void Start()
    {
        ConversationManager.OnConversationStarted += onConversationStarted.Invoke;
        ConversationManager.OnConversationEnded += onConversationFinished.Invoke;
    }

    private void OnDestroy()
    {
        ConversationManager.OnConversationStarted -= onConversationStarted.Invoke;
        ConversationManager.OnConversationEnded -= onConversationFinished.Invoke;
    }
}
