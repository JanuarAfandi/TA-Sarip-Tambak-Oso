using Sirenix.OdinInspector;
using SOGameEvents;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Button chatButton;
    public Button leftButton;
    public Button rightButton;
    public Button jumpButton;

    [BoxGroup("Events", Order = 100)]
    public GameEventBool setActiveChatButtonUI = null;
    [BoxGroup("Events", Order = 100)]
    public GameEventString setCurrentChatID = null;
    [BoxGroup("Events", Order = 100)]
    public GameEventString onClickChatButton = null;
    [BoxGroup("Events", Order = 100)]
    public GameEventBool setActiveController = null;

    private string _chatID = string.Empty;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

    private void Start()
    {
        chatButton.onClick.AddListener(ClickChatButton);
    }

    private void OnEnable()
    {
        setActiveChatButtonUI.AddListener(chatButton.gameObject.SetActive);
        setActiveController.AddListener(SetActiveController);
        setCurrentChatID.AddListener(SetChatID);
    }

    private void OnDisable()
    {
        setActiveChatButtonUI.RemoveListener(chatButton.gameObject.SetActive);
        setActiveController.RemoveListener(SetActiveController);
        setCurrentChatID.RemoveListener(SetChatID);
    }

    private void SetChatID(string id)
    {
        _chatID = id;
    }

    private void ClickChatButton()
    {
        onClickChatButton.Invoke(_chatID);
    }

    private void SetActiveController(bool isActive)
    {
        leftButton.gameObject.SetActive(isActive);
        rightButton.gameObject.SetActive(isActive);
        jumpButton.gameObject.SetActive(isActive);
    }
} 
