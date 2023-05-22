//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class fallingray : MonoBehaviour
//{

//    public GameObject cube;
//    GameObject Temp;
//    public float time = 0f;
//    public float Speed;
//    private int r;
//    public float t1;
//    public List<GameObject> randomspawn = new List<GameObject>();
//    RaycastHit hit;
//    // Start is called before the first frame update
//    private void Awake()
//    {
//        randomspawn= new List<GameObject>();
//    }
//    void Start()
//    {
      
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        Physics.Raycast(cube.transform.position,new Vector3(-12.7f, 17.5f, 4.5f), out hit,10f );
//        Debug.DrawRay(cube.transform.position, Vector3.down, Color.blue);
//        if (hit.collider != null)
//        {
//            if (hit.collider.gameObject.CompareTag("FallingPlat"))
//            {
//                GameObject temp = hit.collider.gameObject;
//                randomspawn.Add(temp);
//                Debug.Log("randomspawn=" + randomspawn[r]);
//                Debug.Log("randomspawn=" + randomspawn[r]);
//            }
//        }
//        int noOffalling = randomspawn.Count;
//         Debug.Log("spawncount=" + noOffalling);
//        r = Random.Range(0, noOffalling);
//        time += Time.deltaTime;
//        if (time >= 2)
//        {
            
//            // falling[r].SetActive(false);

//            if (randomspawn.Count <= 0) return;
//            randomspawn[r].GetComponent<Rigidbody>().useGravity = true;
//            randomspawn[r].GetComponent<Rigidbody>().isKinematic = false;
//            time = 0;
//        }

//        t1 += Time.deltaTime;
//        if (t1 >= 1f)
//        {
//            if (randomspawn.Count <= 0) return;
//            randomspawn[r].GetComponent<MeshCollider>().isTrigger = false;
//            //Debug.Log("if-r=" + r);
//            t1 = 0f;

//        }

//        randomspawn[r].GetComponent<Rigidbody>().velocity = Vector3.down * Speed * Time.deltaTime;

//    }
//}

