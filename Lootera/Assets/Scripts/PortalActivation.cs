using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalActivation : MonoBehaviour
{
	public GameObject gameObjectToEnable;
	GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //gameObjectToEnable.SetActive(true);
		player = GameObject.Find("Player");
		int exitGateToBeEnabled = Random.Range(1,4);
		GameObject ChildGameObject1 = gameObjectToEnable.transform.Find("Exit1").gameObject;//gameObjectToEnable.transform.GetChild(0).gameObject;
		GameObject ChildGameObject2 = gameObjectToEnable.transform.Find("Exit2").gameObject;//gameObjectToEnable.transform.GetChild(1).gameObject;
		GameObject ChildGameObject3 = gameObjectToEnable.transform.Find("Exit3").gameObject;
		GameObject FlameGameObject1 = gameObjectToEnable.transform.Find("Exit1Flame1").gameObject;//gameObjectToEnable.transform.GetChild(0).gameObject;
		GameObject FlameGameObject2 = gameObjectToEnable.transform.Find("Exit1Flame2").gameObject;//gameObjectToEnable.transform.GetChild(1).gameObject;
		GameObject FlameGameObject3 = gameObjectToEnable.transform.Find("Exit2Flame1").gameObject;
		GameObject FlameGameObject4 = gameObjectToEnable.transform.Find("Exit2Flame2").gameObject;//gameObjectToEnable.transform.GetChild(0).gameObject;
		GameObject FlameGameObject5 = gameObjectToEnable.transform.Find("Exit3Flame1").gameObject;//gameObjectToEnable.transform.GetChild(1).gameObject;
		GameObject FlameGameObject6 = gameObjectToEnable.transform.Find("Exit3Flame2").gameObject;
		if(exitGateToBeEnabled==1){
			//player.transform.position = new Vector3(-0.52f, 0.54f, 0f);
			//player.transform.position = new Vector3(-70f,0.54f,150f);
			ChildGameObject1.SetActive(true);
			ChildGameObject2.SetActive(false);
			ChildGameObject3.SetActive(false);
			
			FlameGameObject1.SetActive(true);
			FlameGameObject2.SetActive(true);
			FlameGameObject3.SetActive(false);
			FlameGameObject4.SetActive(false);
			FlameGameObject5.SetActive(false);
			FlameGameObject6.SetActive(false);
		}
		else if(exitGateToBeEnabled==2){
			//player.transform.position = new Vector3(-70f,0.54f,150f);
			//player.transform.rotation = Quaternion.Euler(0, 180, 0);
			ChildGameObject1.SetActive(false);
			ChildGameObject2.SetActive(true);
			ChildGameObject3.SetActive(false);
			
			FlameGameObject1.SetActive(false);
			FlameGameObject2.SetActive(false);
			FlameGameObject3.SetActive(true);
			FlameGameObject4.SetActive(true);
			FlameGameObject5.SetActive(false);
			FlameGameObject6.SetActive(false);
		}
		else{
			ChildGameObject1.SetActive(false);
			ChildGameObject2.SetActive(false);
			ChildGameObject3.SetActive(true);
			
			FlameGameObject1.SetActive(false);
			FlameGameObject2.SetActive(false);
			FlameGameObject3.SetActive(false);
			FlameGameObject4.SetActive(false);
			FlameGameObject5.SetActive(true);
			FlameGameObject6.SetActive(true);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
