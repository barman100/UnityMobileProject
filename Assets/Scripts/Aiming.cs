using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Aiming : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] Rigidbody2D RB;
    [SerializeField] float Strength = 5;
    [SerializeField] float MaxLength = 5;
    [SerializeField] GameObject Arrow;
    [SerializeField] SpriteRenderer ArrowSprite;
    [SerializeField] GameObject Target;

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
        DraggedInstance = null;
        Target.SetActive(false);
        Arrow.SetActive(false);
        RB.AddForce(new Vector2(Target.transform.position.x - RB.transform.position.x, Target.transform.position.y - RB.transform.position.y).normalized * Strength * powerRatio, ForceMode2D.Impulse);
        _offsetToMouse = Vector3.zero;
    }

    #endregion

    /*private bool _isDragActive = false;

    private Vector2 _screenPosition;

    private Vector3 _worldPosition;

    private Draggable _LastDragged;*/






    // Update is called once per frame
    void Update()
    {
        /*if (_isDragActive && Input.GetMouseButtonUp(0) || Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Shoot();
            return;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            _screenPosition = new Vector2(mousePos.x, mousePos.y);  
        }
        else if(Input.touchCount > 0)
        {
            _screenPosition = Input.GetTouch(0).position;
        }
        else
        {
            return;
        }

        _worldPosition = Camera.main.ScreenToWorldPoint(_screenPosition);

        if (_isDragActive)
        {
            Drag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(_worldPosition, Vector2.zero);
            if(hit.collider != null) 
            { 
                Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
                if (draggable != null)
                {
                    _LastDragged = draggable;
                    InitDrag();
                }
            }
        }*/
    }

    


    /*void Drag()
    {
        _LastDragged.transform.position = new Vector2(_worldPosition.x, _worldPosition.y);
    }

    void InitDrag()
    {
        _isDragActive = true;
    }

    void Shoot()
    {
        _isDragActive = false;
        RB.AddForce(new Vector2(_LastDragged.transform.position.x-RB.transform.position.x, _LastDragged.transform.position.y - RB.transform.position.y) *Strength,ForceMode2D.Impulse);
        _LastDragged.transform.position = RB.transform.position;
    }*/
}
