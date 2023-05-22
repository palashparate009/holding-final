using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastFor : MonoBehaviour
{
    
    public RaycastHit hit;
    public GameObject falling;
    
    
    // public GameObject Floor;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        RayForFalling();
    }
    private void RayForFalling()
    {

        Physics.Raycast(falling.transform.position, Vector3.down, out hit, 0.99f);
        Debug.DrawRay(falling.transform.position, Vector3.down, Color.red);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Floor"))
            {

                gameObject.SetActive(false);
                hit.collider.gameObject.SetActive(false);
                GameManager.instance.PoolingScript.GetTiles(hit.collider.gameObject);


            }
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Floor"))
    //    {

    //        //Debug.LogError("STOP WHILE HITTING");
          
    //            gameObject.SetActive(false);
               
            
            
    //    }
    //}

}
