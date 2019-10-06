using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnStartCapture : MonoBehaviour
{
    Dropdown dd;
    InterfaceDBM interfaceDBM;
    void Start()
    {
        interfaceDBM = (InterfaceDBM)GameObject.Find("Driver").GetComponent(typeof(InterfaceDBM));
        dd = interfaceDBM.getSibling(this.gameObject, "CameraList").GetComponent<Dropdown>();

        this.gameObject.GetComponent<Button>().onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if(dd.value > 0)
        {
            if (this.gameObject.transform.parent.name.Equals("CameraProperties1"))
            {
                interfaceDBM.selectedCamera1Idx = dd.value;
                //Debug.Log("Cam1Idx: " + interfaceDBM.selectedCamera1Idx);
            }
            else if (this.gameObject.transform.parent.name.Equals("CameraProperties2"))
            {
                interfaceDBM.selectedCamera2Idx = dd.value;
                //Debug.Log("Cam2Idx: "+ interfaceDBM.selectedCamera2Idx);
            }
            dd.interactable = false;
            this.gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            Debug.Log("Warning: Select a valid Camera.");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
