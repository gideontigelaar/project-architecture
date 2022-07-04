using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 20f;
        }
        else
        {
            speed = 12f;
        }
    }

	public void SaveLocationData()
	{
		//SaveSystem.SaveLocation(this);
		//PlayerPrefs.SetFloat[3]
	}


	// cs0029 cannot convert playermovement to player location data. Ookal heb ik het zelfde gedaan als de turorial 

	// public void LoadLocationData()
	// {
	// 	PlayerLocationData data = SaveSystem.LoadLocation();

	// 	Vector3 position;
	// 	position.x = data.position[0];
	// 	position.y = data.position[1];
	// 	position.z = data.position[2];
	// }
}
