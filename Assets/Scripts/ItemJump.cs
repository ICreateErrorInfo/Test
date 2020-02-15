using JetBrains.Annotations;
using UnityEngine;
using TMPro;

public class ItemJump : MonoBehaviour
{
    GameObject _player;
    public int ExtraJump;
    public TextMeshProUGUI JumpText;

    [UsedImplicitly]
    private void Start() {
        _player = GameObject.FindGameObjectWithTag(TagNames.Player);
    }

    [UsedImplicitly]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag ==_player.tag) {
            _player.GetComponent<Spiel>().ExtraJump = ExtraJump;
            JumpText.text = $"Jumps: {ExtraJump}";
            gameObject.SetActive(false);
        }
    }
}
