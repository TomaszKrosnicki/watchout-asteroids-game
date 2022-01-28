using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float maxX = 19f;
    [SerializeField] public float maxY = 13f;
    [SerializeField] public float moveSpeed = 100f;
    private float activeXMoveSpeed, activeYMoveSpeed;
    [SerializeField] private float acceleration = 2.5f;
    public AudioSource bgmusic;

    void Start() 
    {
        bgmusic = GetComponent<AudioSource>();
        bgmusic.volume = 0.4f;
    }

    void Update() 
    {
        bgmusic.volume = PlayerPrefs.GetFloat("musicVolume");
        if(PlayerState.isDead || !PlayerState.isPlaying)
            bgmusic.Pause();
        else
            if(bgmusic.isPlaying) {}
            else
                bgmusic.Play();
        if (PlayerState.isDead || !PlayerState.isPlaying) return;
        activeXMoveSpeed = Mathf.Lerp(activeXMoveSpeed, Input.GetAxisRaw("Horizontal") * moveSpeed, acceleration * Time.deltaTime);
        activeYMoveSpeed = Mathf.Lerp(activeYMoveSpeed, Input.GetAxisRaw("Vertical") * moveSpeed, acceleration * Time.deltaTime);

        transform.position += transform.right * activeXMoveSpeed * Time.deltaTime;
        transform.position += transform.up * activeYMoveSpeed * Time.deltaTime;
        Vector3 currentPos = transform.position;

        if(transform.position.x > maxX)
        {
            transform.position = new Vector3(maxX, currentPos.y, currentPos.z);
            if (transform.position.y > maxY)
            {
                transform.position = new Vector3(maxX, maxY, currentPos.z);
            }
            else if (transform.position.y < -maxY)
            {
                transform.position = new Vector3(maxX, -maxY, currentPos.z);
            }
        }
        else if (transform.position.x < -maxX)
        {
            transform.position = new Vector3(-maxX, currentPos.y, currentPos.z);
            if (transform.position.y > maxY)
            {
                transform.position = new Vector3(-maxX, maxY, currentPos.z);
            }
            else if (transform.position.y < -maxY)
            {
                transform.position = new Vector3(-maxX, -maxY, currentPos.z);
            }
        }
        else if (transform.position.y > maxY)
        {
            transform.position = new Vector3(currentPos.x , maxY, currentPos.z);
        }
        else if (transform.position.y < -maxY)
        {
            transform.position = new Vector3(currentPos.x , -maxY, currentPos.z);
        }
    }
}