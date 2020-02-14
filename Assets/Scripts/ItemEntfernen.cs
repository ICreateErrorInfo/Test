using JetBrains.Annotations;

using UnityEngine;

public class ItemEntfernen : MonoBehaviour
{
    public GameObject Obj;

    [UsedImplicitly]
    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.tag == "Player") {
            if (Input.GetKeyDown(KeyCode.E)) {
                Destroy(Obj);
            }
        }
    }
}
