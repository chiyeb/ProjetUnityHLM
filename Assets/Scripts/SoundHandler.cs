// /!!\ Résumé du script /!!\
// Ce script joue un son lorsque le collider de l'objet auquel il est attaché entre en contact avec un autre collider.
// Il utilise la méthode `OnTriggerEnter` pour détecter la collision et joue le son à l'aide de l'`AudioSource` attaché à l'objet.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    private AudioSource source;
    private Collider collider;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        collider = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.name);
        if (source != null)
        {
            source.Play();
        }
    }
}
