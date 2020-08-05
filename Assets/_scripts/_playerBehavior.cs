using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _playerBehavior : MonoBehaviour
{
    _playerAttributes playerAttributes;
    _playerMovement playerMovement;
    public GameObject player;
    public GameObject shootPrefab;
    public float speedShooting =5f;
    _cooldown cooldown;
    void Start()
    {
        playerAttributes = GetComponent<_playerAttributes>();
        playerMovement = GetComponent<_playerMovement>();
        cooldown = new _cooldown();
    }

  
    void Update()
    {
      if(Input.GetButton("Fire1"))
        {
            Shoot();
        }

     
    }
    public void enemyHasBeenShot(Collider2D bulletCol, GameObject enemy)
    {
        enemy.GetComponent<_enemyBehavior>().ApplyDamage(randDamage());
        Destroy(bulletCol.gameObject);
    }
    
    int randDamage()
    {
        return Random.Range(playerAttributes.minDamage, playerAttributes.maxDamage);
    }
    void Shoot()
    {
        Debug.Log(playerAttributes.shootCooldown);
        cooldown.wait(playerAttributes.shootCooldown);

        GameObject newShoot = Instantiate(shootPrefab, transform.position, transform.rotation) as GameObject;
            
        Rigidbody2D newShootRB = newShoot.GetComponent<Rigidbody2D>();
            // newShootRB.AddForce(Vector2.right * speedShooting);
            //Vector3 direction = new Vector3(0,player.transform.eulerAngles.y, player.transform.eulerAngles.z);
            //direction = direction.normalized;
            //newShootRB.AddForce(direction * speedShooting);
            switch (playerMovement._direction) // idk why i didnt use just player rotation
            {
                case _playerMovement.playerDirection.right:
                    {
                        newShootRB.AddForce(Vector2.right * speedShooting);
                        break;
                    }
                case _playerMovement.playerDirection.left:
                    {
                        newShootRB.AddForce(Vector2.left * speedShooting);
                        break;
                    }
                case _playerMovement.playerDirection.up:
                    {
                        newShootRB.AddForce(Vector2.up * speedShooting);
                        break;
                    }
                case _playerMovement.playerDirection.down:
                    {
                        newShootRB.AddForce(Vector2.down * speedShooting);
                        break;
                    }
                case _playerMovement.playerDirection.rightUp:
                    {
                        Vector2 dir;
                        dir = Vector2.up + Vector2.right;
                        dir = dir.normalized;
                        newShootRB.AddForce(dir * speedShooting);

                        break;
                    }
                case _playerMovement.playerDirection.rightDown:
                    {
                        Vector2 dir;
                        dir = Vector2.down + Vector2.right;
                        dir = dir.normalized;
                        newShootRB.AddForce(dir * speedShooting);
                        break;
                    }
                case _playerMovement.playerDirection.leftUp:
                    {
                        Vector2 dir;
                        dir = Vector2.up + Vector2.left;
                        dir = dir.normalized;
                        newShootRB.AddForce(dir * speedShooting);
                        break;
                    }
                case _playerMovement.playerDirection.leftDown:
                    {
                        Vector2 dir;
                        dir = Vector2.down + Vector2.left;
                        dir = dir.normalized;
                        newShootRB.AddForce(dir * speedShooting);
                        break;
                    }
            }
         
            
       
    }
}
