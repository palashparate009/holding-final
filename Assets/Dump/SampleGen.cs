using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleGen : MonoBehaviour
{
    List<GameObject> falling = new List<GameObject>(); 
    int i = 0, j = 0, ColumnCount = 0;
    float Tx = -0.5f, Tz = 0;
    public GameObject Prefab;

    void Start()
    {
        for(i = 0; i< 3; i++)
        {
            
            if(i%2 == 0)
            {
                Tx = -0.5f;
                ColumnCount = 11;
              
            }
            else
            {
                Tx = 0f;
                ColumnCount = 10;
               
            }


            for(j = 0; j< ColumnCount; j++)
            {
                    var g = Instantiate(Prefab, new Vector3((float)Tx, 0f,Tz), Quaternion.identity);
                    g.gameObject.name = j.ToString();
                    Tx += 1;
               falling.Add(g);
            }
           
            Tz += 0.86f;
        }

    }

}
