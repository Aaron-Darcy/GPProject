using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public ParticleSystem explosionEffect;
    public GameObject gameOverUI;
    public int lives = 3;
    public float respawnTime =3;
 
    public int score = 0;
    public float respawnInvulnerability = 3.0f;

    public void Respawn()
    {
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.SetActive(true);
    }

    public void AsteroidDestroyed(Asteroid asteroid)
    {
        this.explosionEffect.transform.position = asteroid.transform.position;
        this.explosionEffect.Play();

        if (asteroid.size < 0.7f) {
            this.score += 100; // small asteroid
        } else if (asteroid.size < 1.4f) {
            this.score +=  50; // medium asteroid
        } else {
            this.score +=  25; // large asteroid
        } 
    }

    public void PlayerDeath(Player player)
    {
        this.explosionEffect.transform.position = this.player.transform.position;
        this.explosionEffect.Play();

        this.lives--;

        if (this.lives <= 0) {
            GameOver();
        } else {
            Invoke(nameof(Respawn), this.respawnTime);
        }
    }

       public void GameOver()
    {
        this.lives = 3;
        this.score = 0;

        Invoke(nameof(Respawn), this.respawnTime);
    }

}

