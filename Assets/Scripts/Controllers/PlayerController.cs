using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] Rigidbody rb;
    [SerializeField] float speed = 10.0f;  
    [SerializeField] float horizontalSpeed = 2.5f;
    [SerializeField] GameController gameController;

    private Vector2 fingerUp;
    private Vector2 fingerDown;
    public float SWIPE_THRESHOLD = 20f;
    private Vector3 playerInitialPosition;
    public bool detectSwipeOnlyAfterRelease = false;
    
    // Start is called before the first frame update
    void Start()
    {
        playerInitialPosition = rb.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        MoveHorizontal();

    }

    void FixedUpdate()
    {
        
        if (gameController.GetState() == GameState.PLAY)
            rb.velocity = new Vector3(horizontalSpeed, rb.velocity.y, speed);

        if (gameController.GetState() == GameState.POOL)
            rb.velocity = Vector3.zero;

        if (gameController.GetState() == GameState.MENU)
            rb.transform.position = playerInitialPosition;

    }

    public void PlayerPositionReset()
    {
        rb.transform.position = playerInitialPosition;
    }

    void MoveHorizontal()
    {

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUp   = touch.position;
                fingerDown = touch.position;
            }

            // detects Swipe while finger is still moving
            if (touch.phase == TouchPhase.Moved)
            {
                if (!detectSwipeOnlyAfterRelease)
                {
                    fingerDown = touch.position;
                    CheckSwipe();
                }
            }

            // detects swipe after finger is released
            if (touch.phase == TouchPhase.Ended)
            {
                fingerDown = touch.position;
                CheckSwipe();
            }

        }

    }

    void CheckSwipe()
    {

        if (horizontalValMove() > SWIPE_THRESHOLD && horizontalValMove() > verticalMove())
        {

            if (fingerDown.x - fingerUp.x > 0)
            {
                horizontalSpeed = +2.5f;
            }
            else if (fingerDown.x - fingerUp.x < 0)
            {
                horizontalSpeed = -2.5f;
            }

            fingerUp = fingerDown;

        }else {
            horizontalSpeed = 0.0f;
        }

    }

    float verticalMove()
    {
        return Mathf.Abs(fingerDown.y - fingerUp.y);
    }

    float horizontalValMove()
    {
        return Mathf.Abs(fingerDown.x - fingerUp.x);
    }

}
