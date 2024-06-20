using DialogueEditor;
using UnityEngine;
using UnityEngine.Events;

public class ConversationAction : MonoBehaviour
{
    public NPCConversation conversation = null;

    public UnityEvent onChatEnded = new UnityEvent();

    public void StartConversation()
    {
        if (ConversationManager.Instance == null) return;

        ConversationManager.Instance.StartConversation(conversation);
        ConversationManager.OnConversationEnded += OnChatEnded;
    }

    private void OnChatEnded()
    {
        onChatEnded.Invoke();

        ConversationManager.OnConversationEnded -= OnChatEnded;
    }
}
