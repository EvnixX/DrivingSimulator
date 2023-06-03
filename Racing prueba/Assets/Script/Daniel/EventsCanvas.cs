using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EventsCanvas : MonoBehaviour
{
    public TextMeshProUGUI textAdvertencia, textInformativo;
    public GameObject advObj, infoObj ,pause_Button, pause_Menu, kilometraje, creditsButton,imgGeneral, imgAmarilla, imgAzul, imgRoja;
    public bool juegoPausado;
    public int dialogosAdvertencias,dialogosInformativos;
    private void Update()
    {
        Advertencias();
        Informacion();

        if (dialogosAdvertencias > 3)
        {
            dialogosAdvertencias = 0;
        }

        if (dialogosInformativos > 3)
        {
            dialogosInformativos = 0;
        }
    }
    public void Advertencias ()
    {
        switch (dialogosAdvertencias)
        {
            case 0:
                textAdvertencia.text = null;
                break;
            case 1:
                textAdvertencia.text = "No debes acelerar ni pasarte los sem�foros cuando est�n en rojo.";
                break;
            case 2:
                textAdvertencia.text = "Superaste la prueba.";
                break;
            case 3:
                textAdvertencia.text = "Recoge los objetos por el mapa para conocer un poco sobre algunas se�alizaciones.";
                break;

        }
    }
    public void Informacion() 
    {
        switch (dialogosInformativos)
        {
            case 0:
                textInformativo.text = null;
                break;
            case 1:
                textInformativo.text = "En Colombia, las se�alizaciones de tr�nsito amarillas " +
                    "tienen diferentes prop�sitos y se utilizan para brindar informaci�n " +
                    "y advertencias a los conductores y peatones en las v�as. ";
                break;
            case 2:
                textInformativo.text = "Las se�alizaciones azules proporcionan informaci�n �til a conductores y peatones en las v�as, " +
                    "orient�ndolos hacia destinos espec�ficos, indicando servicios cercanos y brindandoles indicaciones generales.";
                break;
            case 3:
                textInformativo.text = "Las se�alizaciones rojas hacen cumplir las normas de tr�nsito, indicando prohibiciones, " +
                    "obligaciones y restricciones. Su objetivo es regular el tr�fico, " +
                    "promover la seguridad vial y mantener el orden en las carreteras.";
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

