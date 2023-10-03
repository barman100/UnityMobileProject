using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineAnimationsManager : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] ParticleSystem boom;
    [SerializeField] CircleCollider2D ExplosionCollider;
    [SerializeField] GameObject MineBase;
    [SerializeField] SpriteRenderer MineLamp;
    [SerializeField] GameObject ExplosionSource;
    private bool isArmed = false;
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player" && isArmed == false )
        {  TriggerWarning(); Debug.Log("First Collide"); }
        else if (isArmed = true && collision.gameObject.tag == "player")
        { TriggerExplosion(); Debug.Log("Second collide"); }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        { TriggerWarning(); Debug.Log("Exit Collide"); }
    }

    public void TriggerWarning()
    {
        isArmed = !isArmed;
        anim.SetBool("IsWarning", isArmed);
    }

    public void TriggerExplosion()
    {
        if(isArmed){
            anim.SetTrigger("IsBoom");
        }    
    }

    
    public void Boom(){
        ExplosionCollider.enabled = true;
        MineBase.SetActive(false);
        MineLamp.enabled = false;
        boom.Play();
        Destroy(ExplosionSource, 1f);
    }
}
