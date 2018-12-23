using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    AudioSource obstacleAudio;

    // Use this for initialization
    void Start () {
        obstacleAudio = GetComponentInParent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            obstacleAudio.Play();
            GameObject.Find("World").GetComponent<AudioSource>().Stop();
            GameObject.Find("Player").GetComponent<PlayerMovement>().speed=0;
            EndGame();
            //Invoke("EndGame", 1);
            //StartCoroutine(EndGame());
            //gameObject.SetActive(false);
        }
        else if(collision.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

    void EndGame()
    {
        //yield return new WaitForSeconds(2);
        GameObject.Find("SceneChanger").GetComponent<SceneChanger>().ChangeSceneTo("LoseScene");
    }
}
