using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraddScript : MonoBehaviour
{
    private InterfaceDBM interfaceDBM = null;
    public List<string> cameraList;
    void Start()
    {
        interfaceDBM = (InterfaceDBM)GameObject.Find("Driver").GetComponent(typeof(InterfaceDBM));

        cameraList = interfaceDBM.getCameraList();
        this.gameObject.GetComponent<Dropdown>().AddOptions(cameraList);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
