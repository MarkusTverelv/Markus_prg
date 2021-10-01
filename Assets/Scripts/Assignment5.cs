using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Assignment5 : ProcessingLite.GP21
{
    Player playerClass = new Player();
    BallManager ballManager;
    public Canvas mainCanvas;
    float timer;
    public Text timerText;

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
        timer += Time.deltaTime;
        timerText.text = timer.ToString();
        Background(0);
        playerClass.Move();
        Circle(playerClass.PlayerPosition.x, playerClass.PlayerPosition.y, playerClass.Size);
        ballManager.UpdateBalls();
        playerClass.ScreenWarp(Width, Height);
    }
}

class Player
{
    private Vector2 position;
    private float speed = 10.0f;
    private float maxSpeed = 1.0f;
    private Vector2 velocity;
    private Vector2 acceleration;
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

    public Vector2 Position
    {
        get { return position; }
    }
    public float Size
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
    int numberOfBalls = 10;
    Ball[] balls;
    Canvas mainCanvas;

    public BallManager(Player playerClass, Canvas canvas)
    {
        player = playerClass;
        balls = new Ball[numberOfBalls];
        mainCanvas = canvas;
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

            CircleCollision(player.PlayerPosition.x, player.PlayerPosition.y, player.Size, balls[i].Position.x, balls[i].Position.y, balls[i].Size);
        }
    }
    bool CircleCollision(float x1, float y1, float size1, float x2, float y2, float size2)
    {
        float maxDistance = size1 / 2 + size2 / 2;

        //first a quick check to see if we are too far away in x or y direction
        //if we are far away we don't collide so just return false and be done.
        if (Mathf.Abs(x1 - x2) > maxDistance || Mathf.Abs(y1 - y2) > maxDistance)
        {
            return false;
        }
        //we then run the slower distance calculation
        //Distance uses Pythagoras to get exact distance, if we still are to far away we are not colliding.
        else if (Vector2.Distance(new Vector2(x1, y1), new Vector2(x2, y2)) > maxDistance)
        {
            return false;
        }
        //We now know the points are closer then the distance so we are colliding!
        else
        {
            Time.timeScale = 0;
            mainCanvas.enabled = true;
            return true;
        }
    }
}
