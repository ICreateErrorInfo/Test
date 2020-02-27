using JetBrains.Annotations;
using UnityEngine;

public class PlayerControllre: MonoBehaviour {

    GameObject   _spawn;
    public float Speed;
    public float JumpForce;
    public bool  IsGrounded;
    int          _sprungKontingent;
    private GameObject ItemJump;
    GameObject ItemEntferner;

    [UsedImplicitly]
    void Start() {
        ItemEntferner = GameObject.FindGameObjectWithTag(TagNames.ItemEnt);
        ItemJump = GameObject.FindGameObjectWithTag(TagNames.ItemJump);
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

    void Jump()
    {

        if (Input.GetButtonDown(Steuerung.Vertical))
        {

            if (IsGrounded)
            {
                _sprungKontingent = Stats.Instance.Jumps;
            }

            if (_sprungKontingent > 0)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                _sprungKontingent -= 1;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == TagNames.Gefahr)
        {
            Stats.Instance.Health -= 50;
            transform.position = _spawn.transform.position;
        }
        if (collision.tag == TagNames.DeathZone)
        {

            Stats.Instance.Health -= 25;
            transform.position = _spawn.transform.position;

        }
        if (collision.gameObject.tag == TagNames.ItemJump)
        {
            Stats.Instance.Jumps = 3;
            ItemJump.SetActive(false);
        }
        if (collision.tag == TagNames.ItemEnt)
        {
            ItemEntferner.GetComponent<ItemEntfernen>()._insideItem = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == TagNames.ItemEnt)
        {
            ItemEntferner.GetComponent<ItemEntfernen>()._insideItem = false;
            ItemEntferner.GetComponent<ItemEntfernen>().EText.gameObject.SetActive(false);
            ItemEntferner.GetComponent<ItemEntfernen>()._timer = 0;
        }
    }

}