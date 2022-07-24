using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0,0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement ()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float positionX = transform.position.x;
        float positionY = transform.position.y;
        float positionZ = transform.position.z;
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);
        if (positionX > 8) transform.position = new Vector3(8, positionY, positionZ);
        if (positionX < -8) transform.position = new Vector3(-8, positionY, positionZ);
        if (positionY > 4) transform.position = new Vector3(positionX, 4, positionZ);
        if (positionY < -4) transform.position = new Vector3(positionX, -4, positionZ);
    }
}
