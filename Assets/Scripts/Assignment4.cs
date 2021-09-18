using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment4 : ProcessingLite.GP21
{
    float xMovement = 0.0f;
    float yMovement = 0.0f;

    public float velocity = 10.0f;
    public float speed;
    public int acceleration;
    public float maxSpeed;

    Vector2 dir;
    Vector2 circlePosition;
    Vector2 squarePosition;

    // Start is called before the first frame update
    void Start()
    {
        circlePosition = new Vector2(Width / 2, Height / 2);
        squarePosition = new Vector2(Width / 2 + 5, Height / 2);
    }

    // Update is called once per frame
    void Update()
    {
        Background(0);

        xMovement = Input.GetAxisRaw("Horizontal");
        yMovement = Input.GetAxisRaw("Vertical");

        Circle(circlePosition.x, circlePosition.y, 2);
        Square(squarePosition.x, squarePosition.y, 2);

        dir = new Vector2(xMovement, yMovement);
        dir.Normalize();

        if (xMovement > 0 || yMovement > 0 || xMovement < 0 || yMovement < 0)
        {
            circlePosition += dir * Time.deltaTime * speed;

            velocity += acceleration * Time.deltaTime;
            squarePosition += dir * Time.deltaTime * velocity;
        }
        else
        {
            velocity = 10;
        }
    }
}
