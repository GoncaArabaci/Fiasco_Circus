using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletpops;
    private float timer;
    private GameObject player;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");


    }

    void Update()
    {

        timer += Time.deltaTime;
        float distance = Vector2.Distance(transform.position, player.transform.position);
        //Debug.Log(distance);
        if (distance < 10)
        {

            timer += Time.deltaTime;

            if (timer > 3)
            {
                timer = 0;
                shoot();
            }
        }

        if (timer > 4)
        {
            timer = 0;
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(bullet, bulletpops.position, Quaternion.identity);
    }



}
