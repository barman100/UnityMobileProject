using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aiming : MonoBehaviour
{
    [SerializeField] Rigidbody2D RB;
    [SerializeField] float Strength = 5;

    private bool _isDragActive = false;

    private Vector2 _screenPosition;

    private Vector3 _worldPosition;

    private Draggable _LastDragged;

    // Update is called once per frame
    void Update()
    {
        if (_isDragActive && Input.GetMouseButtonUp(0) || Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)
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
        }
    }
    void Drag()
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
    }
}
