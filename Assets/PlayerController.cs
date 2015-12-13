using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float maxSpeed;
    public float maxJump;
    protected Rigidbody2D body;

    public bool isGrounded = false;

    protected virtual void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        float inputHoriz = Input.GetAxis("Horizontal");
        float inputVert = Input.GetAxis("Vertical");

        //if (Mathf.Abs(inputVert) < 0.1f ) inputVert = 0;
        //if (inputVert > 0) inputVert = 1;
        //if (inputVert < 0) inputVert = -1;

        //body.velocity = new Vector2(inputHoriz * maxSpeed, isGrounded ? inputVert * maxJump : body.velocity.y);
        if (inputVert != 0) {
            body.AddForce(new Vector2(inputVert * maxSpeed, 0));
        }
        if (inputVert != 0) {
            body.AddForce(new Vector2(0,  maxJump));
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") isGrounded = true;
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") isGrounded = false;
    }


}
