using JetBrains.Annotations;

using UnityEngine;

public class Spiel: MonoBehaviour {

    public GameObject Spieler;
    public float      Speed;
    public float      JumpForce;
    public bool       IsGrounded;
    public int        ExtraJump = 1;

    int _sprungKontingent;

    [UsedImplicitly]
    void Start() {
    }

    static class AxisName {

        public const string Horizontal = "Horizontal";
        public const string Vertical   = "Vertical";

    }

    [UsedImplicitly]
    void Update() {
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis(AxisName.Horizontal), 0, 0);
        Spieler.transform.position += movement * Time.deltaTime * Speed;
    }

    void Jump() {

        if (Input.GetButtonDown(AxisName.Vertical)) {

            if (IsGrounded) {
                _sprungKontingent = ExtraJump;
            }

            if (_sprungKontingent > 0) {
                Spieler.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                _sprungKontingent -= 1;
            }
        }
    }

}