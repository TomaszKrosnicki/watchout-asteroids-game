/*
    Skrypt wyłączający ParticlesSystem silników gdy fuel = 0
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffEngines : MonoBehaviour
{
    public ParticleSystem engineParticles;
    
    void Update()
    {
        if(PlayerState.fuel == 0)
            engineParticles.Stop();
    }
}
