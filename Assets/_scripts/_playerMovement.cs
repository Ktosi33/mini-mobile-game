using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _playerMovement : MonoBehaviour
{

    public enum playerDirection
    {
        right = 0,
        left,
        up,
        down,
        rightUp,
        rightDown,
        leftUp,
        leftDown
    }

    Rigidbody2D _rigidbody;
    float horizontal=0;
    float vertical=0;
    public playerDirection _direction;
    public float runSpeed = 20.0f;
    Vector2 move;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
      
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        
    }

    private void FixedUpdate() //it have to be in fixedupdate
    {
      
        move = new Vector2(horizontal, vertical);
        move = move.normalized;
        if (move.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            _direction = playerDirection.right;
        }
        else if (move.x < 0)
        {
            transform.eulerAngles = new Vector3(180, 0, -180);
            _direction = playerDirection.left;
        }
        if (move.y > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
            _direction = playerDirection.up;
        }
        else if (move.y < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
            _direction = playerDirection.down;
        }

        if (move.x != 0 && move.y != 0)
        {

            if (move.x > 0)
            {
                if (move.y > 0)
                {
                    _direction = playerDirection.rightUp;
                }
                else
                {
                    _direction = playerDirection.rightDown;
                }
            }
            else
            {
                if (move.y > 0)
                {
                    _direction = playerDirection.leftUp;
                }
                else
                {
                    _direction = playerDirection.leftDown;
                }
            }



        }


        _rigidbody.velocity = Time.deltaTime * move * runSpeed;

    }
}
