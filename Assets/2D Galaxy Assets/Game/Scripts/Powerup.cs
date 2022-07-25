using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private float _speed = 3.0f;

    // Update is called once per frame
    void Update()
    {
       transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                if (gameObject.tag == "SpeedPU")
                    player.SpeedTurnOn();
                else if (gameObject.tag == "TripleShotPU")
                    player.TripleShotTurnOn();
            }
            Destroy(this.gameObject);
        }
    }
}
