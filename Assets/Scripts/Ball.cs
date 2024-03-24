using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private GameManager gameManager;
    private Vector3 moveDirection;
    private PlayerController playerController;
    [SerializeField] private float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        moveDirection = Vector3.down;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            transform.Translate(moveDirection.normalized * speed * Time.deltaTime);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            moveDirection = Vector3.Reflect(moveDirection, Vector3.up) + playerController.moveDirection;
        }
        if (other.tag.Equals("SideWall"))
        {
            moveDirection = Vector3.Reflect(moveDirection, Vector3.right);
        }
        if (other.tag.Equals("TopWall"))
        {
            moveDirection = Vector3.Reflect(moveDirection, Vector3.up);
        }
        if (other.tag.Equals("Sensor"))
        {
            gameManager.GameOver();
            Destroy(gameObject);
        }
    }
}
