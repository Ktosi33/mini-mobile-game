using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _enemyMovement : MonoBehaviour
{
    //Vector2 move;
    Vector2 targetPosition;
    //public _playerAttributes playerAttributes;
    public Rigidbody2D _rigidbody;
   public _enemyAttributes enemyAttributes;
    public GameObject player;
   
    // Start is called before the first frame update
    void Start()
    {
        //playerAttributes = GetComponent<_playerAttributes>();
        enemyAttributes = GetComponent<_enemyAttributes>();
        _rigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        targetPosition = new Vector2(player.transform.position.x, player.transform.position.y);
       
       // move = targetPosition.normalized;
        if (targetPosition.normalized.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
           
        }
        else if (targetPosition.normalized.x < 0)
        {
            transform.eulerAngles = new Vector3(180, 0, -180);
           
        }
        if (targetPosition.normalized.y > 0.4)
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
           
        }
        else if (targetPosition.normalized.y < -0.4)
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
            
        }
        // transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * enemyAttributes.runSpeed);
        // //there is not collision detection :(


        _rigidbody.velocity = (targetPosition-(new Vector2(this.transform.position.x, this.transform.position.y))).normalized  * Time.fixedDeltaTime * enemyAttributes.runSpeed;
       
       
    }
}
