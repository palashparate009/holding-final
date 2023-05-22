//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using DG.Tweening;
//public class DoTweenAnimation : MonoBehaviour
//{

//    Sequence mysequence = DOTween.Sequence();
//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        //AnimateTile();
//    }
//    public void AnimateTile()
//    {
//        //mysequence.Insert(1, transform.DOMoveY(-0.6f, 2));
//        //mysequence.Insert(2, transform.DORotate(new Vector3(0, 30, 20), 1).SetDelay(2));
//        //mysequence.Insert(3, transform.DORotate(new Vector3(0, 30, -20), 1).SetDelay(4));
        
//        mysequence.Insert(1,transform.DOMoveY(-0.6f, 3).SetDelay(2));
//        mysequence.Insert(3, transform.DOShakeRotation(2f,200f, 0, 0, false, ShakeRandomnessMode.Harmonic).SetDelay(4));
//        //transform.DOShakeRotation(2f, new Vector3(0f, 0f, 90f), 5, 0, false, ShakeRandomnessMode.Harmonic);
//        // transform.DORotate(new Vector3(0, 30, 20), 1).Complete();
//    }
//}
