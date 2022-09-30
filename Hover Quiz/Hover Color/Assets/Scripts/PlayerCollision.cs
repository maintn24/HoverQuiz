using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public UnityEngine.GameObject explosionEffect;

    public ObstacleMovement obsMovement;
    public Score score;

    public UnityEngine.GameObject quizUI;


    private void OnTriggerEnter2D(Collider2D other)
    {
        score.isEnded = true;
        this.gameObject.SetActive(false);
        quizUI.SetActive(false);
        obsMovement.enabled = false;
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        FindObjectOfType<GameoverMenu>().EndGame();
    }


    
}
