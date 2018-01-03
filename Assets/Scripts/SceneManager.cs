using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {


    public GameObject loginPanel;
    public GameObject communicatingPanel;
	// Use this for initialization
	
	public void OnSwitch()
    {
        loginPanel.SetActive(false);
        communicatingPanel.SetActive(true);
    }
}
