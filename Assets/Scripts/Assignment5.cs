using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment5 : ProcessingLite.GP21
{
    Player playerClass = new Player();
    BallManager ballManager = new BallManager();

    void Start()
    {
        playerClass.PlayerPosition = new Vector2(Width / 2, Height / 2); //middle of the screen
        ballManager.CreateBalls();
    }

    void Update()
    {
        Background(0);
        playerClass.Move();
        playerClass.ScreenWarp(Width, Height);
        Circle(playerClass.PlayerPosition.x, playerClass.PlayerPosition.y, 2);

        ballManager.UpdateBalls();
    }
}

class Player
{
    private Vector2 position;
    private float speed = 10f;
    private float maxSpeed = 0.3f;
    private Vector2 velocity;
    private Vector2 acceleration;

    public Vector2 PlayerPosition
    {
        get { return position; }
        set
        {
            if (position != null)
                position = value;
        }
    }

    public void ScreenWarp(float width, float height)
    {
        position.x = (position.x + width) % width;
        position.y = (position.y + height) % height;
    }
    public void Move()
    {
        //Input from player
        float xMove = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        float yMove = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;

        //Circle 1 with acc.
        acceleration = new Vector2(xMove, yMove);
        velocity += acceleration * Time.deltaTime;

        if (velocity.magnitude > maxSpeed)
            velocity = velocity.normalized * maxSpeed;

        else if (acceleration == Vector2.zero)
            velocity *= 0.995f;

        position += velocity;
    }
}

// We still need to inherence from ProcessingLite
class Ball : ProcessingLite.GP21
{
    //Our class variables
    Vector2 position; //Ball position
    Vector2 velocity; //Ball direction

    float size = 2;
    Color color;

    //Ball Constructor, called when we type new Ball(x, y);
    public Ball(float x, float y)
    {
        //Set our position when we create the code.
        position = new Vector2(x, y);

        //Create the velocity vector and give it a random direction.
        velocity = new Vector2();
        velocity.x = Random.Range(0, 11) - 5;
        velocity.y = Random.Range(0, 11) - 5;
    }

    //Draw our ball
    public void Draw()
    {
        Circle(position.x, position.y, size);
    }

    //Update our ball
    public void UpdatePos()
    {
        position += velocity * Time.deltaTime;
    }
    public void Bounce()
    {
        if (position.y + size / 2 >= Height || position.y - size / 2 <= 0)
            velocity.y *= -1;

        if (position.x + size / 2 >= Width || position.x - size / 2 <= 0)
            velocity.x *= -1;
    }
    public void ChangeColor()
    {
        color.g = Random.Range(0.0f, 255f);
        color.b = Random.Range(0.0f, 255f);
        color.r = Random.Range(0.0f, 255f);
    }
}
class BallManager : ProcessingLite.GP21
{
    int numberOfBalls = 10;
    Ball[] balls;

    public BallManager()
    {
        balls = new Ball[numberOfBalls];
    }
    public void CreateBalls()
    {
        //A loop that can be used for creating multiple balls.
        for (int i = 0; i < balls.Length; i++)
        {
            //Add some code for creating balls here.
            balls[i] = new Ball(Random.Range(5, Width - 5), Random.Range(5, Height - 5));
        }
    }
    public void UpdateBalls()
    {
        //Tell each ball to update it's position
        for (int i = 0; i < balls.Length; i++)
        {
            balls[i].UpdatePos();
            balls[i].Draw();
            balls[i].Bounce();
            balls[i].ChangeColor();
        }
    }
}
