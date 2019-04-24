using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalPopup : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject dungeonUI,popup;
	/*void Start(){
		popup = GameObject.Find("ExitPopup");
		//popup.SetActive(false);
	}*/
	public void OnTriggerEnter(Collider col){
		//Debug.Log("..................................................................................Collided portal");
		dungeonUI = GameObject.Find("Dungeon UI");
		popup = dungeonUI.transform.Find("ExitPopup").gameObject;
		string nameOfOther = col.gameObject.name;
        if(nameOfOther.Equals("Player"))
        {
		popup.SetActive(true);
		}
	
	}
	
	public void OnTriggerExit(Collider col){
		string nameOfOther = col.gameObject.name;
        if(nameOfOther.Equals("Player"))
        {
		StartCoroutine(popdown(1));
		}
	}
	
	IEnumerator popdown(int sec){
		yield return new WaitForSeconds(sec);
		popup.SetActive(false);
	}

    
}
