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
    public float horizontalCatchup = 0.5f;
    public Camera mainCamera;

    public bool isIdle = true;

    bool facingRight = true;
    bool isGrounded = true;
    bool jumpKeyHeld = false;
    bool isJumping = false;
    //bool isJumping = false;
    Vector3 cameraPos;
    Rigidbody2D r2d;
    public float r2dX;
    //float r2dY;
    Transform t;
    Animator anim;

    Transform childT;

    [SerializeField]
    GameObject gC;

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        anim = GetComponentInChildren<Animator>();
        t = transform;
        r2d = GetComponent<Rigidbody2D>();
        r2dX = r2d.position.x;
        //r2dY = r2d.position.y;
        r2d.freezeRotation = true;
        r2d.simulated = false;
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        r2d.gravityScale = gravityScale;
        facingRight = t.localScale.x > 0;

        childT = GetComponentInChildren<Transform>();

        if (mainCamera)
        {
            cameraPos = mainCamera.transform.position;
        }

        anim.SetBool("isIdle", true);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded && !jumpKeyHeld && !isIdle)
            {
                isJumping = true;
                r2d.velocity = new Vector2(r2d.velocity.x, r2d.velocity.y + initJumpForce);
            }

            isIdle = false; //and it will never be idle again
            anim.SetBool("isIdle", false);

            jumpKeyHeld = true;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            jumpKeyHeld = false;
            isJumping = false;
        }

        anim.SetBool("isJumping", !isGrounded);

        if (mainCamera)
        {
            mainCamera.transform.position = new Vector3(t.position.x, cameraPos.y, cameraPos.z);
        }

    }

    void FixedUpdate()
    {
        if (isIdle)
        {
            //no physics updates
            r2d.simulated = false;
            return;
        }
        else
        {
            r2d.simulated = true;
        }

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
        else //Else, do corrections
        {
            // Too far right, bring back left
            if (r2d.position.x > r2dX)
            {
                r2d.velocity = new Vector2(r2d.velocity.x - horizontalCatchup, r2d.velocity.y);
            }
            else if (r2d.position.x < r2dX)
            {
                r2d.velocity = new Vector2(r2d.velocity.x + horizontalCatchup, r2d.velocity.y);
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
