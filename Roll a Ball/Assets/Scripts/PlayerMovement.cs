using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed;
    //public Text countText;
    //public Text winText;

    private float startingHeight = 0.0f;
    private bool jumping = false;
    private float jumpHeight = 180f;

    private Rigidbody rigidBody;
    private int pickups;

    void Start()
    {
        pickups = 0;
        rigidBody = GetComponent<Rigidbody>();
        //updateCountText();
        //winText.text = "";
        startingHeight = transform.position.y;
    }

    /*
     * Uses FixedUpdate because we are affecting a physics body (rigidbody)
     */
    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal") * moveSpeed;
        float moveVertical = Input.GetAxis("Vertical") * moveSpeed;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rigidBody.AddForce(movement);

        //first attempt at jumping only once
        //if (Input.GetButtonDown("Jump") && (transform.position.y == startingHeight))
        //{
        //    Debug.Log("height " + transform.position.y);
        //    rigidBody.AddForce(Vector3.up * jumpHeight);
        //}

        //second attempt at jumping only once.  first check must come before the second
        //or else it will immediately return jumping to false and allow infinite jumps
        if (jumping && startingHeight == transform.position.y)
        {
            jumping = false;
        }
        if (Input.GetButtonDown("Jump") && !jumping)
        {
            startingHeight = transform.position.y;
            jumping = true;
            rigidBody.AddForce(Vector3.up * jumpHeight);
        }
        

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup")){
            other.gameObject.SetActive(false);
            pickups++;
            //updateCountText();
        }
    }

    //Instead save the value of pickups to compare to how many there were at the start
    //and use the game manager to tell if all the pickups have been gotten
    //void updateCountText()
    //{
    //    countText.text = "Count: " + pickups.ToString();
    //    if(pickups >= 8)
    //    {
    //        winText.text = "You Win!";
    //    }
    //}
}
