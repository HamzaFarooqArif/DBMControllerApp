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
                interfaceDBM.selectedCamera1Idx = dd.value - 1;
                if (interfaceDBM.selectedCamera1Idx == interfaceDBM.selectedCamera2Idx)
                {
                    interfaceDBM.Capture1 = interfaceDBM.Capture2;
                }
                else
                {
                    interfaceDBM.Capture1 = new Emgu.CV.VideoCapture(interfaceDBM.selectedCamera1Idx);
                }
            }
            else if (this.gameObject.transform.parent.name.Equals("CameraProperties2"))
            {
                interfaceDBM.selectedCamera2Idx = dd.value - 1;
                if (interfaceDBM.selectedCamera1Idx == interfaceDBM.selectedCamera2Idx)
                {
                    interfaceDBM.Capture2 = interfaceDBM.Capture1;
                }
                else
                {
                    interfaceDBM.Capture2 = new Emgu.CV.VideoCapture(interfaceDBM.selectedCamera2Idx);
                }
            }
            dd.interactable = false;
            this.gameObject.GetComponent<Button>().interactable = false;
            interfaceDBM.getSibling(this.gameObject, "btnPreview").GetComponent<Button>().interactable = true;
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
