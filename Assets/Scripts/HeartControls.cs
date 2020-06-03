using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartControls : MonoBehaviour
{
    private readonly int speed = 3;
    [SerializeField]
    public GameObject enemyExplosionPrefab;
    [SerializeField]
    public AudioClip powerSound;
    public AudioClip fireSound;
    public AudioClip accidentSound;
    
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fire"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            GameObject objectFireExplosion = (GameObject)Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(fireSound, Camera.main.transform.position, 1.0f);
            Destroy(objectFireExplosion, 2.5f);
            
        }
        else if (collision.CompareTag("Asteroid"))
        {
            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(accidentSound, Camera.main.transform.position, 1.0f);
        }
        else if (collision.CompareTag("Player"))
        {
            PlayerControls playerControls = collision.GetComponent<PlayerControls>();

            if (playerControls != null)
            {
                PlayerControls.playerLives += 1;
            }
            AudioSource.PlayClipAtPoint(powerSound, Camera.main.transform.position, 1.0f);
            Destroy(this.gameObject);;
        }
    }
}
