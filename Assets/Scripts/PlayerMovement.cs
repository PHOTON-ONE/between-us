using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool canMove;
    public Rigidbody2D rb2d;
    public float speed;
    public Animator animator;
    public Transform rotate;
    [HideInInspector]
    public bool isMoving;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rotate = GetComponent<Transform>();
        canMove = false;
    }
    void FixedUpdate()
    {
        if (!canMove) return;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(horizontal, vertical);
        if (horizontal < 0)
        {
            rotate.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        }
        else if (horizontal > 0)
        {
            rotate.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        if ((vertical != 0) || (horizontal != 0))
        {
            animator.SetBool("IsWalking", true);
            isMoving = true;
        }
        else 
        {
            animator.SetBool("IsWalking", false);
            isMoving = false;
        }
        rb2d.AddForce(movement * speed * Time.fixedDeltaTime);
    }
}
