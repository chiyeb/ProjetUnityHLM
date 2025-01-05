// /!!\ Résumé du script /!!\
// Ce script gère le comportement d'un ennemi dans le jeu. 
// L'ennemi se déplace vers un point cible à une vitesse spécifiée. 
// Lorsqu'il entre en collision avec un piège, il ajoute des points au score du joueur et appelle une fonction pour gérer la mort de l'ennemi.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyHandler : MonoBehaviour
{
    public Transform target;
    public int numberOfPoint = 10;
    public GameManager gameManager;
    public float speed = 5f;
    public bool isMoving { get; private set; }

    private Rigidbody rb;
    private Vector3 lastPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastPosition = transform.position; 
    }
    void Update()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        rb.MovePosition(pos);
        transform.LookAt(target);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trap"))
        {
            gameManager.AddScore(this.numberOfPoint);
            gameManager.EnnemyDead();
        }
    }
}
