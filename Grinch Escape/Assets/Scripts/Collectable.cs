using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour {

    public static int collectableQuantity = 0;
    Text collectableText;

    AudioSource collectableAudio;

    // Use this for initialization
    void Start () {
        //collectableQuantity = 0;
        collectableAudio = GetComponentInParent<AudioSource>();
        collectableText = GameObject.Find("CollectableQuantityText").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collectableAudio.Play();
            Destroy(gameObject);
            //gameObject.SetActive(false);
            collectableQuantity++;
            collectableText.text = collectableQuantity.ToString();
        }
    }
}
