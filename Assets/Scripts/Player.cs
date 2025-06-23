using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float JumFoce = 15;
    private Rigidbody2D rb;
    private bool isGroud;
    [SerializeField]
    private Transform groudcheck;
    [SerializeField]
    private float groudCheckRadius = 0.2f;
    [SerializeField]
    private LayerMask groudlayer;
    private Animator anim;
    [SerializeField]
    private BoxCollider2D normacollider;
    [SerializeField]
    private CapsuleCollider2D duckcollider;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        normacollider.enabled = true;
        duckcollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        isGroud = checkiforounded();
        Hanlejump();
        HandeleDuck();
        HanleSoud();
    }
    private bool checkiforounded()
    {
        return Physics2D.OverlapCircle(groudcheck.position, groudCheckRadius, groudlayer);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groudcheck.position, groudCheckRadius);
    }

    private void Hanlejump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGroud)
        {
            rb.linearVelocity = Vector2.up * JumFoce;
        }
    }
    private void HandeleDuck()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            normacollider.enabled = false;
            duckcollider.enabled = true;
            anim.SetBool("isDuck", true);
        }
        else if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            normacollider.enabled= true;
            duckcollider.enabled=false;
            anim.SetBool("isDuck", false);

        }
    }
    private void HanleSoud()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGroud)
        {
            AudioManager.intance.PlayJumpclip();
        }
        if(isGroud && !AudioManager.intance.hasplayeEffectSound())
        {
            AudioManager.intance.playtapclip();
            AudioManager.intance.SetHasPlayEffSound(true);
        }
        else if(!isGroud)
        {
            AudioManager.intance.SetHasPlayEffSound(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle"))
        {
            AudioManager.intance.playHUrtclip();
        }
    }
}
