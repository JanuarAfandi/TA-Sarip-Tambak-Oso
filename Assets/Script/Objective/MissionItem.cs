using SOGameEvents;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mission Item Data", menuName = "Mission/New Mission Item Data")]
public class MissionItem : ScriptableObject
{
    public string Label = string.Empty;
    public GameEventNoParam Callback = null;
    public int TargetAmount = 1;
    
    [HideInInspector]
    public int Amount = 0;

    public bool IsDone
    {
        get
        {
            return TargetAmount <= Amount;
        }
    }

    public void Initialize()
    {
        Amount = 0;
        Callback.AddListener(AddAmount);
    }

    public void Deinitialize()
    {
        Callback.RemoveListener(AddAmount);
    }

    public void AddAmount()
    {
        Amount++;
    }
}
