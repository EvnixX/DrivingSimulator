using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
  public void Menu()
  {
        SceneManager.LoadScene("Menu");
  }

  public void Tutorial()
  {
       SceneManager.LoadScene("Controles");
  }

    public void Controles()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void Salir()
    {
        Application.Quit();
    }

}
