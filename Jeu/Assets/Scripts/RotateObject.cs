// /!!\ Résumé du script /!!\
// Ce script fait tourner un objet autour de l'axe Z à une vitesse spécifiée par la variable `rotationSpeed`. 
// La rotation est effectuée à chaque image en fonction du temps écoulé pour assurer une rotation fluide et indépendante du framerate.

using UnityEngine;

public class RotateObjectZ : MonoBehaviour
{
    public float rotationSpeed = 100f; 

    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
