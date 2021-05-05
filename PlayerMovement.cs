using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2f;
    private float halfScreenWidth;
    Vector2 velocity;
    float halfPlayerWidth;
    Rigidbody2D myRigidBody;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        halfPlayerWidth = transform.localScale.x / 2;
        halfScreenWidth = Camera.main.aspect * Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 direction = input.normalized;
        velocity = direction * speed;

        if (transform.position.x < -(halfScreenWidth + halfPlayerWidth))
        {
            transform.position = new Vector2(halfScreenWidth, transform.position.y);
        }
        if (transform.position.x > (halfScreenWidth + halfPlayerWidth))
        {
            transform.position = new Vector2(-halfScreenWidth, transform.position.y);
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(velocity * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if(triggerCollider.CompareTag("fallingBlock"))
        {
            Destroy(gameObject);
        }
    }
}
