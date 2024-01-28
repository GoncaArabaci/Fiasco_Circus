using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirControl : MonoBehaviour
{
    public float moveSpeed = 5f; // Hareket hýzý
    public float maxHoldTime = 3f; // Maksimum basýlý tutma süresi
    public float stopDuration = 1f; // Durma süresi

    Animator playerAnimator;

    private float holdTime = 0f; // Basýlý tutma süresi ölçümü
    private bool isHolding = false; // Tuþ basýlý mý kontrolü

    private Rigidbody2D rb;

    
    public enum PlayerState
    {
        Moving,
        Stop,
    }

    public PlayerState currentPlayerState;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        // Tuþa basýlý tutma süresini ölç
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            holdTime += Time.deltaTime;

            // Basýlý tutma süresi kontrolü
            if (holdTime > maxHoldTime && !isHolding)
            {
                isHolding = true;
                Debug.Log("3tiems");
                StartCoroutine(StopPlayer());
            }
        }
        else
        {
            // Tuþ býrakýldýðýnda süreyi sýfýrla
            holdTime = 0f;
            isHolding = false;
        }

        if (currentPlayerState != PlayerState.Stop)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        }
    }

    


    // Oyuncuyu belirli bir süre durdurma fonksiyonu
    IEnumerator StopPlayer()
    {
        currentPlayerState = PlayerState.Stop;
        rb.velocity = Vector2.zero;
        playerAnimator.SetBool("Fall", true);
        yield return new WaitForSeconds(stopDuration);
        Debug.Log("5tiems");
        currentPlayerState = PlayerState.Moving;
        playerAnimator.SetBool("Fall", false);
        holdTime = 0f;
        isHolding = false;
    }
}
