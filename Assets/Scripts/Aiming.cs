using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Aiming : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] Rigidbody2D RB;
    [SerializeField] float Strength = 5;
    [SerializeField] float MaxLength = 5;
    [SerializeField] GameObject Arrow;
    [SerializeField] SpriteRenderer ArrowSprite;
    [SerializeField] GameObject Target;
    [SerializeField] Blob player;

    [SerializeField] AudioClip JumpSound;
    [SerializeField] AudioSource PlayerSound;

    public static GameObject DraggedInstance;

    Vector3 _startPosition;
    Vector3 _offsetToMouse;
    float _zDistanceToCamera;
    float size;
    float powerRatio;

    [SerializeField] Vector3 Green = new Vector3((88/256), (217 / 256), (66 / 256));
    [SerializeField] Vector3 Red = new Vector3((203 / 256), (33 / 256), (20 / 256));
    Vector3 newColor;

    #region Interface Implementations

    public void OnPointerDown(PointerEventData eventData)
    {
        
        Debug.Log("OnPointerDown");
        Target.SetActive(true);
        Debug.Log(ArrowSprite.color);
        Target.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(eventData.position).x, Camera.main.ScreenToWorldPoint(eventData.position).y,1);
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Arrow.SetActive(true);
        Arrow.transform.up = (Target.transform.position - Arrow.transform.position).normalized;
        size = (Target.transform.position - Arrow.transform.position).magnitude;
        Arrow.transform.localScale = new Vector3(1,size,1);
        Debug.Log("OnBeginDrag");
        DraggedInstance = Target;
        _startPosition = transform.position;
        _zDistanceToCamera = Mathf.Abs(_startPosition.z - Camera.main.transform.position.z);

        _offsetToMouse = _startPosition - Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, _zDistanceToCamera - 1)
        );
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        if (Input.touchCount > 1)
            return;
        
        Target.transform.position = Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, _zDistanceToCamera)
            ) + _offsetToMouse;
        Arrow.transform.up = (Target.transform.position - Arrow.transform.position).normalized;
        size = (Target.transform.position - Arrow.transform.position).magnitude;
        if (size>MaxLength) size = MaxLength;
        powerRatio = size / MaxLength;
        newColor = (powerRatio) * Red + (1 - powerRatio) * Green;
        ArrowSprite.color = new UnityEngine.Color(newColor.x,newColor.y,newColor.z);
        Arrow.transform.localScale = new Vector3(1, size, 1);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        Debug.Log("OnEndDrag");
        LevelStatsTracker.Jumps++;
        DraggedInstance = null;
        Target.SetActive(false);
        Arrow.SetActive(false);
        player.TrigThis();

        PlayerSound.clip = JumpSound;
        PlayerSound.Play();
        RB.AddForce(new Vector2(Target.transform.position.x - RB.transform.position.x, Target.transform.position.y - RB.transform.position.y).normalized * Strength * powerRatio, ForceMode2D.Impulse);
        player.TrigThis();
        _offsetToMouse = Vector3.zero;

    }

    #endregion


}
