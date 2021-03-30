using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{
    public ParticleSystem teleporterDust;

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        teleporterDust.Play();
    }
}
