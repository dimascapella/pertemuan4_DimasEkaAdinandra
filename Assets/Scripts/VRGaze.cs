using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRGaze : MonoBehaviour
{
    public Image imgGaze;
    public Text text;
    public float time = 2;
    bool gvrStatus;
    float gvrTimer;

    public int distanceOfRay = 10;
    private RaycastHit hit;

    void Update()
    {
        if(gvrStatus){
            gvrTimer += Time.deltaTime;
            imgGaze.fillAmount = gvrTimer / time;

            if(imgGaze.fillAmount == 1){
                Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
                if (Physics.Raycast(ray, out hit, distanceOfRay)){
                    switch (hit.transform.tag)
                    {
                        case "hitam":
                            text.text = "Ini kubu hitam";
                            text.gameObject.SetActive(true);
                            break;
                        case "merah":
                            text.text = "Ini kubu merah";
                            text.gameObject.SetActive(true);
                            break;
                    }
                }
            }
        }
    }

    public void GvrON(){
        gvrStatus = true;
    }

    public void GvrOFF(){
        gvrStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;
        text.gameObject.SetActive(false);
    }
}
