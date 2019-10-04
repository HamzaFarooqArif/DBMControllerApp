using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;
public class mainDriver : MonoBehaviour
{
    private InterfaceDBM interfaceDBM = null;
    private VideoCapture _capture1 = null;
    void Start()
    {
        interfaceDBM = (InterfaceDBM)GameObject.Find("Driver").GetComponent(typeof(InterfaceDBM));

        CvInvoke.UseOpenCL = false;
        _capture1 = new VideoCapture(0);

        interfaceDBM.updateCameraList();
        interfaceDBM.setColorSpace(1, hue: 100, sat:50);
        
        Debug.Log(interfaceDBM.getColorParam(1, 1));
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
