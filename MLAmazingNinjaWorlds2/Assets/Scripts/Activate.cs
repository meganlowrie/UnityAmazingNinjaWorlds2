using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    public ParticleSystem allParticles;

    // Plays particles
    public void On()
    {
        allParticles.Play();
    }
}
