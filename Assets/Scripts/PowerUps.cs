using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [SerializeField]
    GameObject healthprefab;
    [SerializeField]
    GameObject DestroyStopperPrefab;
    private float RandomX;
    private float RandomZ;
    public float time;
    public float time1;

    PlayerMovement pm;
    public float speed;

    public float timer;
    [SerializeField] Transform refPos;
    // Start is called before the first frame update
    void Start()
    {
        DestroyStopper();
    }

    // Update is called once per frame
    void Update()
    {
        healthup();
        DestroyStopper();
    }

    GameObject currPowerInstance;
    public void healthup()
    {
        //timer += Time.deltaTime;
        time1 += Time.deltaTime;
        if (time1 >= 100f)
        {
            float RandomX = Random.Range(-0.5f, 9.5f);
            float RandomZ = Random.Range(0.0f, 7.7f);
          
            currPowerInstance = Instantiate(healthprefab, new Vector3(RandomX, 10f, RandomZ), Quaternion.identity);
                    
            time1 = 0;
            
        }

        if(currPowerInstance!=null)
            if (currPowerInstance.transform.position.y <= refPos.position.y)
            {

                currPowerInstance.GetComponent<Rigidbody>().isKinematic = true;
                currPowerInstance.GetComponent<Rigidbody>().useGravity = false;

                // g.GetComponent<Rigidbody>().useGravity = false;

            }
    }
    public void DestroyStopper() 
    {
        time += Time.deltaTime;
        if (time >= 150f)
        {
            float RandomX = Random.Range(-0.5f, 9.5f);
            float RandomZ = Random.Range(0.0f, 7.7f);
            GameObject temp = DestroyStopperPrefab;
            Instantiate(temp, new Vector3(RandomX, 1f, RandomZ), Quaternion.identity);

            temp.transform.gameObject.GetComponent<Rigidbody>().velocity = Vector3.down * speed * Time.deltaTime;
            //if(temp.transform.position.y>1f)
            //{
            //  Rigidbody  rigidtemp;
            //   rigidtemp = GetComponent<Rigidbody>();
            //    rigidtemp.constraints = RigidbodyConstraints.FreezePositionY;


            //}
            time = 0;
        }
    }
  
}
