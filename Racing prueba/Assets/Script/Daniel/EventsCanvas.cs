using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EventsCanvas : MonoBehaviour
{
    //public GameObject carros;
    public TextMeshProUGUI textMesh;
    public string strings;
    //[TextArea]
    //public GameObject carro;
    public GameObject pause_Button;
    public GameObject pause_Menu;
    public bool juegoPausado;
    public int estadodialogos = 1;

    private void Start()
    {

    }
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
    }
    public void Textos ()
    {
        switch (estadodialogos)
        {
            case 1:
                textMesh.text = "Holaaaaa";
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

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Autos")
        {
            Pausegame();
            estadodialogos++;
        }
    }*/
}

