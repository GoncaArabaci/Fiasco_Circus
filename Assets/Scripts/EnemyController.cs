using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    public string playerTag = "Player";
    public float moveSpeed = 5f;
    public int damagePerHit = 1;
    public int hitsToKillPlayer = 5;

    private Transform player;
    private int hitsTakenByPlayer = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag)?.transform;

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
            TakeDamage();
            
        }
        

    }

    void TakeDamage()
    {
        hitsTakenByPlayer++;

        

        Debug.Log("Player and Enemy touched! Player Hits: " + hitsTakenByPlayer);
        
        if (hitsTakenByPlayer >= hitsToKillPlayer)
        {
            KillPlayer();
        }
    }

    void KillPlayer()
    {
        Debug.Log("Player is dead!");
        // Add any additional logic for player death, such as playing death animation, resetting the level, etc.
        // For simplicity, let's deactivate the player object in this example.
        player.gameObject.SetActive(false);
    }

    

   

   



}
