using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {
	public Material defaultSkin;
	public Material selectedSkin;

	public int speed; //how far can the player move in total
	private int remainingSpeed; //how far can he yet move this turn
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void StartTurn(){
		remainingSpeed = speed;
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
