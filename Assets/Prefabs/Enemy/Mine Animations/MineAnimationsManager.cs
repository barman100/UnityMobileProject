using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineAnimationsManager : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] ParticleSystem boom;
    private bool isArmed = false;
    
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
        boom.Play();
    }
}
