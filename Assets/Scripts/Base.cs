using UnityEngine;

public class Base : MonoBehaviour
{
    public SpriteRenderer inner;

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.name == "Player")
            inner.gameObject.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.name == "Player")
            inner.gameObject.SetActive(false);
    }
}
