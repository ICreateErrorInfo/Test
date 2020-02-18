using JetBrains.Annotations;
using UnityEngine;

public class PlayerControllre: MonoBehaviour {

    GameObject   _spawn;
    public float Speed;
    public float JumpForce;
    public bool  IsGrounded;
    public int   ExtraJump = 1;
    int          _sprungKontingent;

    [UsedImplicitly]
    void Start() {
        _spawn             = GameObject.FindGameObjectWithTag(TagNames.Spawn);
        transform.position = _spawn.transform.position;
    }

    [UsedImplicitly]
    void Update() {

        if (Input.GetAxis(Steuerung.Horizontal) < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetAxis(Steuerung.Horizontal) > 0){
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        Jump();
        Vector3 movement = new Vector3(Input.GetAxis(Steuerung.Horizontal), 0, 0);
        transform.position += movement * Time.deltaTime * Speed;

    }

    void Jump() {

        if (Input.GetButtonDown(Steuerung.Vertical)) {

            if (IsGrounded) {
                _sprungKontingent = ExtraJump;
            }

            if (_sprungKontingent > 0) {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                _sprungKontingent -= 1;
            }
        }
    }
}