using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetParticles : MonoBehaviour
{
    private var planetParticles : ParticleSystem;

    function Start ()
    {
        planetParticles = GetComponent(ParticleSystem);
        planetParticles.Play();
    }
}
