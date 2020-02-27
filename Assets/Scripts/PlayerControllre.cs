using JetBrains.Annotations;
using UnityEngine;

public class PlayerControllre: MonoBehaviour {

    GameObject   _spawn;
    public float Speed;
    public float JumpForce;
    [HideInInspector]
    public bool  IsGrounded;
    int          _sprungKontingent;
    private GameObject ItemJump;
    GameObject ItemEntferner;
    GameObject Gefahr;
    int colTimer;
    bool GefahrenCol;
    public int hitTime;
    int saveHitTime;
    public int GefahrenDamage;

    [UsedImplicitly]
    void Start() {
        // Variablen werden initialisiert
        ItemEntferner = GameObject.FindGameObjectWithTag(TagNames.ItemEnt);
        ItemJump = GameObject.FindGameObjectWithTag(TagNames.ItemJump);
        _spawn             = GameObject.FindGameObjectWithTag(TagNames.Spawn);
        Gefahr = GameObject.FindGameObjectWithTag(TagNames.Gefahr);
        transform.position = _spawn.transform.position;
        saveHitTime = hitTime;
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
        if (GefahrenCol)
        {
            colTimer += 1;
        }

        // Wird leben in einer bestimmten zeit abgezogen
        if(colTimer == hitTime)
        {
            Stats.Instance.Health -= GefahrenDamage;
            hitTime += saveHitTime;
        }

        //Wird aufgerufen wenn der spieler kein Leben mehr hat
        if(Stats.Instance.Health <= 5)
        {
            Time.timeScale = 0;
        }

        //läst den Spiler bewegen
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == TagNames.Gefahr)
        {
            Gefahr.GetComponent<Gefahren>().enabled = false;
            Stats.Instance.Health -= GefahrenDamage;
            GefahrenCol = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == TagNames.Gefahr)
        {
            GefahrenCol = false;
            Gefahr.GetComponent<Gefahren>().enabled = true;
        }
    }

}