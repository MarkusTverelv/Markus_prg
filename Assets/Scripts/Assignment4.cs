using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment4 : ProcessingLite.GP21
{
    float xMovement = 0.0f;
    float yMovement = 0.0f;

    public float maxSpeed;
    public float circleSpeed;
    public float squareVelocity = 10.0f;
    public int acceleration;

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

        Move();
        ScreenWarp();
    }
    private void ScreenWarp()
    {
        if (circlePosition.x >= Width)
            circlePosition.x = 0;
        else if (circlePosition.x <= 0)
            circlePosition.x = Width;

        if (squarePosition.x >= Width)
            squarePosition.x = 0;
        else if (squarePosition.x <= 0)
            squarePosition.x = Width;

        if (circlePosition.y >= Height)
            circlePosition.y = 0;
        else if (circlePosition.y <= 0)
            circlePosition.y = Height;

        if (squarePosition.y >= Height)
            squarePosition.y = 0;
        else if (squarePosition.y <= 0)
            squarePosition.y = Height;
    }
    private void Move()
    {
        if (xMovement != 0 || yMovement != 0)
        {
            circlePosition += dir * Time.deltaTime * circleSpeed;

            squareVelocity += acceleration * Time.deltaTime;
            squarePosition += dir * squareVelocity * Time.deltaTime;
        }
        else
            squareVelocity = 10;

        if (squareVelocity > maxSpeed)
            squareVelocity = maxSpeed;
    }
}
