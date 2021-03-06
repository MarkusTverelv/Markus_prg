using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Assignment5 : ProcessingLite.GP21
{
    Player playerClass = new Player();
    BallManager ballManager;

    public Canvas mainCanvas;
    public Text timerText;

    float timer;

    private void Awake()
    {
        ballManager = new BallManager(playerClass, mainCanvas);
        playerClass.PlayerPosition = new Vector2(Width / 2, Height / 2); //middle of the screen

        Time.timeScale = 1;
        mainCanvas.enabled = false;
    }
    void Start()
    {
        ballManager.CreateBalls();
    }

    void Update()
    {
        Background(0);

        timer += Time.deltaTime;
        timerText.text = timer.ToString();

        Circle(playerClass.PlayerPosition.x, playerClass.PlayerPosition.y, playerClass.Size);

        playerClass.Move();
        ballManager.UpdateBalls();
        playerClass.ScreenWarp(Width, Height);
    }
}

class Player
{
    private Vector2 position;
    private Vector2 velocity;
    private Vector2 acceleration;

    private float speed = 10.0f;
    private float maxSpeed = 1.0f;
    private float size = 2;

    public Vector2 PlayerPosition
    {
        get { return position; }
        set
        {
            if (position != null)
                position = value;
        }
    }
    public float Size
    {
        get { return size; }
        set
        {
            if (size != 0)
                size = value;
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
    private Vector2 position; //Ball position
    private Vector2 velocity; //Ball direction
    private float size = 2;

    public Vector2 Position     //Property with get access
    {
        get { return position; }
    }
    public float Size       //Property with get access
    {
        get { return size; }
    }

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
        Bounce();
    }

    private void Bounce()
    {
        if (position.y + size / 2 >= Height || position.y - size / 2 <= 0)
            velocity.y *= -1;

        if (position.x + size / 2 >= Width || position.x - size / 2 <= 0)
            velocity.x *= -1;
    }
}
class BallManager : ProcessingLite.GP21
{
    Player player;
    Ball[] balls; 
    Canvas mainCanvas;

    int numberOfBalls = 10;

    public BallManager(Player playerClass, Canvas canvas)
    {
        player = playerClass;
        balls = new Ball[numberOfBalls];
        mainCanvas = canvas;
    }

    public void CreateBalls()
    {
        //A loop that creates multiple balls.
        for (int i = 0; i < balls.Length; i++)
            balls[i] = new Ball(Random.Range(5, Width - 5), Random.Range(5, Height - 5));
    }

    public void UpdateBalls()
    {
        //Tell each ball to update it's position
        for (int i = 0; i < balls.Length; i++)
        {
            balls[i].UpdatePos();
            balls[i].Draw();

            CircleCollision(player, balls[i]);
        }
    }

    bool CircleCollision(Player player, Ball ball)
    {
        float maxDistance = player.Size / 2 + ball.Size / 2;

        //first a quick check to see if we are too far away in x or y direction
        //if we are far away we don't collide so just return false and be done.
        if (Mathf.Abs(player.PlayerPosition.x - ball.Position.x) > maxDistance || Mathf.Abs(player.PlayerPosition.y - ball.Position.y) > maxDistance)
            return false;

        //we then run the slower distance calculation
        //Distance uses Pythagoras to get exact distance, if we still are to far away we are not colliding.
        else if (Vector2.Distance(new Vector2(player.PlayerPosition.x, player.PlayerPosition.y), new Vector2(ball.Position.x, ball.Position.y)) > maxDistance)
            return false;

        //We now know the points are closer then the distance so we are colliding!
        else
        {
            Time.timeScale = 0;
            mainCanvas.enabled = true;
            return true;
        }
    }
}
