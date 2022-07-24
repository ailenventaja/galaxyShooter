using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    private float _positionX;
    private float _positionY;
    private float _positionZ;
    [SerializeField]
    private float _fireRate = 0.25f;
    private float _lastShoot = 0.0f;
    [SerializeField]
    private bool isTripleShot;

    [SerializeField]
    private float _speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0,0, 0);
    }

    // Update is called once per frame
    void Update()
    {  
       Movement();
       if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
       {
           Shoot();
       }
    }

    private void Movement ()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        _positionX = transform.position.x;
        _positionY = transform.position.y;
        _positionZ = transform.position.z;
        transform.Translate(Vector3.right * Time.deltaTime * _speed * horizontalInput);
        transform.Translate(Vector3.up * Time.deltaTime * _speed * verticalInput);
        if (_positionX > 8) transform.position = new Vector3(8, _positionY, _positionZ);
        if (_positionX < -8) transform.position = new Vector3(-8, _positionY, _positionZ);
        if (_positionY > 4) transform.position = new Vector3(_positionX, 4, _positionZ);
        if (_positionY < -4) transform.position = new Vector3(_positionX, -4, _positionZ);
    }

    private void Shoot()
    {
        if (Time.time - _lastShoot > _fireRate)
        {
            if (isTripleShot == true)
            {
                Instantiate(_tripleShotPrefab, transform.position + new Vector3(0.2627442f, -0.1591894f, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
            }
            _lastShoot = Time.time;
        }
    }
    public void TripleShotTurnOn()
    {
        isTripleShot = true;
        StartCoroutine(TripleShotTurnOff());
    }

    IEnumerator TripleShotTurnOff()
    {
        yield return new WaitForSeconds(10.0f);
        isTripleShot = false;
    }
}
