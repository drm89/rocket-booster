using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {
    [SerializeField]
    private float rcsTrust = 100f;
    [SerializeField]
    private float mainTrust = 100f;
    private Rigidbody rigidbody;
    private AudioSource audioSource;
	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        ProcessInput();
	}

    private void ProcessInput()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddRelativeForce(Vector3.up* mainTrust);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }

        float m = rcsTrust * Time.deltaTime;
        rigidbody.freezeRotation = true;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * m);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * m);
        }

        rigidbody.freezeRotation = false;

    }

    void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Friendly":
                print("on friend");
                break;
        }
    }
}
