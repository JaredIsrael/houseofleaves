
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

	
public class LightSwitchController: MonoBehaviour {
	[SerializeField] GameObject lightObj;
	public bool isOn = true;
	public void lightChange()
	{
		Debug.Log(lightObj.name);
		if (isOn)
		{
            isOn = false;
            lightObj.SetActive(false);
		}
		else
		{
			isOn = true;
			lightObj.SetActive(true);
			
		}
	}
	
	
}
