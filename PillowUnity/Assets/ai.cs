using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class ai : MonoBehaviour
{
    // Start is called before the first frame update
  
    [SerializeField] private Renderer middle;
    [SerializeField] private Renderer ToObj1;
    [SerializeField] private Renderer ToObj2;
    [SerializeField] private Renderer Choice1;
    [SerializeField] private Renderer Choice2;

    [SerializeField] private Renderer oldMaterial;
    public int CounSelect1 = 0;
    public int CounSelect2 = 0;
    /*
    public GameObject Select1;
    public GameObject Select2;

    public GameObject Middle;
    public GameObject ToObj1; 
    public GameObject ToObj2;*/

    public string comPort = "COM3";
    public int baudRate = 115200;

    private SerialPort serialPort;


    void Start()
    {
        serialPort = new SerialPort(comPort, baudRate);
        serialPort.Open();
  
       

    }
   

    void Update()
    {
        
        if (serialPort.IsOpen)
        {
            try
            {
                // Read a line of text from the serial port
                string data = serialPort.ReadLine();
                float XFloat = Convert.ToSingle(data);
                Debug.Log(data);
                transform.rotation =  Quaternion.Euler(XFloat * 90+90, -90, 90);
               // var oldMaterial = material1.material;
                if (XFloat > -0.2 && XFloat < 0.2)
                {
                    //color MIDDLE
                    middle.material.color = Color.yellow;
                    ToObj1.material = oldMaterial.material;
                    ToObj2.material = oldMaterial.material;
                    Choice1.material = oldMaterial.material;
                    Choice2.material = oldMaterial.material;
                    CounSelect1 = 0;
                    CounSelect2 = 0;
                }
               
                if (XFloat > 0.2 && XFloat < 0.6)
                {
                    //color TOOBJ1
                    middle.material = oldMaterial.material;

                    ToObj1.material.color = Color.yellow;

                    ToObj2.material = oldMaterial.material;
                    Choice1.material = oldMaterial.material;
                    Choice2.material = oldMaterial.material;
                    CounSelect1 = 0;
                    CounSelect2 = 0;

                    //choice1.GetComponent<Renderer>().material.SetColor("kgf", new Color(9, 9, 200));
                }
                if (XFloat > 0.6 && XFloat < 1)
                {
                    //color CHOICE ONE
                    middle.material = oldMaterial.material;

                    ToObj1.material = oldMaterial.material;

                    ToObj2.material = oldMaterial.material;
                    Choice1.material.color = Color.yellow;
                    Choice2.material = oldMaterial.material;
                    CounSelect1++;
                  
                    CounSelect2 = 0;


                    //choice1.GetComponent<Renderer>().material.SetColor("kgf", new Color(9, 9, 200));
                }
                if (XFloat > 0.6 && XFloat < 1 && CounSelect1 > 20)
                {
                    //color CHOICE ONE and GREEN
                    middle.material = oldMaterial.material;

                    ToObj1.material = oldMaterial.material;

                    ToObj2.material = oldMaterial.material;
                    Choice1.material.color = Color.green;
                    Choice2.material = oldMaterial.material;
                    CounSelect1++; 
                    
                    CounSelect2 = 0;


                    //choice1.GetComponent<Renderer>().material.SetColor("kgf", new Color(9, 9, 200));
                }

                if (XFloat < -0.2 && XFloat > -0.6)
                {
                    //color CHOICE TOOBJ2
                    middle.material = oldMaterial.material;

                    ToObj1.material = oldMaterial.material;

                    ToObj2.material.color = Color.yellow;
                    Choice1.material = oldMaterial.material;
                    Choice2.material = oldMaterial.material;
                    CounSelect1 = 0;
                    CounSelect2 = 0;

                    //choice1.GetComponent<Renderer>().material.SetColor("kgf", new Color(9, 9, 200));
                }
                if (XFloat < -0.6 && XFloat > -1)
                {
                    //color CHOICE 2 
                    middle.material = oldMaterial.material;

                    ToObj1.material = oldMaterial.material;

                    ToObj2.material = oldMaterial.material;
                    Choice1.material = oldMaterial.material;
                    Choice2.material.color = Color.yellow;
                    CounSelect2++;
                    CounSelect1 = 0;
                    

                    //choice1.GetComponent<Renderer>().material.SetColor("kgf", new Color(9, 9, 200));
                }
                if (XFloat < -0.6 && XFloat > -1 && CounSelect2 > 20)
                {
                    //color CHOICE 2  AND GREEN
                    middle.material = oldMaterial.material;

                    ToObj1.material = oldMaterial.material;

                    ToObj2.material = oldMaterial.material;
                    Choice1.material = oldMaterial.material;
                    Choice2.material.color = Color.green;
                    CounSelect2++;
                    CounSelect1 = 0;
                   

                    //choice1.GetComponent<Renderer>().material.SetColor("kgf", new Color(9, 9, 200));
                }




                // TODO: process the data received from the Arduino
            }
            catch (System.Exception e)
            {
                Debug.LogError(e.Message);
            }
        }
    }
}



