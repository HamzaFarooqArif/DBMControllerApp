using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;
using UnityEngine.UI;
public class mainDriver : MonoBehaviour
{
    private InterfaceDBM interfaceDBM = null;
    private VideoCapture _capture1 = null;
    void Start()
    {
        interfaceDBM = (InterfaceDBM)GameObject.Find("Driver").GetComponent(typeof(InterfaceDBM));
        CvInvoke.UseOpenCL = false;
        _capture1 = new VideoCapture(0);

        //GameObject.Find("UpperChosenColor").GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        interfaceDBM.updateCameraList();
        interfaceDBM.setColorSpace(0, hue: 60, sat:255, val:255);
        interfaceDBM.setColorSpace(1, hue: 120, sat: 255, val: 255);

        //Debug.Log(interfaceDBM.getColorParam(1, 1));
    }

    // Update is called once per frame
    void Update()
    {
        ProcessFrame();
    }

    private void ProcessFrame()
    {
        Image<Bgr, byte> frame1 = _capture1.QueryFrame().ToImage<Bgr, byte>();
        Image<Bgr, Byte> frame1Copy = frame1.Clone();
        frame1Copy._SmoothGaussian(11);
        Image<Hsv, byte> frame1HSV = frame1Copy.Convert<Hsv, byte>();

        CvInvoke.Imshow("Frame", frame1HSV);
    }

    void OnApplicationQuit()
    {
        CvInvoke.DestroyAllWindows();
    }
}
