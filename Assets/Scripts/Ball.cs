﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle;
    private Vector3 paddleToBallVector;
    private bool hasStarted = false;
    private Rigidbody2D rigidBody2d;
    private AudioSource sound;


    // Use this for initialization
    void Start() {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        rigidBody2d = GetComponent<Rigidbody2D>();
        sound = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update() {
        if (!hasStarted) {
            this.transform.position = paddle.transform.position + paddleToBallVector;
            if (Input.GetMouseButtonDown(0)) {
                this.rigidBody2d.velocity = new Vector2(2f, 10f);
                hasStarted = true;
                print("mouse clicked");
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision) {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f,0.2f));
        if (hasStarted) {
            sound.Play();
            rigidBody2d.velocity += tweak;
        }
    }
}
