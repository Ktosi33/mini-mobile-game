using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _playerBuilding : MonoBehaviour
{
   public GameObject wallPrefab;
   public _playerMovement _plMovement;
    public float distance = 2f;
    Transform position;
    void Update()
    {
         
      if(Input.GetKeyDown("space"))
        {
            Vector3 positionPlayer = transform.position;
          
            switch(_plMovement._direction) // it will not work because there are not vertically grid prefab only horizontally so it work only in x not in y;
            {
                case _playerMovement.playerDirection.right:
                    {
                        Quaternion angel = new Quaternion();
                        angel = Quaternion.Euler(0, 0, 0);
                        Vector2 point = new Vector2(positionPlayer.x + distance, positionPlayer.y);
                        RaycastHit2D hit = Physics2D.Raycast(point, Vector2.zero, Mathf.Infinity);
                        Instantiate(wallPrefab, hit.transform.position, angel);
                            break;
                    }
                case _playerMovement.playerDirection.left:
                    {
                        Quaternion angel = new Quaternion();
                        angel = Quaternion.Euler(180, 0, -180);
                        //Instantiate(wallPrefab, new Vector2(positionPlayer.x - distance, positionPlayer.y), angel);
                        Vector2 point = new Vector2(positionPlayer.x - distance, positionPlayer.y);
                        RaycastHit2D hit = Physics2D.Raycast(point, Vector2.zero, Mathf.Infinity);
                        Instantiate(wallPrefab, hit.transform.position, angel);
                        break;
                    }
                case _playerMovement.playerDirection.up:
                    {
                        Quaternion angel = new Quaternion();
                        angel = Quaternion.Euler(0, 0, 90);
                       // Instantiate(wallPrefab, new Vector2(positionPlayer.x, positionPlayer.y + distance), angel);
                        Vector2 point = new Vector2(positionPlayer.x, positionPlayer.y + distance);
                        RaycastHit2D hit = Physics2D.Raycast(point, Vector2.zero, Mathf.Infinity);
                        Instantiate(wallPrefab, hit.transform.position, angel);
                        break;
                    }
                case _playerMovement.playerDirection.down:
                    {
                        Quaternion angel = new Quaternion();
                        angel = Quaternion.Euler(0, 0, -90);
                       // Instantiate(wallPrefab, new Vector2(positionPlayer.x, positionPlayer.y - distance), angel);
                        Vector2 point = new Vector2(positionPlayer.x, positionPlayer.y - distance);
                        RaycastHit2D hit = Physics2D.Raycast(point, Vector2.zero, Mathf.Infinity);
                        Instantiate(wallPrefab, hit.transform.position, angel);
                        break;
                    }
                    
            }
        }
            
    }
}
