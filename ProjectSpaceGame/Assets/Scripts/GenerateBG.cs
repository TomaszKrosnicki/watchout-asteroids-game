/*
    Klasa odpowiedzialna za tworzenie asteroid w tle na początku rozgrywki.
    Skrypt jest przypięty do pustego obiektu.
    Dodajemy do tablicy obiekty które chcemy wygenerować.
    Obiekt jest losowany z podanej w tablicy puli i tworzony w płaszczyźnie pustego obiektu 
    posiadającego skrypt (od -100 do 100 w osiach x i y), z losowym obrotem,
    następnie pusty obiekt jest przesuwany o 30 jednostek po osi z.
    Generowane jest w ten sposób 30 asteroid na każdy pusty obiekt.
*/

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
