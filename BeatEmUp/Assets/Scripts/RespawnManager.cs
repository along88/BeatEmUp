using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{

    private Transform spawnPoint;
    private Transform player;
    private SpriteRenderer sprite;
    [SerializeField]
    private float respawnTime;
    private Transform playerCamera;
    private Vector2 playerPos;
    public bool isDead = false;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sprite = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        playerPos = new Vector2(transform.position.x, transform.position.y);
        spawnPoint = GameObject.FindGameObjectWithTag("Spawn").transform;

    }
    private void LateUpdate()
    {
        if (isDead)
        {
            Respawn();
            //isDead = false;
           
        }
    }

    
    private void Respawn()
    {
     
           
       // playerPos = new Vector2(transform.position.x,transform.position.y);
        sprite.enabled = false;
        
        Vector3.Lerp(transform.position, spawnPoint.position, Time.deltaTime);
        isDead = true;
        if (!isDead)
        {
            sprite.enabled = true;
        }


    }

}
