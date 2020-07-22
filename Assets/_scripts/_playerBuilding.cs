using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _playerBuilding : MonoBehaviour
{
   public GameObject wallPrefab;
   public _playerMovement _plMovement;
    public float distance = 2f;

    void Update()
    {
      if(Input.GetKeyDown("space"))
        {
            Vector3 positionPlayer = transform.position;
          
            switch(_plMovement._direction)
            {
                case _playerMovement.playerDirection.right:
                    {
                        Quaternion angel = new Quaternion();
                        angel = Quaternion.Euler(0, 0, 0);
                        Instantiate(wallPrefab, new Vector2(positionPlayer.x + distance, positionPlayer.y), angel);
                        break;
                    }
                case _playerMovement.playerDirection.left:
                    {
                        Quaternion angel = new Quaternion();
                        angel = Quaternion.Euler(180, 0, -180);
                        Instantiate(wallPrefab, new Vector2(positionPlayer.x - distance, positionPlayer.y), angel);
                        break;
                    }
                case _playerMovement.playerDirection.up:
                    {
                        Quaternion angel = new Quaternion();
                        angel = Quaternion.Euler(0, 0, 90);
                        Instantiate(wallPrefab, new Vector2(positionPlayer.x, positionPlayer.y + distance), angel);
                        break;
                    }
                case _playerMovement.playerDirection.down:
                    {
                        Quaternion angel = new Quaternion();
                        angel = Quaternion.Euler(0, 0, -90);
                        Instantiate(wallPrefab, new Vector2(positionPlayer.x, positionPlayer.y - distance), angel);
                        break;
                    }
                    
            }
        }
            
    }
}
