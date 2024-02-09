using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    [Header("Health")] 
    public int lives = 3;
    public int maxLives = 3;

    [Header("IFrames")] 
    public bool canTakeDamage;
    public float canTakeDamageTime = 0.1f;
    public float canTakeDamageCounter;

    private AudioSource _audioSource;
    public AudioClip[] hurtClips;
    public AudioClip[] pickupClips;
    //private SceneController _sceneController;

    private GameObject[] Hearts;
    
    [SerializeField] private AudioSource hurtSoundEffect;
    
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        //_sceneController = GetComponent<SceneController>();
    }

    private void Update()
    {
        if (Time.time > canTakeDamageCounter && !canTakeDamage)
        {
            canTakeDamage = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Heart"))
        {
            if (lives >= maxLives) return;
            lives++;
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("DamageZone"))
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    //Gå gjennom array med forloop uten gameobject.find! (Setactive to false or destroy?)
    {
        if (!canTakeDamage) return;
        lives -= 1;
        hurtSoundEffect.Play();
        //or (int i = 0; i < hearts.Length; i++)
        {
            //hearts[i].color = i < _target.lives ? new Color(1,1,1,1) : new Color(1, 1, 1, 0.1f);
        }

        
        if (lives <= 0)
        {
            //_sceneController.Reset();
        }

        canTakeDamage = false;
        canTakeDamageCounter = Time.time + canTakeDamageTime;
    }
}
