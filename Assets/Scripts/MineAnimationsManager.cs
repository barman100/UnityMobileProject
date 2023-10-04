using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineAnimationsManager : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private ParticleSystem _boom;
    [SerializeField] private CircleCollider2D _explosionCollider;
    [SerializeField] private GameObject _mineBase;
    [SerializeField] private SpriteRenderer _mineLamp;
    [SerializeField] private GameObject _explosionSource;
    [SerializeField] private AudioSource _beep;
    [SerializeField] private AudioSource _explosion;
 

    public void ExitWarningRange()
    {
        _beep.enabled = false;
        _anim.SetBool("IsWarning", false);
    }

    public void TriggerWarning()
    {
        _beep.enabled = true;
        _anim.SetBool("IsWarning", true);
    }

    public void TriggerExplosion(Blob player)
    {
        int i = 0;
        while (i < 10)
        {
            _beep.pitch += 0.5f;
            i++;
        }
        _anim.SetTrigger("IsBoom");
       
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
        _explosion.Play();
        _explosionCollider.enabled = true;
        _mineBase.SetActive(false);
        _mineLamp.enabled = false;
        _boom.Play();
        Destroy(_explosionSource, 1f);
    }
}
