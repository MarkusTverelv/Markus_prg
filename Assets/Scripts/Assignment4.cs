using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment4 : ProcessingLite.GP21
{
    [Range(0.005f, 1.0f)]
    public float maxSpeed;
    public float moveSpeed;

    Vector2 circlePosition;
    Vector2 squarePosition;

    Vector2 squareVelocity;

    // Start is called before the first frame update
    void Start()
    {
        squarePosition = new Vector2(Width / 2 + 5, Height / 2);
        circlePosition = new Vector2(Width / 2, Height / 2);
    }

    // Update is called once per frame
    void Update()
    {
        Background(0);

        DrawGeometry();

        MoveCircle();
        MoveSquare();

        ScreenWarpGeometry();
    }

    Vector2 NormalizedDirectionalMovement()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    void DrawGeometry()
    {
        Circle(circlePosition.x, circlePosition.y, 2);
        Square(squarePosition.x, squarePosition.y, 2);
    }

    private void ScreenWarpGeometry()
    {
        squarePosition.x = (squarePosition.x + Width) % Width;
        squarePosition.y = (squarePosition.y + Height) % Height;

        circlePosition.x = (circlePosition.x + Width) % Width;
        circlePosition.y = (circlePosition.y + Height) % Height;
    }

    private void MoveCircle()
    {
        circlePosition += NormalizedDirectionalMovement() * moveSpeed * Time.deltaTime;
    }

    private void MoveSquare()
    {
        squareVelocity += NormalizedDirectionalMovement() * moveSpeed * Time.deltaTime;

        if (squareVelocity.magnitude > maxSpeed)
            squareVelocity = squareVelocity.normalized * maxSpeed;

        else if (NormalizedDirectionalMovement() == Vector2.zero)
            squareVelocity *= 0.993f;

        squarePosition += squareVelocity;
    }
}
