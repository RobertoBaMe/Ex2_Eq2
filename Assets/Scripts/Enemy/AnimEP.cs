using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEP : MonoBehaviour
{
    private Animator anim;
    private AudioSource ads;
    void Start()
    {
        ads = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    public void isAtack()
    {
        anim.SetBool("Attack", true);
        //ads.Play();
    }
    public void notAtack()
    {
        anim.SetBool("Attack", false);
        //ads.Pause();
    }
}
