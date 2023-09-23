using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void Detected() { }
    public virtual void Undetected() { }
    public virtual bool CanInteracted() { return true; }
    public virtual void Interact() { }
}
