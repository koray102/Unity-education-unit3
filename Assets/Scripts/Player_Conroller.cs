using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Conroller : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool isGameOver = false;
    public ParticleSystem explosionPart;
    public ParticleSystem dirtPart;
    public AudioClip jumpSound;
    public AudioClip collisionSound;
    private AudioSource playerAudio;
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // "!" işareti "not" anlamına gelir
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isGameOver)
        {
            // ForceMode.Impulse = kuvvetin aniden uygulanmasını sağlar
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtPart.Stop();
            playerAudio.PlayOneShot(jumpSound, 0.3f);
        }
    }

    // ilk "Collision" her zaman yazılır, ikinci "collision" bu nesne ile çarpışan diğer nesneyi temsil eder 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtPart.Play();
        }else if(collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            isGameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            dirtPart.Stop();
            explosionPart.Play();
            playerAudio.PlayOneShot(collisionSound, 1.0f);
        }
        
    }
}
