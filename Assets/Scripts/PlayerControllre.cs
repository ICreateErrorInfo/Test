using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllre: MonoBehaviour {

    GameObject   _spawn;
    public float Speed;
    public float JumpForce;
    [HideInInspector]
    public bool  IsGrounded;
    int          _sprungKontingent;
    private GameObject _itemJump;
    GameObject _itemEntferner;
    GameObject _gefahr;
    int _colTimer;
    bool _gefahrenCol;
    public int HitTime;
    int _saveHitTime;
    public int GefahrenDamage;

    [UsedImplicitly]
    void Start() {
        // Variablen werden initialisiert
        _itemEntferner = GameObject.FindGameObjectWithTag(TagNames.ItemEnt);
        _itemJump = GameObject.FindGameObjectWithTag(TagNames.ItemJump);
        _spawn             = GameObject.FindGameObjectWithTag(TagNames.Spawn);
        _gefahr = GameObject.FindGameObjectWithTag(TagNames.Gefahr);
        transform.position = _spawn.transform.position;
        _saveHitTime = HitTime;
    }

    [UsedImplicitly]
    void Update() {

        // dreht die textur vom spieler um
        if (Input.GetAxis(Steuerung.Horizontal) < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetAxis(Steuerung.Horizontal) > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        // der timer wird jeden frame um eins größer
        if (_gefahrenCol)
        {
            _colTimer += 1;
        }

        // Wird leben in einer bestimmten zeit abgezogen
        if(_colTimer == HitTime)
        {
            Stats.Instance.Health -= GefahrenDamage;
            HitTime += _saveHitTime;
        }

        //Wird aufgerufen wenn der spieler kein Leben mehr hat
        if(Stats.Instance.Health <= 0) {
            Death();
        }

        //läst den Spieler bewegen
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

    // wenn etwas mit dem tag berührt wird wird das ausgeführt
    [UsedImplicitly]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == TagNames.DeathZone)
        {

            Stats.Instance.Health -= 25;
            transform.position = _spawn.transform.position;

        }
        if (collision.gameObject.tag == TagNames.ItemJump)
        {
            Stats.Instance.Jumps = 3;
            _itemJump.SetActive(false);
        }
        if (collision.tag == TagNames.ItemEnt)
        {
            _itemEntferner.GetComponent<ItemEntfernen>()._insideItem = true;

        }
    }
    [UsedImplicitly]
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == TagNames.ItemEnt)
        {
            _itemEntferner.GetComponent<ItemEntfernen>()._insideItem = false;
            _itemEntferner.GetComponent<ItemEntfernen>().EText.gameObject.SetActive(false);
            _itemEntferner.GetComponent<ItemEntfernen>()._timer = 0;
        }

    }
    [UsedImplicitly]
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == TagNames.Gefahr)
        {
            _gefahr.GetComponent<Gefahren>().enabled = false;
            Stats.Instance.Health -= GefahrenDamage;
            _gefahrenCol = true;
        }
    }
    [UsedImplicitly]
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == TagNames.Gefahr)
        {
            _gefahrenCol = false;
            _gefahr.GetComponent<Gefahren>().enabled = true;
        }
    }

    public static void Death() {

        Time.timeScale = 0;

    }

}