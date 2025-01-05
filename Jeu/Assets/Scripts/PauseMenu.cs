// /!!\ Résumé du script /!!\
// Ce script gère un menu de pause dans le jeu. 
// Lorsque le joueur appuie sur la touche Échap, un menu s'affiche ou se ferme. 
// Ce menu permet de quitter le jeu ou de retourner au menu principal. 
// Le jeu est mis en pause lorsque le menu est actif.

using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject menuPanel; 

    private bool isMenuActive = false;

    void Start(){
        if (isMenuActive){
            menuPanel.SetActive(false);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    void ToggleMenu()
    {
        isMenuActive = !isMenuActive;
        menuPanel.SetActive(isMenuActive);

        Time.timeScale = isMenuActive ? 0 : 1;
    }

    public void QuitGame()
    {
        Application.Quit(); 
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene("menu"); 
    }
}
