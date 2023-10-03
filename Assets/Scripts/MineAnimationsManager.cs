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


    public void ExitWarningRange()
    {
        anim.SetBool("IsWarning", false);
    }

    public void TriggerWarning()
    {

        anim.SetBool("IsWarning", true);
    }

    public void TriggerExplosion(Blob player)
    {

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
        ExplosionCollider.enabled = true;
        MineBase.SetActive(false);
        MineLamp.enabled = false;
        boom.Play();
        Destroy(ExplosionSource, 1f);
    }
}
