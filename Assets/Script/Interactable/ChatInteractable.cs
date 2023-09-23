using DialogueEditor;
using Sirenix.OdinInspector;
using SOGameEvents;
using UnityEngine.Events;

public class ChatInteractable : Interactable
{
    [BoxGroup("Data", Order = 0)]
    public NPCConversation _conversation;
    [BoxGroup("Data", Order = 0)]
    public bool isAlreadyUsed = false;
    [BoxGroup("Data", Order = 0)]
    public UnityEvent onChatEnded = new UnityEvent();

    [BoxGroup("Events", Order = 1)]
    public GameEventBool setActiveChatButton = null;
    [BoxGroup("Events", Order = 1)]
    public GameEventString setChatID = null;
    [BoxGroup("Events", Order = 1)]
    public GameEventString onClickChatButton = null;
    [BoxGroup("Events", Order = 1)]
    public GameEventBool setActiveController = null;

    #region Mono

    private void OnEnable()
    {
        onClickChatButton.AddListener(ShowDialogue);
    }

    private void OnDisable()
    {
        onClickChatButton.RemoveListener(ShowDialogue);
    }

    #endregion

    #region Interactable

    public override void Detected()
    {
        setActiveChatButton.Invoke(true);
        setChatID.Invoke(GetInstanceID().ToString());
    }

    public override void Undetected()
    {
        setActiveChatButton.Invoke(false);
    }

    public override bool CanInteracted()
    {
        return !isAlreadyUsed && _conversation != null;
    }

    #endregion

    #region Methods

    private void ShowDialogue(string id)
    {
        if (id != GetInstanceID().ToString()) return;

        setActiveController.Invoke(false);
        setActiveChatButton.Invoke(false);

        ConversationManager.Instance.StartConversation(_conversation);
        ConversationManager.OnConversationEnded += OnChatEnd;
    }

    private void OnChatEnd()
    {
        isAlreadyUsed = true;
        setActiveController.Invoke(true);

        onChatEnded.Invoke();

        ConversationManager.OnConversationEnded -= OnChatEnd;
    }

    #endregion
}
