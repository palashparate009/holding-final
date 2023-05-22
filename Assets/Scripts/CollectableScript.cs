using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    private float RandomX;
    private float RandomZ;
    public GameObject Prefab;
    public List<GameObject> tiles;
    public float time;
    public PlayerMovement pm;
    public int r;
    public Vector3 _spawnPos;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        tiles= new List<GameObject>();
        TileAdd();
        
       
    }

    // Update is called once per frame
    void Update()
    {

        CollectibleInstan();
        if(player.transform.position.y<=-2)
        playerspawn();
    }
    private void TileAdd()
    {
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Floor"))
        {
            tiles.Add(g);

        }
        Debug.Log("tiles" + tiles.Count);
    }
    private void CollectibleInstan()
    {
        time += Time.deltaTime;
        if (time >= 3)
        {
             r = Random.Range(0, tiles.Count);
            if (tiles[r] == false)
            {
                return;
            }


            Vector3 spawnpoint = new Vector3(tiles[r].transform.position.x, tiles[r].transform.position.y + 0.4f, tiles[r].transform.position.z);
                Instantiate(Prefab, spawnpoint, Quaternion.identity);
                time = 0;
            
        }
    }
    private void playerspawn()
    {
        //if (tiles[r].activeInHierarchy)
        //{
        //Debug.Log("PLayerSpawn");
        var g = Random.Range(0, tiles.Count);
       // Debug.Log("PLS" + tiles[g].activeInHierarchy);
        if (tiles[g].activeInHierarchy)
        {
            //float RandomX = Random.Range(-0.5f, 9.5f);
            // float RandomZ= Random.Range(0.0f, 7.7f);
           
                float posX = tiles[g].transform.position.x;
                float posZ = tiles[g].transform.position.z;
                // pm._spawnPos = new Vector3(RandomX, 0.5f, RandomZ);   
                _spawnPos = new Vector3(posX, 0.5f, posZ);
               player.transform.position = _spawnPos;
               pm.health = pm.health - 1;
            }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
        
    }
}
