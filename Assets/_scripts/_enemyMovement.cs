using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _enemyMovement : MonoBehaviour
{

    Vector2 targetPosition;
    public Rigidbody2D _rigidbody;
    public _enemyAttributes enemyAttributes;
    public GameObject player;
   

    void Start()
    {
     
        enemyAttributes = GetComponent<_enemyAttributes>();
        _rigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        
    }


    void FixedUpdate()
    {
        targetPosition = new Vector2(player.transform.position.x, player.transform.position.y);
    

        Vector3 diff = player.transform.position - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
      
        _rigidbody.velocity =
       (
       targetPosition-
       (new Vector2(this.transform.position.x, this.transform.position.y))).normalized 
       * Time.fixedDeltaTime
       * enemyAttributes.runSpeed;
     
       
    }
}
