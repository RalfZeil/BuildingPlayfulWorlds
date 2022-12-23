using UnityEngine;

public class WinArea : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered Win");
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            EventManager.RaiseEvent(EventType.ON_WIN);
        }

    }
}
