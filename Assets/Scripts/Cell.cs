using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;

public class Cell : MonoBehaviour
{
    //public PlayerMovement pm;

    public bool Standing;
    public float Time1;
    public float animtimer;

    Sequence mysequence = DOTween.Sequence();
    //public string name;
    public bool anim_standing;


    private void Start()
    {
        anim_standing = false;
    }

    public void DestroyObj()
    {
        //animtimer += Time.deltaTime;
        //if (animtimer <= 1f)
        //{
        //    AnimateTile();
        //}
        //animtimer = 0f;
        StartCoroutine(DelayedDestroy(6.0f));

    }

    IEnumerator DelayedDestroy(float time)
    {
        //  Debug.Log("COROUTINE");
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }

    public void AnimateTile()
    {
        //mysequence.Insert(1, transform.DOMoveY(-0.6f, 2));
        //mysequence.Insert(2, transform.DORotate(new Vector3(0, 30, 20), 1).SetDelay(2));
        //mysequence.Insert(3, transform.DORotate(new Vector3(0, 30, -20), 1).SetDelay(4));
        Debug.Log("ANIMATE TILE");
        mysequence.Insert(1, transform.DOMoveY(-0.6f, 3).SetDelay(2));
        //transform.DOShakeRotation(2f, new Vector3(0f, 0f, 90f), 5, 0, false, ShakeRandomnessMode.Harmonic);
        // transform.DORotate(new Vector3(0, 30, 20), 1).Complete();
    }
    public void shake_anim()
    {
        transform.DOShakeRotation(2f, 200f, 0, 0, false, ShakeRandomnessMode.Harmonic).SetDelay(4);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim_standing = true;
            Debug.Log(anim_standing);
            if (anim_standing)
            {
                AnimateTile();
                shake_anim();
            }
            else if (!anim_standing)
            {

                AnimateTile();
                DestroyObj();
            }
        }

    }
}

//private void OnCollisionExit(Collision collision)
//{
//    if (collision.gameObject.CompareTag("Player"))
//    {
//        anim_standing = false;

      
//}
//    }
//}


