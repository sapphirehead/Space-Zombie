using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidControls : MonoBehaviour
{
    //[SerializeField]
    //public GameObject playerExplosionPrefab;
    [SerializeField]
    public GameObject enemyExplosionPrefab;
    [SerializeField]
    public AudioClip touchSound;

    private readonly int speed = 1;

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < -13.0f) //y=3.53f up -3.81f down
        {
            transform.position = new Vector3(10.0f, Random.Range(-3.5f, 3.5f), 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerControls playerControls = collision.GetComponent<PlayerControls>();
            if (playerControls != null)
            {
                playerControls.LifeSubstraction();
            }
            if (PlayerControls.playerLives != 0)
                AudioSource.PlayClipAtPoint(touchSound, Camera.main.transform.position, 1.0f);
            //Destroy(this.gameObject);//here haven't need explosion because here isn't quare lossing of player's lives
        }
    }
}
