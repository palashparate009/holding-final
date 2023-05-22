using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
   
    public List<GameObject> Tiles = new List<GameObject>();
    //public Transform RefPosition;


    void Start()
    {
        
    }

    public void GetTiles(GameObject GObj)
    {
       
            // GObj.transform.position = RefPosition.position;
            GObj.SetActive(false);
            GObj.GetComponent<MeshCollider>().enabled = true;

            Tiles.Add(GObj);
        
    }

    float Timer = 10f;
    int Rand = 0;
    private void Update()
    {
        
        
        if(Timer <= 0f)
        {
            if (Tiles.Count > 0)
            {
                Rand = Random.Range(0, Tiles.Count);
                Tiles[Rand].SetActive(true);
                Tiles.RemoveAt(Rand);
            }
            Timer = 5f;
        }
        else
        {
            Timer -= Time.deltaTime;
        }

    }

}

