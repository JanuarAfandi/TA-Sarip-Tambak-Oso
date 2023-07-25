using System.Collections;
using System.Collections.Generic;
using DialogueEditor;
using UnityEngine;

public class NPCChat : MonoBehaviour
{
    public NPCConversation myConversation;
    public bool isAlreadyUsed = false;
    
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
        isAlreadyUsed = true;

        DisableChat();
    }

    private void DisableChat() {
        UIManager.Instance.chatButton.gameObject.SetActive(false);
        UIManager.Instance.chatButton.onClick.RemoveListener(ShowDialogue);
    }
}
