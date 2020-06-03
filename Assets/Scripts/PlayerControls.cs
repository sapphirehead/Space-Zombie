using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    public GameObject firePrefab;
    private readonly float fireRate = 0.3f;// public
    private float nextFire;//public
    [SerializeField]
    public static int playerLives = 5;
    [SerializeField]
    public GameObject playerExplosionPrefab;
    [SerializeField]
    private int speed = 6;
    [SerializeField]
    public AudioClip explosionSound;

    //[SerializeField]
    private AudioSource fireShot;
    //private AudioSource explosionSound;
    public float horizontInput;
    public float vertInput;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        fireShot = GetComponent<AudioSource>();
        //explosionSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        SpaceMovement();
        if(Input.GetMouseButton(0))
        {
            if(Time.time > nextFire)
            {
                fireShot.Play();
                Instantiate(firePrefab, transform.position + new Vector3(0.08f, 1.55f, 0), Quaternion.identity);
                nextFire = Time.time + fireRate;
            }            
        }
    }

    public void LifeSubstraction()
    {
        playerLives--;

        if (playerLives < 1)
        {
            GetComponent<PlayerControls>().enabled = false;// отключает управление игроком но не делает невидимым
            Instantiate(playerExplosionPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 1.0f);
            Invoke("Delay", 1.0f);
        }
    }
    
    public void Delay()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void SpaceMovement()
    {
        horizontInput = Input.GetAxis("Horizontal");
        vertInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontInput);
        transform.Translate(Vector3.up * Time.deltaTime * speed * vertInput);

        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.6f)
        {
            transform.position = new Vector3(transform.position.x, -4.6f, 0);
        }
        if (transform.position.x > 9.0f)
        {
            transform.position = new Vector3(-9.0f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.0f)
        {
            transform.position = new Vector3(9.0f, transform.position.y, 0);
        }
    }
}
