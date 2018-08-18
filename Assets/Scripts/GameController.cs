using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private const float MOVEMENT_MULTIPLIER = 10.0f;
    private const int NUM_COINS = 10;

    private Rigidbody ball;
    private List<GameObject> coins;

    public GameObject Coin;

	// Use this for initialization
	void Start () {
        ball = GetComponent<Rigidbody>();
        coins = new List<GameObject>();

        System.Random rand = new System.Random();
        for (int i = 0; i < NUM_COINS; i++)
        {
            int isNegX = rand.Next(0, 2);
            int isNegY = rand.Next(0, 2);

            int x = rand.Next(3, 10);
            int y = rand.Next(3, 10);

            if (isNegX > 0)
            {
                x = -x;
            }

            if (isNegY > 0)
            {
                y = -y;
            }

            coins.Add((GameObject)Instantiate(Coin, new Vector3(x, 0, y), Quaternion.identity));
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveX, 0, moveY) * MOVEMENT_MULTIPLIER;
        ball.AddForce(movement, ForceMode.Force);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
    }
}
