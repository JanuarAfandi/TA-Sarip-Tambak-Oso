using UnityEngine;
using UnityEngine.Events;

public class EventOnTrigger : MonoBehaviour
{
    public UnityEvent onTriggerEnter = new UnityEvent();
    public UnityEvent onTriggerStay = new UnityEvent();
    public UnityEvent onTriggerExit = new UnityEvent();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        onTriggerEnter.Invoke();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        onTriggerStay.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onTriggerExit.Invoke();
    }
}
