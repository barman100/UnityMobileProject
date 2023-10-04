using UnityEngine;


public class TurretDetect : MonoBehaviour
{
    [SerializeField] private GameObject _rocketReserved;
    [SerializeField] private Transform _player;
    [SerializeField] private float _fireDelay = 3;
    [SerializeField] private float _reloadDelay = 3;

    private RocketHit _rocketFire;
    private GameObject _rocket;
    private float _reloadTimer = 0;
    private float _fireTimer = 0;
    private Quaternion _initialRotation;
    private bool _isFired = false;
    public bool _isLockedOn = false;
    public bool _isGunLoaded = true;
    private bool isActive = true;

    private void OnApplicationFocus(bool focus)
    {
        isActive = focus;
    }
    public void TriggerAlarm()
    {
        _isLockedOn = !_isLockedOn;
    }

    private void Start()
    {
        _rocket = Instantiate(_rocketReserved, transform.position, transform.rotation, transform);
        _rocketFire = _rocket.GetComponent<RocketRefrence>().refrence;
        _isFired = false;
        _rocket.transform.localPosition = new Vector3(3, 0, 1);

        _initialRotation = transform.rotation;

    }


    void Update()
    {
        if (isActive)
        {
            if (_isLockedOn)
            {
                Quaternion rotation = Quaternion.LookRotation
                  (_player.position - transform.position, transform.TransformDirection(Vector3.up));



                transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
                if (_isFired == false)
                {
                    if (_fireTimer > _fireDelay)
                    {
                        Debug.Log("Fired");
                        _rocket.transform.parent = null;
                        _reloadTimer = 0;
                        _isFired = true;
                        _rocketFire.IgniteThrusters();
                        _rocket = Instantiate(_rocketReserved, new Vector3(0, 0, 1), transform.rotation, transform);
                        _rocketFire = _rocket.transform.GetChild(1).GetComponent<RocketHit>();
                        _rocket.transform.localPosition = new Vector3(0, 0, 1);
                    }
                    else
                    {
                        _fireTimer += Time.deltaTime;
                        Debug.Log("Aiming");
                    }
                }
            }
            else
            {
                _fireTimer = 0;
            }
            if (_isFired && _reloadTimer > _reloadDelay)
            {
                Debug.Log("Reloading Finished");
                _fireTimer = 0;
                _isFired = false;

                _rocket.transform.localPosition = new Vector3(3, 0, 1);
            }
            else if (_isFired)
            {
                Debug.Log("Reloading");
                _reloadTimer += Time.deltaTime;
            }

            _rocket.transform.localPosition = new Vector3(3, 0, 1);
        }
        else if (_isFired)
        {
            Debug.Log("Reloading");
            _reloadTimer += Time.deltaTime;
        }


    }
    
}



   
       
            
    