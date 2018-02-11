using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Brick : MonoBehaviour {

    public static int breakableCount = 0;
    public Sprite[] hitSprites;
    public AudioClip crack;
    public GameObject smoke;
    public GameObject smokePuff;
    public ParticleSystem ps;
    
  
   

    private int numHits;
    private LevelManager levelManager;
    private bool isBreakable; 


    // Use this for initialization
    void Start () {
        
        isBreakable = (this.tag == "Breakable");
        // keep track of breakable bricks
        if(isBreakable) {
            breakableCount++;
            
        }
        numHits = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        
	}
	
	// Update is called once per frame
	void Update () {
        
		
	}
    private void OnTriggerEnter2D(Collider2D trigger) {
        
    }
    private void OnCollisionExit2D(Collision2D collision) {
        AudioSource.PlayClipAtPoint(crack, transform.position, 1.0f);
        if(isBreakable) {
            HandleHits();
        }
        
    }

    void HandleHits() {
        numHits++;
        int maxHits = hitSprites.Length + 1;
        if (numHits >= maxHits) {
            breakableCount--;
            levelManager.BrickDestroyed();
            smokePuff = Instantiate(smoke, transform.position, Quaternion.identity);
            ParticleSystem.MainModule main = smokePuff.GetComponent<ParticleSystem>().main;
            main.startColor = gameObject.GetComponent<SpriteRenderer>().color;
            Destroy(gameObject);
        }
        else {
            LoadSprites();

        }
    }

    void LoadSprites() {
        int spriteIndex = numHits - 1;
        if(hitSprites[spriteIndex] != null) {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }else {
            Debug.LogError("Brick Sprite Missing");
        }
        
    }

    // TODO Remove this method once we can actually win
    void SimulateWin() {
        levelManager.LoadNextLevel();
    }
    private void PuffSmoke()
    {
        GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity);
        smokePuff.SendMessage("SetColor", gameObject.GetComponent<SpriteRenderer>().color);
    }
}

