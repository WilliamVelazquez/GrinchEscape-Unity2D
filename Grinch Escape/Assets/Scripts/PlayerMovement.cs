using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody2D playerRb;
    public float speed = 8;
    public float objectsSpeed = 60;

    public static int time = 0;
    public static int scorePoints = 0;
    Text scoreText;

    public GameObject CollectablePrefab;
    public GameObject ObstaclePrefab;

    private Vector3[] positions = new Vector3[3];
    private GameObject[] prefab = new GameObject[2];

    /*
    public float gridX = 5f;
    public float gridY = 5f;
    
    */
    public float spacing = 2f;

    // Use this for initialization
    void Start() {
        time = 0;
        scorePoints = 0;
        scoreText = GameObject.Find("ScorePointsText").GetComponent<Text>();

        positions[0] = new Vector3(-1.8f, 9f, 0f);
        positions[1] = new Vector3(0f, 9f, 0f);
        positions[2] = new Vector3(1.8f, 9f, 0f);

        prefab[0] = CollectablePrefab;
        prefab[1] = ObstaclePrefab;
    }

    // Update is called once per frame
    void Update() {
        playerRb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, playerRb.velocity.y);
        time++;
        if (time == objectsSpeed)
        {
            time = 0;
            addPoint();
            //Debug.Log("--->" + Random.Range(0, 3));
            if(Random.Range(0, 3)>1)
            {
                addCollectable(positions[Random.Range(0, 3)]);
            }
            else
            {
                addObstacle(positions[Random.Range(0, 3)]);
            }
            
        }
    }

    void addPoint()
    {
        scorePoints++;
        scoreText.text = scorePoints.ToString();
    }

    void addCollectable(Vector3 pos)
    {
        GameObject newCollectable;
        
        newCollectable = Instantiate(CollectablePrefab, pos, Quaternion.identity);
        newCollectable.transform.parent = GameObject.Find("Collectables").transform;
    }

    void addObstacle(Vector3 pos)
    {
        GameObject newCollectable;
        newCollectable = Instantiate(ObstaclePrefab, pos, Quaternion.identity);
        newCollectable.transform.parent = GameObject.Find("Obstacles").transform;
    }

}
