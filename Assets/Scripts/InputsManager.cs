// /!!\ Résumé du script /!!\
// Ce script gère la personnalisation des touches du joueur. 
// Il permet de sauvegarder et de charger les touches définies pour les mouvements (avant, arrière, gauche, droite) et l'interaction (touche 'F') à l'aide de PlayerPrefs. 
// Lors du démarrage, les touches sont chargées à partir des paramètres sauvegardés, et les modifications peuvent être enregistrées.

using UnityEngine;

public class InputManager : MonoBehaviour
{
    public KeyCode moveForwardKey = KeyCode.W;
    public KeyCode moveBackwardKey = KeyCode.S;
    public KeyCode moveLeftKey = KeyCode.A;
    public KeyCode moveRightKey = KeyCode.D;
    public KeyCode interactKey = KeyCode.F;

    void Start()
    {
        // Charger les touches sauvegardées
        LoadKeyBindings();
    }

    public void SaveKeyBindings()
    {
        PlayerPrefs.SetInt("MoveForwardKey", (int)moveForwardKey);
        PlayerPrefs.SetInt("MoveBackwardKey", (int)moveBackwardKey);
        PlayerPrefs.SetInt("MoveLeftKey", (int)moveLeftKey);
        PlayerPrefs.SetInt("MoveRightKey", (int)moveRightKey);
        PlayerPrefs.SetInt("InteractKey", (int)interactKey);
        PlayerPrefs.Save();
    }

    public void LoadKeyBindings()
    {
        moveForwardKey = (KeyCode)PlayerPrefs.GetInt("MoveForwardKey", (int)KeyCode.W);
        moveBackwardKey = (KeyCode)PlayerPrefs.GetInt("MoveBackwardKey", (int)KeyCode.S);
        moveLeftKey = (KeyCode)PlayerPrefs.GetInt("MoveLeftKey", (int)KeyCode.A);
        moveRightKey = (KeyCode)PlayerPrefs.GetInt("MoveRightKey", (int)KeyCode.D);
        interactKey = (KeyCode)PlayerPrefs.GetInt("InteractKey", (int)KeyCode.F);
    }
}
