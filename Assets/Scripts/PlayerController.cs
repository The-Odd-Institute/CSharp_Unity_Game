using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;

    Rigidbody rb;

    // each time, player taps, this becomes true
    bool fire = false;

    // 02-Player
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            fire = true;

        if (GameManager.instance.gameStatus == Modes.paused)
        {
            if (fire)
                begin();
        }
        else if (GameManager.instance.gameStatus == Modes.running)
        {
            // if there's nothing beneath us
            if (!Physics.Raycast(   gameObject.transform.position,
                                    Vector3.down,
                                    10))
            {
                rb.velocity = new Vector3(0, -25.0f, 0);
                GameManager.instance.EndGame();
            }
            else
            {
                if (fire)
                {
                    ChangePlayerDirection();
                    fire = false;
                }
            }
        }

        // let's make the game harder
        moveSpeed += .001f;
    }


    void begin()
    {
        rb.velocity = new Vector3(moveSpeed, 0, 0);
        GameManager.instance.StartGame();
        fire = false;
    }

    void ChangePlayerDirection()
    {
        // switch the direction of the movement

        // moveSpeed -> 5
        if (rb.velocity.z > 0) // moving on the Z Direction
            rb.velocity = new Vector3(moveSpeed, 0, 0); // let's go on the x

        else if (rb.velocity.x > 0) // moving on the X direction
            rb.velocity = new Vector3(0, 0, moveSpeed); // let's go on the Z
    }
}