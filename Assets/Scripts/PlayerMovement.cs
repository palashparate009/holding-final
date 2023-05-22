using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    public Rigidbody player;
    public Animator anim;
    public float speed;
    public float Jumpspeed;
    public float currenttime;
    private bool standValue;
    private Cell c;
    public int health;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    [SerializeField] 
    private float TimerMax = 6f;
   public Vector3 _spawnPos;
    GameObject FloorCell;
    private MainMenu mm;
   public bool stopperflag;
    float poweruptimer = 0f;
    bool isJumping;
    public CollectableScript cs;
   // public DoTweenAnimation dt;
    //public GameObject tmp;
    int Run_HashId = Animator.StringToHash("Run");
    int Jump_HashId = Animator.StringToHash("Jump");
    int Tile_HashId = Animator.StringToHash("Tile");




    void Start()
    {
      stopperflag=false;
        is_standing_anim= false;
        //dt = dt.GetComponent<DoTweenAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        
        healthsystem();
        // Invoke("healthsystem", 5f);
        if ((Input.GetKey(KeyCode.W)) && (Input.GetKey(KeyCode.A)))
        {
            Move(Vector3.forward);
            Move(Vector3.left);
            anim.SetInteger("Run", 3);
        }
        else if ((Input.GetKey(KeyCode.S)) && (Input.GetKey(KeyCode.A)))
        {
            Move(Vector3.back);
            Move(Vector3.left);
            anim.SetInteger("Run", 3);
        }
        else if ((Input.GetKey(KeyCode.D)) && (Input.GetKey(KeyCode.A)))
        {
            Move(Vector3.right);
            anim.SetInteger("Run", 1);
        }
        else if ((Input.GetKey(KeyCode.W)) && (Input.GetKey(KeyCode.D)))
        {
            Move(Vector3.forward);
            Move(Vector3.right);
            anim.SetInteger("Run", 1);
        }
        else if ((Input.GetKey(KeyCode.S)) && (Input.GetKey(KeyCode.D)))
        {
            Move(Vector3.back);
            Move(Vector3.right);
            anim.SetInteger("Run", 1);
        }
        else if ((Input.GetKey(KeyCode.A)) && (Input.GetKey(KeyCode.D)))
        {
            Move(Vector3.left);
            anim.SetInteger("Run", 3);
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJumping)
            {
                isJumping = true;
                player.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, Jumpspeed * Time.deltaTime, 0f), ForceMode.Impulse);
                // player.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, Jumpspeed * Time.deltaTime, 0);
                anim.SetBool(Jump_HashId, true);
                anim.SetInteger("Run", 2);
            }
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJumping)
            {
                isJumping = true;
                player.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, Jumpspeed * Time.deltaTime, 0f), ForceMode.Impulse);
                // player.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, Jumpspeed * Time.deltaTime, 0);
                anim.SetBool(Jump_HashId, true);
                anim.SetInteger("Run", 3);
            }
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJumping)
            {
                isJumping = true;
                player.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, Jumpspeed * Time.deltaTime, 0f), ForceMode.Impulse);
                // player.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, Jumpspeed * Time.deltaTime, 0);
                anim.SetBool(Jump_HashId, true);
                anim.SetInteger("Run", 1);
            }
        }

        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Space))
        {
            Move(Vector3.back);
            Move(Vector3.up);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Move(Vector3.right);
            //anim.Play("Run01Right");
            anim.SetInteger("Run", 1);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            Move(Vector3.forward);
            anim.SetInteger("Run", 2);
        }
        else if (Input.GetKey(KeyCode.A))
        {

            Move(Vector3.left);
            anim.SetInteger("Run", 3);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Move(Vector3.back);
            anim.SetInteger("Run", 4);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if(!isJumping)
            {
                isJumping= true;
               player.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3 (0f,Jumpspeed*Time.deltaTime,0f),ForceMode.Impulse);
               // player.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, Jumpspeed * Time.deltaTime, 0);
                anim.SetBool(Jump_HashId, true);
            }
           
            //Debug.Log("JUMP BOOL SETTING HERE");
            //anim.SetBool("Jump1", false);

        }       
        else
        {
            anim.SetInteger("Run", 0);
            anim.SetBool("Jump", false);
        }


        //if (Input.GetKey(KeyCode.C))
        //{
        //    stopperflag = true;
        //    Debug.Log("c");

        //    //if (poweruptimer > 0.0f && poweruptimer <= 5f)
        //    //    stopperflag = true;
        //    // poweruptimer = 0f;
        //    if (stopperflag)
        //    {
        //       // Debug.Log("true");

        //        poweruptimer += Time.deltaTime;
        //        Debug.Log("timer" + poweruptimer);
        //        if(poweruptimer>=5f)
        //        {
        //            stopperflag= false;
        //        }

        //    }
        if (Input.GetKey(KeyCode.C) /*&& stopperflag==true*/)
        {
            stopperflag= true;
            poweruptimer += Time.deltaTime;
            Debug.Log("c");

            //if (poweruptimer > 0.0f && poweruptimer <= 5f)
            //    stopperflag = true;
            // poweruptimer = 0f;
            
                // Debug.Log("true");

               
                Debug.Log("timer" + poweruptimer);
                if (poweruptimer >= 5f)
                {
                    stopperflag = false;
                    poweruptimer = 0;
                
                }
            //poweruptimer = 0f;


        }
        




        if ( stopperflag == false)
        {
            Translatefloorcell();
            currenttime += Time.deltaTime;
        }

        //Invoke("Translatedown", 5f);

        //if (currenttime >= 7f)
        //{

        //    ////  Debug.Log("temp="+temp);
        //    //if (FloorCell != null)
        //    //{
        //    //    FloorCell.gameObject.SetActive(false);
        //    //    health = health - 1;
        //    //    // FloorCell.gameObject.GetComponent<MeshCollider>().material ;
        //    //}
        //    currenttime = 0;
        // }

        //if (FloorCell!=null)
       


    }
    void Translatefloorcell()
    {
      



           // if (currenttime >= 4.0f && currenttime <= 4.2f)
            if (currenttime >= 0.2f && currenttime <= 0.5f)
            {
                if (FloorCell != null)
                {
                    // Debug.Log("translate");

                   // FloorCell.transform.Translate(new Vector3(0f, -0.8f * Time.deltaTime, 0f));
                    FloorCell.GetComponent<Cell>().DestroyObj();
                    //currenttime += Time.deltaTime;
                }

            
        }
    }
    public void healthsystem()
    {

        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
           
              
            
           
        }
        if(health<=0)
        {
            SceneManager.LoadScene(2);
        }    
    }
    public bool is_standing_anim;

    Cell Temp;
    Cell ExitRef;


  
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
            currenttime = collision.gameObject.GetComponent<Cell>().Time1;
            FloorCell = collision.gameObject;
            //is_standing_anim= true;
            ////GameManager.instance.FloorMgr.GettingPos(FloorCell.transform);
            //if (is_standing_anim)
            //{
            //    anim.Play("pCylinder1|pCylinder1Action");
            //    Debug.Log("nsjsc");
            //}
           
            //standValue = collision.gameObject.GetComponent<Cell>().Standing;
            Temp = collision.gameObject.GetComponent<Cell>();

            if(Temp.Standing == false)
            {
                if (ExitRef != null)
                {
                    ExitRef.Standing = false;
                }

                Temp.Standing = true;
               
                if (currenttime == 0)
                {
                  //  Debug.Log("currenttime=0");
                    TimerMax = 6f;
                }
                else
                {
                  //  Debug.Log("currenttime="+currenttime);
                    TimerMax = currenttime;
                }
            }
            //if(Temp.Standing==true)
            //{
            //    //dt.AnimateTile();
            //}
            

          
       
        }
        //if(!collision.gameObject.CompareTag("Floor"))
        //{
        //    is_standing_anim = false;
        //}
        
    }
    //private void Translatedown()
    //{
        
    //        Debug.Log("bigs");
    //        FloorCell.transform.Translate(new Vector3(0f, -1f, 0f));

    //        //currenttime += Time.deltaTime;
        
    //}

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {

            if(Temp.Standing == true)
            {
                ExitRef = collision.gameObject.GetComponent<Cell>();
                // Temp.Time = currenttime;
                collision.gameObject.GetComponent<Cell>().Time1 = currenttime;
            }
            else
            {

            }
        }

    }
    public float i=0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Health")
        {
            health = health + 1;
            Debug.Log("hghf");
            other.gameObject.SetActive(false);
        }
        
        if (other.gameObject.tag=="DestroyStopper")
        {
            Debug.Log("triggered");
            other.gameObject.SetActive(false);
            //stopperflag = true;
            poweruptimer = 0.0f;
        }
        
    } 


       
          
    public void Move(Vector3 dir)
    {
        player.transform.Translate(dir * speed * Time.deltaTime);
    }

}
