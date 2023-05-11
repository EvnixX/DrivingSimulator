using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class EventsCanvas : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    string strings;
    public GameObject pause_Button, pause_Menu, kilometraje, creditsButton;
    public bool juegoPausado;
    public int estadodialogos;
    private void Update()
    {
        Textos();

        if (estadodialogos > 2)
        {
            estadodialogos = 0;
        }
    }
    public void Textos ()
    {
        switch (estadodialogos)
        {
            case 0:
                textMesh.text = null;
                break;
            case 1:
                textMesh.text = "No debes acelerar ni pasarte los semáforos cuando estén en rojo.";
                break;
            case 2:
                textMesh.text = "Superaste la prueba";
                break;

        }
    }
    public void Pausegame()
    {
        juegoPausado = true;
        Time.timeScale = 0f;
        pause_Button.SetActive(true);
        pause_Menu.SetActive(true);
        kilometraje.SetActive(false);
    }

    public void ResumeGame()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        pause_Button.SetActive(false);
        pause_Menu.SetActive(false);
        kilometraje.SetActive(true);
    }
    public void Restart_Game()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Creditos()
    {
        juegoPausado = true;
        Time.timeScale = 0f;
        pause_Button.SetActive(false);
        creditsButton.SetActive(true);
        pause_Menu.SetActive(true);
        kilometraje.SetActive(false);
    }
    public void CreditosScene() 
    {
        SceneManager.LoadScene("Creditos");
    }

}

