using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class GoBack : MonoBehaviour
{

    private bool confirm = false;

    public KeyCode goBackKey;
    public GameObject confirmText;

    // Start is called before the first frame update
    void Start()
    {
        confirmText.SetActive(false);
        
    }

    public void goBack() {

        if(confirm){

            //go back to previous scene
            SceneManager.LoadScene("MenuFinalFinal");
            confirm = false;
            confirmText.SetActive(false);

        }else{
            confirm = true;
            confirmText.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(goBackKey)){

            goBack();


        }
        
        
    }
}
