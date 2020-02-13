using JetBrains.Annotations;

using UnityEngine;

public class Spiel: MonoBehaviour {

    public GameObject Spieler;
    public float Speed;
    public float JumpForce;
    public bool IsGrounded;
    public int ExtraJump = 1;
    [SerializeField]public int ExtraJump2;

    [UsedImplicitly]
    void Start() {
        ExtraJump2 = ExtraJump;
    }

    static class AxisName {

        public const string Horizontal = "Horizontal";
        public const string Jump       = "Jump";
        public const string Vertical   = "Vertical";

    }

    [UsedImplicitly]
    void Update() {

        if (transform.rotation.z >= 90 || transform.position.z >= 180) {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }

        Jump();
        Vector3 movement = new Vector3(Input.GetAxis(AxisName.Horizontal), 0, 0);
        Spieler.transform.position += movement * Time.deltaTime * Speed;
        if (IsGrounded) {
            ExtraJump = ExtraJump2;
        }
    }

    void Jump() {
        if (ExtraJump == 1) {
            if (Input.GetButtonDown(AxisName.Vertical) && IsGrounded) {
                Spieler.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            }
        }else if (ExtraJump >= 2) {
            if (Input.GetButtonDown(AxisName.Vertical) && ExtraJump > 1) {
                Spieler.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                ExtraJump -= 1;
            }
        }
    }

}