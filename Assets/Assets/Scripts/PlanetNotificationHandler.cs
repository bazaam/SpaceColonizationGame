﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetNotificationHandler : MonoBehaviour
{
    private ParticleSystem planetParticles;

    void Start ()
    {
        planetParticles = gameObject.GetComponent<ParticleSystem>();
    }
    void PlayParticles()
    {
        planetParticles.Play();
    }
}
