using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    private InterfaceDBM interfaceDBM = null;
    private int sliderValue;
    // Start is called before the first frame update
    void Start()
    {
        interfaceDBM = (InterfaceDBM)GameObject.Find("Driver").GetComponent(typeof(InterfaceDBM));
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.parent.parent.name.Equals("ColorPickerUpper"))
        {
            if(this.transform.name.Equals("HueSlider"))
            {
                this.gameObject.GetComponent<Slider>().value = interfaceDBM.getColor(1)[0];
            }
            else if (this.transform.name.Equals("SaturationSlider"))
            {
                this.gameObject.GetComponent<Slider>().value = interfaceDBM.getColor(1)[1];
            }
            else if (this.transform.name.Equals("ValueSlider"))
            {
                this.gameObject.GetComponent<Slider>().value = interfaceDBM.getColor(1)[2];
            }
        }
        else if (this.transform.parent.parent.name.Equals("ColorPickerLower"))
        {
            if (this.transform.name.Equals("HueSlider"))
            {
                this.gameObject.GetComponent<Slider>().value = interfaceDBM.getColor(0)[0];
            }
            else if (this.transform.name.Equals("SaturationSlider"))
            {
                this.gameObject.GetComponent<Slider>().value = interfaceDBM.getColor(0)[1];
            }
            else if (this.transform.name.Equals("ValueSlider"))
            {
                this.gameObject.GetComponent<Slider>().value = interfaceDBM.getColor(0)[2];
            }
        }
    }
}
