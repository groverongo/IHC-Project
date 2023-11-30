using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EleccionRuta : MonoBehaviour
{
    public static int indice = 3;


    public GameObject[] menuObjects;

    public void SetMenu(int menu)
    {
        for (int i = 0; i < menuObjects.Length; i++)
        {
            if (i == menu) {
                menuObjects[i].SetActive(true);
            }
            else
            {
                menuObjects[i].SetActive(false);
            }
        }
    }


    private void LoadCircuito()
    {
        // Get the current scene index
        // int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the next scene by incrementing the current scene index
        // int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        // SceneManager.LoadScene(nextSceneIndex);
        SceneManager.LoadScene("Circuito");

        // SceneManager.LoadScene("LightingBase", LoadSceneMode.Single);

        // SceneManager.LoadSceneAsync("Circuito", LoadSceneMode.Additive);
    }

    public void LoadTutorialScene(){


        // SceneManager.LoadScene("TutorialRack");
        // SceneManager.LoadScene("LightingBase", LoadSceneMode.Single);

        SceneManager.LoadScene("TutorialRack");
    }



    public void SetRuta(int ruta) {
        indice = ruta;
        Debug.Log("Set Ruta: "+indice.ToString());
        LoadCircuito();
    }

    void Start()
    {
        SetMenu(0);
    }
}

