using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using UnityEditor;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
using UnityEngine.UI;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private int powerupID;
    [SerializeField]
    private AudioClip _clip;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed *Time.deltaTime);
        if (transform.position.y < -4.5f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            AudioSource.PlayClipAtPoint(_clip, transform.position);


            if(player != null)
            {
                if(powerupID == 0)
                {
                    player.TripleShotActive();
                }
                else if (powerupID ==1)
                {
                    player.SpeedBoostActive();
                }
                else if(powerupID ==2)
                {
                    player.ShieldsActive();
                }
            }

            Destroy(this.gameObject);
        }
    }
}
