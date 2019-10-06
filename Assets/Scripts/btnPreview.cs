using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnPreview : MonoBehaviour
{
    InterfaceDBM interfaceDBM;
    // Start is called before the first frame update
    void Start()
    {
        interfaceDBM = (InterfaceDBM)GameObject.Find("Driver").GetComponent(typeof(InterfaceDBM));
        this.gameObject.GetComponent<Button>().onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        if(this.gameObject.transform.parent.name.Equals("CameraProperties1"))
        {
            interfaceDBM.cam1Preview = !interfaceDBM.cam1Preview;
        }
        else if (this.gameObject.transform.parent.name.Equals("CameraProperties2"))
        {
            interfaceDBM.cam2Preview = !interfaceDBM.cam2Preview;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
