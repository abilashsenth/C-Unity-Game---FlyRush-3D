using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animateobstacle : MonoBehaviour
{

    public AnimationClip animationClip;
    public Animator anim;

   
    private void OnTriggerEnter(Collider other)
    {
        anim.enabled = true;
    }
}
