using UnityEngine;

public class PlayerMovementWithCamera : MonoBehaviour
{
    public float vitesse = 1.5f;
    Animator PlayerAnimator;
    void Start(){
}

void Awake()
{
    PlayerAnimator = GetComponent<Animator>();
}


void Update()
{
    if (Input.GetKey(KeyCode.D))
    {
        Vector3 newPosition = new Vector3(0.0f, 0.0f, vitesse * Time.deltaTime);
        transform.Translate(newPosition);
        transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
        PlayerAnimator.SetBool("walk", true);
    }
    if (Input.GetKey(KeyCode.Q))
    {
        Vector3 newPosition = new Vector3(0.0f, 0.0f, vitesse * Time.deltaTime);
        transform.Translate(newPosition);
        transform.rotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
        PlayerAnimator.SetBool("walk", true);
    }
    if (Input.GetKey(KeyCode.Z))
    {
        Vector3 newPosition = new Vector3(0.0f, 0.0f, vitesse * Time.deltaTime);
        transform.Translate(newPosition);
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        PlayerAnimator.SetBool("walk", true);
    }
    if (Input.GetKey(KeyCode.S))
    {
        Vector3 newPosition = new Vector3(0.0f, 0.0f, vitesse * Time.deltaTime);
        transform.Translate(newPosition);
        transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        PlayerAnimator.SetBool("walk", true);
    }
    if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.S))
    {
        PlayerAnimator.SetBool("walk", false);
    }
}

}
