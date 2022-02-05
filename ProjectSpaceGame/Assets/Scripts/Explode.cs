/*
    Klasa odpowiedzialna za efekt wybuchu.
    Obiektem posiadającym ten skrypt jest "FracturedSpaceship", czyli statek podzielony na kawałki.
    Kawałki statku poddawane są symulacji z udziałem sił wybuchu,
    następnie po opóźnieniu, fragmenty statku są niszczone.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public float minForce;
    public float maxForce;
    public float radius;
    public float destroyDelay;

    public void ExplodeObj()
    {
        foreach (Transform t in transform)
        {
            var rb = t.GetComponent<Rigidbody> ();

            if(rb != null)
            {
                rb.AddExplosionForce(Random.Range(minForce, maxForce), transform.position, radius);
            }

            Destroy(t.gameObject, destroyDelay);
            Destroy(gameObject, destroyDelay);
        }
    }

}
