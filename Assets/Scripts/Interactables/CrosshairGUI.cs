
using UnityEngine;
using System.Collections;

public class CrosshairGUI : MonoBehaviour {


public Texture2D m_crosshairTexture;
public Texture2D m_useTexture;
public float RayLength = 3f;

public bool m_DefaultReticle;
public bool m_UseReticle;
public bool m_ShowCursor = true;

private bool m_bIsCrosshairVisible = true;
private Rect m_crosshairRect;
private Ray playerAim;
private Camera playerCam;
 
	void  Update (){
		playerCam = Camera.main;
		Ray playerAim = playerCam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
		RaycastHit hit;
	
		if (Physics.Raycast (playerAim, out hit, RayLength))
			{
				if(hit.collider.gameObject.tag == "Interact")
				{
					m_DefaultReticle = false;
					m_UseReticle = true;
				}
				if(hit.collider.gameObject.tag == "InteractItem")
				{
					m_DefaultReticle = false;
					m_UseReticle = true;
				}
				if(hit.collider.gameObject.tag == "Door")
				{
					m_DefaultReticle = false;
					m_UseReticle = true;
				}
				if(hit.collider.gameObject.tag == "LightSwitch")
				{
                m_DefaultReticle = true;
              
                m_UseReticle = false;
            }
			}else{
           // m_DefaultReticle = true;
            m_DefaultReticle = false;
					m_UseReticle = false;		
			}
		
		if(Input.GetKeyDown(KeyCode.C)) {
			m_ShowCursor = !m_ShowCursor;
		}
		/*
		if(m_ShowCursor){
			Cursor.visible = (true);
			Cursor.lockState = CursorLockMode.None;					
		}
		else {
			Cursor.visible = (false);
			Cursor.lockState = CursorLockMode.Locked;						
		}
		*/
	}
 
	void  Awake (){
	    if(m_DefaultReticle){
		  m_crosshairRect = new Rect((Screen.width - (m_crosshairTexture.width / 10)) / 2, 
								(Screen.height - (m_crosshairTexture.height / 10)) / 2, 
								m_crosshairTexture.width /10, 
								m_crosshairTexture.height / 10);
	    }
		
	    if(m_UseReticle){
		  m_crosshairRect = new Rect((Screen.width - (m_useTexture.width/10)) / 2, 
								(Screen.height - (m_useTexture.height /10)) / 2, 
								m_useTexture.width /10, 
								m_useTexture.height / 10 );
	    }
	}
 
	void  OnGUI (){
		if(m_bIsCrosshairVisible)
		  if(m_DefaultReticle){
			GUI.DrawTexture(m_crosshairRect, m_crosshairTexture);
		 }
		  if(m_UseReticle){
			GUI.DrawTexture(m_crosshairRect, m_useTexture);
		 }
	}
}