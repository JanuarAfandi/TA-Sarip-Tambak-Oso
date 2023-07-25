using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Button chatButton;
    public Button leftButton;
    public Button rightButton;
    public Button jumpButton;

    void Awake() {
        if (Instance == null) Instance = this;
        else Destroy(this);
    } 


} 
