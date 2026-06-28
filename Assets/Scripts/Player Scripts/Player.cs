using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] Light flashlight;
    private CharacterController controller;

    [SerializeField] AudioSource audiSource;
    [SerializeField] AudioClip footStepSound;

    float timeBetweenSteps = 0.6f;
    float stepTimer;

    List<string> keys = new List<string>();

    public bool isFlashlightOn;
    private float velocityY;

    public int keyCount;

    private void Start()
    {
        controller = GetComponent<CharacterController>();

        flashlight.enabled = isFlashlightOn;
    }

    private void Update()
    {
        PlayerMove();
        IsFlashOn();
        FootStepSound();
       
    }        
        

    void PlayerMove()
    {
        if (controller.isGrounded && velocityY < 0)
        {
            velocityY = -2f;
        }

        velocityY += -gravity * Time.deltaTime;

        Vector3 gravityForce = new Vector3(0, velocityY, 0);


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime + gravityForce * Time.deltaTime);
    }

    void IsFlashOn()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isFlashlightOn = !isFlashlightOn;
            flashlight.enabled = isFlashlightOn;
        }
    }
    public void AddKey(string keyID)
    {
        keys.Add(keyID);
    }

    public bool HasKey(string requiredKeyID)
    {
        return keys.Contains(requiredKeyID);
    }

    void FootStepSound()
    {
        bool isMoving = false;
        
        if (controller != null)
        {
            isMoving = controller.isGrounded && controller.velocity.magnitude > 0.1f;
        }

       if (isMoving)
        {
            stepTimer -= Time.deltaTime;

            if (stepTimer <= 0)
            {
                audiSource.PlayOneShot(footStepSound);
                stepTimer = timeBetweenSteps;
            }
        }
        else
        {
            stepTimer = 0.2f;
        }
    }
}
