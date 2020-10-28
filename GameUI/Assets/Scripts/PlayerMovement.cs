using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Photon.Pun.MonoBehaviourPun
{
    [SerializeField]
    float moveSpeed = 5f;

    Rigidbody2D rb;
    GameObject otherPlayer;

    Touch touch;
    Vector3 touchPosition, whereToMove;
    bool isMoving = false;
    bool isLeft = true;

    float previousDistanceToTouchPos, currentDistanceToTouchPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();        
    }

    void Update()
    {
        //if(this.gameObject.tag == "Player")
        //{
        //    otherPlayer = GameObject.FindGameObjectWithTag("PlayerRed");
        //}
        //else if(this.gameObject.tag == "PlayerRed")
        //{
        //    otherPlayer = GameObject.FindGameObjectWithTag("Player");
        //}

        //Physics.IgnoreCollision(this.gameObject.GetComponent<Collider>(), otherPlayer.GetComponent<Collider>());

        if (isMoving)
            currentDistanceToTouchPos = (touchPosition - transform.position).magnitude;

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                previousDistanceToTouchPos = 0;
                currentDistanceToTouchPos = 0;
                isMoving = true;
                touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0;
                whereToMove = (touchPosition - transform.position).normalized;
                rb.velocity = new Vector2(whereToMove.x * moveSpeed, whereToMove.y * moveSpeed);

                if (touchPosition.x > transform.position.x && isLeft == false)
                {
                    transform.RotateAround(transform.position, new Vector2(0f, 1f), 180f);
                    isLeft = true;
                }
                else if (touchPosition.x < transform.position.x && isLeft == true)
                {
                    transform.RotateAround(transform.position, new Vector2(0f, 1f), -180f);
                    isLeft = false;

                }
            }
        }

        if (currentDistanceToTouchPos > previousDistanceToTouchPos)
        {
            isMoving = false;
            rb.velocity = Vector2.zero;
        }

        if (isMoving)
            previousDistanceToTouchPos = (touchPosition - transform.position).magnitude;
    }
}
