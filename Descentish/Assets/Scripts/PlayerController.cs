using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {
	public Material defaultSkin;
	public Material selectedSkin;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void SetActiveSkin(Skin skin)
	{
		Debug.Log("changing skin to " + skin.ToString() + " @"+transform.position.ToString());
		switch(skin){
		case Skin.Selected:
			renderer.material = selectedSkin;
			break;
		default:
			renderer.material = defaultSkin;
			break;
		}
	
	}

}
