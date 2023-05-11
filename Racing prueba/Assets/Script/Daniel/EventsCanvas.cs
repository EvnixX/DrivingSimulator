using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EventsCanvas : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    string strings;
    public GameObject pause_Button;
    public GameObject pause_Menu;
    public bool juegoPausado;
    public int estadodialogos;
    private void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            if (juegoPausado)
            {
                ResumeGame();
            }
            else
            {
                Pausegame();
            }
        }
        Textos();

        if (estadodialogos > 1)
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
                textMesh.text = "Adiooossss  ;D";
                break;

        }
    }
    public void Pausegame()
    {
        juegoPausado = true;
        Time.timeScale = 0f;
        pause_Button.SetActive(true);
        pause_Menu.SetActive(true);
    }

    public void ResumeGame()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        pause_Button.SetActive(false);
        pause_Menu.SetActive(false);
    }
}

