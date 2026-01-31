using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 0.1f;
    Vector2 moveValue;

    Rigidbody2D rigidbody;
    Animator animator;
    BoxCollider2D bodyCollider;
    CapsuleCollider2D feetCollider;

    float gravityScaleAtStart;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        bodyCollider = GetComponent<BoxCollider2D>();
        feetCollider = GetComponent<CapsuleCollider2D>();
    }
    private void Start()
    {
        gravityScaleAtStart = rigidbody.gravityScale;
    }

    private void FixedUpdate()
    {
        Run();
        FlipSprite();
        ClimbLadder();
        //Die();
    }

    void OnMove(InputValue value)
    {
        moveValue = value.Get<Vector2>();
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveValue.x * runSpeed, rigidbody.linearVelocity.y);
        rigidbody.linearVelocity = playerVelocity;
    }

    void OnJump(InputValue value)
    {
        if (value.isPressed && feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            rigidbody.linearVelocity = new Vector2(rigidbody.linearVelocity.x, jumpSpeed);
        }
    }

    void FlipSprite()
    {
        bool hasHorizontalSpeed = Mathf.Abs(rigidbody.linearVelocity.x) > Mathf.Epsilon;
        if (hasHorizontalSpeed)
        {          
            animator.SetBool("isRunning", true);
            transform.localScale = new Vector2(Mathf.Sign(rigidbody.linearVelocity.x), 1f);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    //  Climbing
    void ClimbLadder()
    {
        if (!feetCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            rigidbody.gravityScale = gravityScaleAtStart;
            return;
        }
        Vector2 playerlinearVelocity = new Vector2(rigidbody.linearVelocity.x, moveValue.y * climbSpeed);
        rigidbody.linearVelocity = playerlinearVelocity;
        rigidbody.gravityScale = 0f;
    }

    //  Dying
    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Die");
    }


}
