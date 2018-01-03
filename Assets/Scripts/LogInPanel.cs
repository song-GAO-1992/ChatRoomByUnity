using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogInPanel : MonoBehaviour {

   
    public Text nameInputTxt;
    public Text ipInputTxt;
    public Text portInputTxt;

   
    //private string name;
    //private string ipStr;
    //private string portStr;


    public void OnLogInClick()
    {
        IpInfo.name = nameInputTxt.text;
        IpInfo.ipStr = ipInputTxt.text;
        IpInfo.portStr = int.Parse(portInputTxt.text);
    }



}
