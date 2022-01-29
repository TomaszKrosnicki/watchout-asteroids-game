using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionController : MonoBehaviour
{
    AudioSource audiosource;
    public GameObject originalObject;
    public GameObject fracturedObject;
    [SerializeField] AudioClip point;
    [SerializeField] AudioClip explosion;
    [SerializeField] AudioClip fuel;
    [SerializeField] ParticleSystem explosionParticle;
    [SerializeField] ParticleSystem[] enginesParticles;
    MeshRenderer mr;
    MeshCollider mc;
    void Start() 
    {
        PlayerPrefs.SetInt("score",0);
        PlayerPrefs.SetInt("finalScore",0);
        PlayerPrefs.SetInt("distance",0);
        audiosource = GetComponent<AudioSource>();
        mr = GetComponent<MeshRenderer>();
        mc = GetComponent<MeshCollider>();
    }

    void Update() 
    {
        audiosource.volume = PlayerPrefs.GetFloat("soundsVolume");
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Asteroid" && !PlayerState.isDead)
        {
            PlayerState.isDead = true;
            audiosource.PlayOneShot(explosion);
            explosionParticle.Play();
            enginesParticles[0].Stop();
            enginesParticles[1].Stop();
            mr.enabled = false;
            mc.enabled = false;
            SpawnFracturedObj();
        }
        else if (other.gameObject.tag == "Star")
        {
            audiosource.PlayOneShot(point);
            GameData.singleton.UpdateScore(10);
            other.gameObject.SetActive(false);
            GenerateWorld.gw.GenerateSectors();
        }
        else if (other.gameObject.tag == "Fuel")
        {
            audiosource.PlayOneShot(fuel);
            PlayerState.fuel += 25;
            other.gameObject.SetActive(false);
            GenerateWorld.gw.GenerateSectors();
        }
    }
    void SpawnFracturedObj()
    {
        GameObject fractObj = Instantiate(fracturedObject, transform.position, Quaternion.identity);
        fractObj.GetComponent<Explode>().ExplodeObj();
    }
}
