using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    private InterfaceDBM interfaceDBM = null;
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        interfaceDBM = (InterfaceDBM)GameObject.Find("Driver").GetComponent(typeof(InterfaceDBM));
        slider = this.gameObject.GetComponent<Slider>();
        slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }
    public void ValueChangeCheck()
    {
        if (this.transform.parent.parent.name.Equals("ColorPickerUpper"))
        {
            if (this.transform.name.Equals("HueSlider"))
            {
                interfaceDBM.setColorSpace(1, hue: (int)slider.value);
            }
            else if (this.transform.name.Equals("SaturationSlider"))
            {
                interfaceDBM.setColorSpace(1, sat: (int)slider.value);
            }
            else if (this.transform.name.Equals("ValueSlider"))
            {
                interfaceDBM.setColorSpace(1, val: (int)slider.value);
            }
        }
        else if (this.transform.parent.parent.name.Equals("ColorPickerLower"))
        {
            if (this.transform.name.Equals("HueSlider"))
            {
                interfaceDBM.setColorSpace(0, hue: (int)slider.value);
            }
            else if (this.transform.name.Equals("SaturationSlider"))
            {
                interfaceDBM.setColorSpace(0, sat: (int)slider.value);
            }
            else if (this.transform.name.Equals("ValueSlider"))
            {
                interfaceDBM.setColorSpace(0, val: (int)slider.value);
            }
        }
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
