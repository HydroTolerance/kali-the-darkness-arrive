using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MeleeAttack : MonoBehaviour
{
  
     public Animator playerAnim;
    public float attackDelay;
    public Transform weaponTransform;
    public float weaponRange;
    public int weaponDamage;
    public LayerMask enemyLayer;

    public float timer;
    private float coolDown = 0.8f;
    public float Kbforce;

    public float speed = 5f;

    private Vector3 playerInput;
    bool flipped;
    Rigidbody2D rb;
    [SerializeField] int jumpPower;
    private Animator anim;
    public Transform groudnCheck;
    public LayerMask groundLayer;
    bool isGrounded;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    isGrounded = Physics2D.OverlapCapsule(groudnCheck.position, new Vector2(1.8f, 0.3f), CapsuleDirection2D.Horizontal, 0, groundLayer);


        timer -= Time.deltaTime;
        if(Input.GetButton("Fire1") && timer <= 0) {
            StartCoroutine(Attack1());
            timer = coolDown;
        }

        playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.position = transform.position + playerInput.normalized * speed * Time.deltaTime;
            if (playerInput == Vector3.zero)
            {
                playerAnim.SetBool("isRunning", false);
            }
            else
                playerAnim.SetBool("isRunning", true);


            //Flipped
            if(playerInput.x < 0)
                {
                    flipped = true;
                    this.transform.localScale = new Vector3(-1f, 1f, 1f);
                }

            else if(playerInput.x > 0)
                {
                    flipped = false;
                    this.transform.localScale = new Vector3(1f, 1f, 1f);
                }

        //Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

    }

    IEnumerator Attack1()
    {
        playerAnim.Play("Swordslash");
        Collider2D enemy= Physics2D.OverlapCircle(weaponTransform.position, weaponRange, enemyLayer);
        yield return new WaitForSeconds(attackDelay);
        bool facingRight =(transform.position.x < enemy.transform.position.x);
        enemy.GetComponent<EnemyHealth>().TakeDamage(weaponDamage,facingRight,Kbforce);

    }
}