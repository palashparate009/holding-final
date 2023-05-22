using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    private float RandomX;
    private float RandomZ;
    public float time;
    GameObject Temp;
    public GameObject prefab;
    public float speed;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time>=5)
        {
            RandomX = Random.Range(player.transform.position.x - 3f, player.transform.position.x + 3f);
            RandomZ = Random.Range(player.transform.position.z - 3f, player.transform.position.z + 3f);
            var g = Instantiate(prefab, new Vector3(RandomX, 10f, RandomZ), Quaternion.identity);
            Temp = g;
            Temp.transform.gameObject.GetComponent<Rigidbody>().velocity = Vector3.down * speed ;
            time = 0;      
        }
    }
}
