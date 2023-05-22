using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


//Top Floor Managing is done in this Script ... to maintain or to create the falling huge tiles on player
public class FloorManager : MonoBehaviour
{
    public List<GameObject> falling;

    int i = 0, j = 0, ColumnCount = 0;
    //float Tx = -0.5f, Ty = 16.9f, Tz = 0f;//0.13f;
    float Tx = 1.2f, Ty = 16.9f, Tz = 2.4f;
    public GameObject Prefab;
    GameObject Temp;
    public float time = 0f;
    public float Speed;
    private int r;
    public float t1;
    public  float RandomX;
    public float RandomZ;

    //public Transform PosFromPlayer;

    private void Awake()
    {
        falling = new List<GameObject>();
    }
    void Start()
    {
        
        for (int i = 0; i < 100; i++)
        {
            RandomX = Random.Range(-0.5f,9.5f);
            RandomZ = Random.Range(0f, 7.7f);
            var g = Instantiate(Prefab, new Vector3(RandomX, 10, RandomZ), Quaternion.identity);
            g.SetActive(false);
            falling.Add(g);

        }
       // Init();

    }


    //public void GettingPos(Transform TilePosValue)
    //{
    //    PosFromPlayer = TilePosValue;
    //}

    //public void ActivateFall()
    //{
    //    Vector3 n = PosFromPlayer.position;
    //    n.y += 10f;
    //    PosFromPlayer.position = n;
    //    falling[0].transform.position = PosFromPlayer.position;
    //    falling[0].SetActive(true);

    //}


    public void Init()
    {
        //  falling[r].GetComponent<Rigidbody>();
        // falling[r].AddComponent<Rigidbody>();
        for (i = 0; i < 10; i++)
        {

            if (i % 2 == 0)
            {
                Tx = -0.5f;
                ColumnCount = 11;

            }
            else
            {
                Tx = 0f;
                ColumnCount = 10;

            }


            for (j = 0; j < ColumnCount; j++)
            {
                GameObject g = Instantiate(Prefab, new Vector3((float)Tx, Ty, Tz), Quaternion.identity);
                Temp = g;
                Temp.gameObject.name = j.ToString() + " FallObj";
                Tx += 1;
                falling.Add(Temp);
            }

            Tz += 0.86f;
        }



    }

    private void Update()
    {

        time += Time.deltaTime;
        if (time >= 2)
        {
            int noOffalling = falling.Count;
            r = Random.Range(0, noOffalling);
            falling[r].SetActive(true);

            if (falling.Count <= 0) return;
            falling[r].GetComponent<Rigidbody>().useGravity = true;
            falling[r].GetComponent<Rigidbody>().isKinematic = false;

            //ActivateFall();

            time = 0;
        }

        t1 += Time.deltaTime;
        if (t1 >= 1f)
        {
            falling[r].GetComponent<MeshCollider>().isTrigger = false;
            //Debug.Log("if-r=" + r);
            t1 = 0f;

        }

        falling[r].GetComponent<Rigidbody>().velocity = Vector3.down * Speed * Time.deltaTime;


    }
}

