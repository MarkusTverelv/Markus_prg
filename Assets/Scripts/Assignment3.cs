using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment3 : ProcessingLite.GP21
{
    public Vector2 circlePosition;
    public float circleDiameter;
    Vector2 velocity;

    public float speed;
    public float maxSpeed;

    private void Start()
    {
        Background(0, 0, 0);
        circlePosition = new Vector2(Width / 2, Height / 2);
    }

    // Update is called once per frame
    void Update()
    {
        Background(0, 0, 0);

        if (Input.GetMouseButtonDown(0))
        {
            circlePosition = new Vector2(MouseX, MouseY);
            velocity = Vector2.zero;
        }
        if (Input.GetMouseButtonUp(0))
            velocity = new Vector2(MouseX, MouseY) - circlePosition;

        if (Input.GetMouseButton(0))
            Line(circlePosition.x, circlePosition.y, MouseX, MouseY);

        circlePosition += velocity * speed * Time.deltaTime;
        Circle(circlePosition.x, circlePosition.y, circleDiameter);

        Bounce();
    }

    private void Bounce()
    {
        if (circlePosition.y + circleDiameter / 2 >= Height || circlePosition.y - circleDiameter / 2 <= 0)
        {
            velocity.y *= -1;
            Fill(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));
        }
        if (circlePosition.x + circleDiameter / 2 >= Width || circlePosition.x - circleDiameter / 2 <= 0)
        {
            velocity.x *= -1;
            Fill(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));
        }

    }
}
