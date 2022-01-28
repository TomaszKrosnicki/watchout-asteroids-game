using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBG : MonoBehaviour
{
    public GameObject[] bgAsteroid;
    float a = 100f;
    void Start()
    {
        Vector3 pos = this.transform.position;
        float zPos = pos.z;
        for (int i = 0; i <30; i++)
        {
            float xPos = Random.Range(-a, a);
            float yPos = Random.Range(-a, a);
            Vector3 p = new Vector3(pos.x + xPos, pos.y + yPos, zPos);
            float aRotationX = Random.Range(0f, 360f);
            float aRotationY = Random.Range(0f, 360f);
            float aRotationZ = Random.Range(0f, 360f);
            Quaternion rot = Quaternion.Euler(aRotationX, aRotationY, aRotationZ);
            int aNumber = Random.Range(0, bgAsteroid.Length);
            Instantiate(bgAsteroid[aNumber], p, rot);
            zPos += 30f;
        }
    }
}
