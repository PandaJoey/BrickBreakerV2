﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;
    public float minX, maxX;

    private Ball ball;

    private void Start() {
       ball = GameObject.FindObjectOfType<Ball>();
       
    }
    // Update is called once per frame
    void Update () {
        if(!autoPlay) {
            MoveWithMouse();
        }else {
            AutoPlay();
        }
	}

    void AutoPlay() {
        Vector3 paddlePos = new Vector3(this.transform.position.x, this.transform.position.y, -5f);
        Vector3 ballPos = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPos.x, minX, maxX);
        this.transform.position = paddlePos;
    }

    void MoveWithMouse() {
        Vector3 paddlePos = new Vector3(this.transform.position.x, this.transform.position.y, -5f);
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, minX, maxX);
        this.transform.position = paddlePos;
    }
}
