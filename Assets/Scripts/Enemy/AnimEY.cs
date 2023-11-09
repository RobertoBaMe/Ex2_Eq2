using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEY : MonoBehaviour
{
    private Animator anim;
    private AudioSource ads;
    void Start()
    {
        ads = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    public void isAlert()
    {
        anim.SetBool("Alert", true);
        //ads.Play();
    }
    public void notAlert()
    {
        anim.SetBool("Alert", false);
        //ads.Pause();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isAlert();

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            notAlert();
        }
    }
}
