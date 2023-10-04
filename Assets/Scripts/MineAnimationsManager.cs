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
    [SerializeField] AudioSource Beep;
    [SerializeField] AudioSource Explosion;
 

    public void ExitWarningRange()
    {
        Beep.enabled = false;
        anim.SetBool("IsWarning", false);
    }

    public void TriggerWarning()
    {
        Beep.enabled = true;
        anim.SetBool("IsWarning", true);
    }

    public void TriggerExplosion(Blob player)
    {
        int i = 0;
        while (i < 10)
        {
            Beep.pitch += 0.5f;
            i++;
        }
        anim.SetTrigger("IsBoom");
       
        StartCoroutine(DelayedBoom(player));
    }
    IEnumerator DelayedBoom(Blob player)
    {
        yield return new WaitForSeconds(2.5f);
        player.TrigThis();
        Boom();
    }

    
    public void Boom()
    {
        Explosion.Play();
        ExplosionCollider.enabled = true;
        MineBase.SetActive(false);
        MineLamp.enabled = false;
        boom.Play();
        Destroy(ExplosionSource, 1f);
    }
}
