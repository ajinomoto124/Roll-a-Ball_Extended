using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    [HideInInspector] public Rigidbody target;
    //public Text winText;

    private Vector3 velocity = Vector3.zero;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, .5f);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            //gameOver();
        }
    }

    

    //void gameOver()
    //{

    //    winText.text = "You Lose!";

    //}
}
