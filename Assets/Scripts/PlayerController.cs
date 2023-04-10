using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //public int coins;//1,2,265541
    //public float speed;//number:11.21f
    //public string playername;//"ericy"
    //public bool isDead;//true or false
 
    public float moveSpeed;
    private bool facingRight = true;
    public Rigidbody2D rb;
    public float jumpForce;
    private float moveInput=5f;

    public LayerMask ground;
    public float groundDistance;
    private bool isGrounded;
    private bool canDoubleJump;

    private int honey = 0;
    public TMP_Text HoneyCount;

    private int health = 3;

    public Animator anim;

    private enum PlayerState
    {
        JasonAnimator,run,jump,
    }

    // Start is called before the first frame update
    void Start()
    { 
        jumpForce = 7;
        canDoubleJump = true;
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        collisionCheck();
        inputCheck();
        if (isGrounded)
        {
            canDoubleJump = true;
        }
        Move();
        playerAnim();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Enter");
        if (collision.gameObject.CompareTag("Honey"))
        {
            Destroy(collision.gameObject);
            AddHoney();
        }
       

    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            health -= 1;
            if (health == 0)
            {
                Death();
            }
            if (health< 1)
            {
                /// YOU DEAD
                Destroy(GameObject.Find("heart"));
            }
            else if (health < 2)
            {
                Destroy(GameObject.Find("heart2"));
            }
            else if(health < 3)
            {
                Destroy(GameObject.Find("heart3"));
            }
        }
        if (collision.tag == "DieLine")
        {
            Invoke("Restart", 0.5f);
            anim.SetTrigger("death");
        }
    }

    private void Death()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void inputCheck()
    { 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpMechanics();

        }
    }

    private void JumpMechanics()
    {
        if (isGrounded)
        {
            Jump();

        }
        else if (canDoubleJump)
        {
            canDoubleJump = false;
            Jump();
        }
    }

    private void Move()
    {
        moveSpeed = Input.GetAxis("Horizontal");
        anim.SetFloat("speed",Mathf.Abs(moveSpeed));
        rb.velocity = new Vector2(moveSpeed * moveInput, rb.velocity.y);

        if(facingRight == false && moveSpeed > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveSpeed < 0)
        {
            Flip();
        }
    }
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x*= -1;
        transform.localScale = playerScale;
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void OnDrawGizmas()
    {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - groundDistance));
    }

    private void collisionCheck()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, ground);
    }
    private void AddHoney()
    {
        honey += 1;
        HoneyCount.text = $"x{honey}";
    }
    void playerAnim()
    {
        PlayerState states;
        if (Mathf.Abs(moveSpeed)>0)
        {
            states = PlayerState.run;
        }
        else
        {
            states = PlayerState.JasonAnimator;
        }
        if (rb.velocity.y>0.1f)
        {
            states = PlayerState.jump;
        }
        anim.SetInteger("state", (int)states);
    }
}
