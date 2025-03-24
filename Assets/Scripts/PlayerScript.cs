using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float speed = 4.0f;
    Rigidbody2D rb; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        rb.linearVelocity = new Vector2(horizontal * speed, vertical * speed);

        if(horizontal  > 0)
        {
            GetComponent<Animator>().Play("Right");
        } else if(horizontal  < 0)
        {
            GetComponent<Animator>().Play("Left");
        } else if(vertical  > 0)
        {
            GetComponent<Animator>().Play("Up");
        } else if(vertical  < 0)
        {
            GetComponent<Animator>().Play("Down");
        }
    }
}
