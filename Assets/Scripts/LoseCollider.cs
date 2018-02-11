using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoseCollider : MonoBehaviour {
    private LevelManager levelManager;

    private void OnTriggerEnter2D(Collider2D trigger) {
        levelManager = FindObjectOfType<LevelManager>();
        print("Trigger");
        levelManager.loadLevel("Lose");
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        print("Collider");
    }
}
