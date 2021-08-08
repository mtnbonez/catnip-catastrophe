using UnityEngine;

//[RequireComponent(typeof(Rigidbody2D))]
//[RequireComponent(typeof(BoxCollider2D))]

public class PlayerController : MonoBehaviour
{

    public float maxSpeed = 3.4f;
    public float initJumpForce = 3f;
    public float longJumpForce = 1f;
    public float gravityScale = 1.5f;
    public float maxJumpForce = 10f;
    public Camera mainCamera;

    bool facingRight = true;
    bool isGrounded = false;
    bool jumpKeyHeld = false;
    bool isJumping = false;
    //bool isJumping = false;
    Vector3 cameraPos;
    Rigidbody2D r2d;
    Transform t;
    Animator anim;

    [SerializeField]
    GameObject gC;
    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        anim = GetComponentInChildren<Animator>();
        t = transform;
        r2d = GetComponent<Rigidbody2D>();
        r2d.freezeRotation = true;
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        r2d.gravityScale = gravityScale;
        facingRight = t.localScale.x > 0;

        if (mainCamera)
        {
            cameraPos = mainCamera.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            
            if (isGrounded && !jumpKeyHeld)
            {
                isJumping = true;
                r2d.velocity = new Vector2(r2d.velocity.x, r2d.velocity.y + initJumpForce);
            }
            
            jumpKeyHeld = true;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            jumpKeyHeld = false;
            isJumping = false;
        }

        anim.SetBool("isJumping", isJumping);

        if (mainCamera)
        {
            mainCamera.transform.position = new Vector3(t.position.x, cameraPos.y, cameraPos.z);
        }

    }

    void FixedUpdate()
    {
        if (isJumping)
        {
            if (r2d.velocity.y >= maxJumpForce)
            {
                isJumping = false;
            }
            else
            {
                //r2d.velocity = new Vector2(r2d.velocity.x, Mathf.Min(r2d.velocity.y + jumpForce, maxJumpForce));
                r2d.velocity = new Vector2(r2d.velocity.x, r2d.velocity.y + longJumpForce);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }

        Debug.Log("Collision ENTER with: " + collision.gameObject.name);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = false;
        }

        Debug.Log("Collision EXIT with: " + collision.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "TunaCoin")
        {
            gC.GetComponent<TunaCoinPoints>().score += 10;

            Destroy(other.gameObject);
        }
    }
}
