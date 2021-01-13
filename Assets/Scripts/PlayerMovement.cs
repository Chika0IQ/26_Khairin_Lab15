using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public GameObject jumpText;        // Finding the JumpText
    public AudioClip[] AudioClipArr;   // AudioClip array
    public Rigidbody playerRb;         // Find RigidBody of Player

    private AudioSource audioSource;   // Initaillize AudioSouce

    private int JumpCounter;           // Count how many times player has jumped
    public float jump = 10f;           // How hign player can jump

    private int spacePressed = 0;      // Count how many times spacebar is pressed for Single Jump

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();         // Get Rigidbody component
        audioSource = GetComponent<AudioSource>();    // Get AudioSource Component
    }

    // Update is called once per frame
    void Update()
    {
        PlayerJump();  // Calling PlayerJump Function
    }

    private void PlayerJump()
    {

        // Player will jump 1 at a time after landing on platfrom, add JumpCounter to Jumpcounter Text and produce audio on every Jump
        if (Input.GetKeyDown(KeyCode.Space) && spacePressed < 1)
        {

            playerRb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            JumpCounter++;
            spacePressed++;
            jumpText.GetComponent<Text>().text = "Jump: " + JumpCounter;

            //audioSource.Play();
            int rand = Random.Range(0, AudioClipArr.Length);
            audioSource.PlayOneShot(AudioClipArr[rand]);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if player has landed on gameobject.Tag "Platfrom"
        if(collision.gameObject.CompareTag("Platform"))
        {
            spacePressed = 0;
        }
    }
}
