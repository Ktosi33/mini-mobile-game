using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _enemyBehavior : MonoBehaviour
{
    public _enemyAttributes enemyAttributes;
    public _playerBehavior playerBehavior;
    void Start()
    {
        enemyAttributes = GetComponent<_enemyAttributes>();
        playerBehavior = GameObject.FindGameObjectWithTag("Player").GetComponent<_playerBehavior>();

    }
   
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Bullet")
        {
            playerBehavior.enemyHasBeenShot(collision);
        }

    }
    public void ApplyDamage(int dmg)
    {
        enemyAttributes.hp -= dmg;
        Debug.Log("Enemy HP: " + enemyAttributes.hp);

        if (enemyAttributes.hp < 0)
        {
            EnemyDying();
        }
    }  
    void EnemyDying()
    {
        GameObject.Destroy(this.gameObject);
    }
    int randDamage()
    {
        return Random.Range(enemyAttributes.minDamage, enemyAttributes.maxDamage);
    }
}
