
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    private Vector3 _offset = new Vector3 (0f,0f,-10f);
    private float _smoothTime = 0.25f;
    private Vector3 _velocity = Vector3.zero;
    void Update()
    {
        Vector3 targetPos = target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref _velocity, _smoothTime);
    }
}
