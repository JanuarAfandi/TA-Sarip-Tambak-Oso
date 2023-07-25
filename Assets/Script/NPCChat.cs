using System.Collections;
using System.Collections.Generic;
using DialogueEditor;
using UnityEngine;
using UnityEngine.Events;

public class NPCChat : MonoBehaviour
{
    public NPCConversation myConversation;
    public bool isAlreadyUsed = false;
    public UnityEvent onAfterChat = new UnityEvent();
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isAlreadyUsed) return;

        if (collision.CompareTag("Player"))
        {
            UIManager.Instance.chatButton.gameObject.SetActive(true);
            UIManager.Instance.chatButton.onClick.AddListener(ShowDialogue);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isAlreadyUsed) return;

        if (collision.CompareTag("Player"))
        {
            DisableChat();
        }
    }

    private void ShowDialogue() {
        ConversationManager.Instance.StartConversation(myConversation);
        DisableController();

        ConversationManager.OnConversationEnded += OnChatEnd;

        DisableChat();
    }

    private void OnChatEnd() {
        isAlreadyUsed = true;
        onAfterChat.Invoke();
        EnableController();

        ConversationManager.OnConversationEnded -= OnChatEnd;
    }

    private void EnableController() {
        UIManager.Instance.leftButton.gameObject.SetActive(true);
        UIManager.Instance.rightButton.gameObject.SetActive(true);
        UIManager.Instance.jumpButton.gameObject.SetActive(true);
    }

    private void DisableController() {
        UIManager.Instance.leftButton.gameObject.SetActive(false);
        UIManager.Instance.rightButton.gameObject.SetActive(false);
        UIManager.Instance.jumpButton.gameObject.SetActive(false);
    }

    private void DisableChat() {
        UIManager.Instance.chatButton.gameObject.SetActive(false);
        UIManager.Instance.chatButton.onClick.RemoveListener(ShowDialogue);
    }
}
