using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public string playerTag = "Player";
    public float moveSpeed = 5f;

    private Transform player;

    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag(playerTag).transform;

        if (player == null)
        {
            Debug.LogError("Player not found! Make sure the player has the 'Player' tag.");
        }
    }

    void Update()
    {
        if (player != null)
        {
            
            Vector3 direction = player.position - transform.position;
            direction.Normalize();

            
            transform.position = Vector3.Lerp(transform.position, transform.position + direction, moveSpeed * Time.deltaTime);
        }
    }
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        
        if (collision2D.collider.CompareTag(playerTag))
        {
            Debug.Log("Player and Enemy touched!");
        }
    }

}
