using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] Outlines;

    public float[] keyValuePineTree = {100f,100f,99.1f,89.3f,69.9f,100f,90.3f,76.9f,65.1f,48.5f,41.8f,28.7f,80.3f,58.3f,51.5f,37.9f,18.9f,9.1f,6.8f,100f,100f,100f,100f,100f};

    public SkinnedMeshRenderer skinedRendererPot1;
    public SkinnedMeshRenderer skinedRendererPot2;

    public bool doneCarving=false;
    public GameObject mainCamera;
    public GameObject invisibleBoxCollider;
    public GameObject AccuracyPanel;

    GameObject currentActiveOutline;
    public int score=0;
    public float percentage;

    public Text accuracyText;
    // Start is called before the first frame update
    void Start()
    {
        currentActiveOutline = Outlines[Random.Range (0, Outlines.Length)];
        currentActiveOutline.SetActive(true);
    }

    //Update is called once per frame
    void Update()
    {
        
    

        if(doneCarving){
            float rotateZ = 90f;
          
            mainCamera.transform.rotation =  Quaternion.Slerp(mainCamera.transform.rotation, Quaternion.Euler(0,0,rotateZ), 20 *  Time.deltaTime);
            float step = 20 * Time.deltaTime;
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, new Vector3(0,2.35f,-7.65f), step);
        }
    }

    public void CalculateAccuracy(){
        /*switch(currentActiveOutline.name){
            case "pine_tree":
                break;
            case "sword":
                break;
            case default:
                break;
        }*/
        Debug.Log(skinedRendererPot2.GetBlendShapeWeight(10)+" "+keyValuePineTree.Length);

        for(int i=0;i<12;i++){
            
            if(RoughlyEqual(skinedRendererPot1.GetBlendShapeWeight(i),keyValuePineTree[i])){
                score++;
            }

            if(RoughlyEqual(skinedRendererPot2.GetBlendShapeWeight(i),keyValuePineTree[i+12])){
                score++;
            }
        }
        

        Debug.Log("Total Score is : "+score);
        percentage = ((float)score / keyValuePineTree.Length) * 100;
        StartCoroutine(DisplayAccuracy());
        Debug.Log("Accuracy is: "+percentage+"%");

    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public IEnumerator DisplayAccuracy(){
        AccuracyPanel.SetActive(true);
        int counter = 0;
        
        while(counter<=(int)percentage+10){
            yield return new WaitForSeconds(0.04f);
            counter+=1;
            accuracyText.text = counter.ToString()+"%";
        }
        while(counter>=(int)percentage){
            yield return new WaitForSeconds(0.1f);
            counter-=1;
            accuracyText.text = counter.ToString()+"%";
        }
        accuracyText.text = percentage.ToString()+"%";
        
    }


    public void FinishCarvingBTN(){
        doneCarving = true;
        AccuracyPanel.SetActive(true);
        invisibleBoxCollider.SetActive(false);
        CalculateAccuracy();
    }

    static bool RoughlyEqual(float a, float b) {
        float treshold = 4f; //how much roughly
        return (Mathf.Abs(a-b)< treshold);
    }
}
