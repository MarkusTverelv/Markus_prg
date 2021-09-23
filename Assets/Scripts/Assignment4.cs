using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment4 : ProcessingLite.GP21
{
    float xMovement = 0.0f;
    float yMovement = 0.0f;

    [Range(0.005f, 1.0f)]
    public float maxSpeed;
    public float speed;

    Vector2 circlePosition;
    Vector2 squarePosition;

    Vector2 moveDirection;
    Vector2 squareVelocity;

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

        xMovement = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        yMovement = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;

        Circle(circlePosition.x, circlePosition.y, 2);
        Square(squarePosition.x, squarePosition.y, 2);

        moveDirection = new Vector2(xMovement, yMovement);
        moveDirection.Normalize();

        MoveCircle();
        MoveSquare();

        ScreenWarp();
    }
    private void ScreenWarp()
    {
        squarePosition.x = (squarePosition.x + Width) % Width;
        squarePosition.y = (squarePosition.y + Height) % Height;

        circlePosition.x = (circlePosition.x + Width) % Width;
        circlePosition.y = (circlePosition.y + Height) % Height;

        //if (circlePosition.x >= Width)
        //    circlePosition.x = 0;
        //else if (circlePosition.x <= 0)
        //    circlePosition.x = Width;

        //if (squarePosition.x >= Width)
        //    squarePosition.x = 0;
        //else if (squarePosition.x <= 0)
        //    squarePosition.x = Width;

        //if (circlePosition.y >= Height)
        //    circlePosition.y = 0;
        //else if (circlePosition.y <= 0)
        //    circlePosition.y = Height;

        //if (squarePosition.y >= Height)
        //    squarePosition.y = 0;
        //else if (squarePosition.y <= 0)
        //    squarePosition.y = Height;
    }
    private void MoveCircle()
    {
        circlePosition += new Vector2(xMovement, yMovement);
    }
    private void MoveSquare()
    {
        squareVelocity += moveDirection * Time.deltaTime;

        if (squareVelocity.magnitude > maxSpeed)
            squareVelocity = squareVelocity.normalized * maxSpeed;
        else if (moveDirection == Vector2.zero)
            squareVelocity *= 0.993f;
        
        squarePosition += squareVelocity;
    }
}
