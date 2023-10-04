using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class CollectGem : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _partical;
    [SerializeField]
    private GameObject _diamondChild;
    [SerializeField] MeshRenderer DiamondMeshRendrer;
    private bool NotDestroyed = false;

    [SerializeField] Color Color1;
    [SerializeField] Color Color2;
    Color newColor;

    public Vector3 EndValueRotation = new Vector3(0,360,0);
    public Vector3 EndValueScales= new Vector3(0.2f, 0.2f, 0.2f);

    public bool SwitchedColor = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!NotDestroyed && collision.gameObject.tag == "player")
        {
            GameManager.Diamonds++;
            _partical.Play();
            _diamondChild.SetActive(false);
            Destroy(this.gameObject, 1f);
        }
    }

    private void Update()
    {
        if (DOTween.PlayingTweens() == null)
        {
            if (SwitchedColor) { newColor = Color1; SwitchedColor = false; }
            else { newColor = Color2; SwitchedColor = true; }

            EndValueRotation = EndValueRotation * -1;
            EndValueScales = EndValueScales * -1;
            transform.DOLocalRotate(EndValueRotation, 5f, RotateMode.Fast);
            transform.DOScale(Vector3.one - EndValueScales , 5f);
            DiamondMeshRendrer.material.DOColor(newColor, 5f); 
        }
    }
}
