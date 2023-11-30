using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TutorialSteps : MonoBehaviour
{
    public static int currentStep = 0;


    public KeyCode prev;
    public KeyCode next;

    public GameObject[] stepsFrames;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < stepsFrames.Length; i++)
        {
          
            stepsFrames[i].SetActive(false);
            GameObject textObject = new GameObject("MyText");
          
            
            // Make the new GameObject a child of another GameObject (in this case, the current GameObject)
            textObject.transform.parent = stepsFrames[i].transform;
        

            // Add the TextMeshPro component to the new GameObject
            TextMeshProUGUI textMeshPro = textObject.AddComponent<TextMeshProUGUI>();

            // Set the text content
            textMeshPro.text = (i+1).ToString()+"/"+(stepsFrames.Length).ToString();
            textMeshPro.color = Color.black; 
            textMeshPro.fontSize = 12;

            RectTransform textRectTransform = textObject.GetComponent<RectTransform>();
            if (textRectTransform != null)
            {
                // Set the anchored position (you can modify these values)
                textRectTransform.anchoredPosition3D = new Vector3(101.5f, -71.3f, 0f);
                textObject.transform.localScale = new Vector3(1f, 1f, 1f);
                //set all rotation to 0
                textRectTransform.localRotation = Quaternion.Euler(0, 0, 0);

            }


        }

        stepsFrames[0].SetActive(true);
        
    }

    public void PrevStep(){
        int prevStep = currentStep - 1 ;


        if(prevStep >= 0){
            if(currentStep < stepsFrames.Length)
                stepsFrames[currentStep].SetActive(false);
            Debug.Log("que2");

            currentStep = prevStep;
            stepsFrames[currentStep].SetActive(true);

        }

    }

    public void NextStep()
    {

        if(currentStep == stepsFrames.Length)return;
        
        int nextStep = (currentStep + 1);

        Debug.Log(nextStep.ToString());


        stepsFrames[currentStep].SetActive(false);
        Debug.Log("que");
        currentStep = nextStep;
        if(currentStep < stepsFrames.Length)
            stepsFrames[currentStep].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(next))
        {
            NextStep();
        }
        if(Input.GetKeyDown(prev)){
            PrevStep();
        }
    }

}
