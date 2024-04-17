using UnityEngine;
using UnityEngine.UI;

public class LevelOptionUI : MonoBehaviour
{
    public string levelKey = string.Empty;

    public Image levelImage = null;
    public Button button = null;
    public Color unlockColor = Color.white;
    public Color lockColor = Color.white;

    private void Start()
    {
        LevelManager levelManager = LevelManager.Instance;
        
        if (levelManager == null) return;

        if (!levelManager.LevelKeys.ContainsKey(levelKey)) return;

        if (levelManager.LevelKeys[levelKey])
        {
            Unlock();
            return;
        }

        Lock();
    }

    public void Lock()
    {
        levelImage.color = lockColor;
        button.interactable = false;
    }

    public void Unlock()
    {
        levelImage.color = unlockColor;
        button.interactable = true;
    }
}
