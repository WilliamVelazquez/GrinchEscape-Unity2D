using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {
    Text scoreText;
    public int finalScore = (Convert.ToInt32(Collectable.collectableQuantity) * 10) + Convert.ToInt32(PlayerMovement.scorePoints);

    // Use this for initialization
    void Start () {
        scoreText = GameObject.Find("FinalScoreQuantity").GetComponent<Text>();
        scoreText.text = finalScore.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
