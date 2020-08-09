using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class _grid : MonoBehaviour
{
   public GameObject backgroundForGrid;
   public GameObject gridPrefab;

    private void Start()
    {
        float height = gridPrefab.GetComponent<Renderer>().bounds.size.y;
        float width = gridPrefab.GetComponent<Renderer>().bounds.size.x;
        float heightToFill = backgroundForGrid.GetComponent<Renderer>().bounds.size.y;
        float widthToFill = backgroundForGrid.GetComponent<Renderer>().bounds.size.x;
        Vector3 startPoint = backgroundForGrid.transform.position - backgroundForGrid.GetComponent<Renderer>().bounds.size / 2;
        Vector3 endPoint = backgroundForGrid.transform.position + backgroundForGrid.GetComponent<Renderer>().bounds.size / 2;
        endPoint.x += width;
        endPoint.y += height;
        startPoint.x -= width;
        startPoint.x -= height;
        startPoint.z = 0;
        endPoint.z = 0;


         float startPointX = startPoint.x;
       while (startPoint.y<=endPoint.y + height)
        {
            while( startPoint.x <= endPoint.x + width)
            {
                Instantiate(gridPrefab,startPoint,Quaternion.identity);
                startPoint.x += width;
            }
            startPoint.x = startPointX;


            startPoint.y += height;


        }   
    
        
    }

}
