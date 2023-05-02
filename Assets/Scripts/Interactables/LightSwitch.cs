
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

	
public class LightSwitch : MonoBehaviour {
	
	public GameObject playerCam;
	private LightSwitchController lightSwitch;
	private float PickupRange = 3f;
	
	private Ray playerAim;
	private GameObject objectHeld;
	
	void Start () {
	
	}
	
	void Update () {
		if(Input.GetMouseButtonDown(0)){

                tryLightSwitch();
        
		}
		
		
	}
	
	private void tryLightSwitch(){
		Ray playerAim = playerCam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
		RaycastHit hit;
		
		if (Physics.Raycast (playerAim, out hit, PickupRange)){
			objectHeld = hit.collider.gameObject;
			if(objectHeld.tag == "LightSwitch")
			{
				lightSwitch = objectHeld.GetComponent<LightSwitchController>();
				lightSwitch.lightChange();

			}
			else
			{
				objectHeld = null;
			}
		}
	}
	
	
}
