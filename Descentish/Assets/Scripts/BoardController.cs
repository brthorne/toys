using UnityEngine;
using System.Collections.Generic;

public class BoardController : MonoBehaviour {

	public GameObject tileGrass;
	public GameObject tileWall;
	public GameObject playerType;
	public GameObject monsterType;

	public int width=8;
	public int depth=8;
	public const float BOARD_HEIGHT = 0;
	int? playerSelectionIndex;


	// Use this for initialization
	void Start () {
		createBoard();
		createPlayers();
		createMonsters();
	}

	void createBoard ()
	{

		for(int x=0;x<width;x++){
			for(int z=0;z<depth;z++){
				if(x==4)
				{
					GameObject tile = Instantiate(tileWall,new Vector3(x,BOARD_HEIGHT + .5f,z),Quaternion.identity) as GameObject;
					tile.layer = (int)Layer.Blocking; 
					Layers.AddLayerObject(Layer.Blocking,tile);
				}else{
					GameObject tile = Instantiate(tileGrass,new Vector3(x,BOARD_HEIGHT,z),Quaternion.identity) as GameObject;
					tile.layer = (int)Layer.BaseTerrain; 
					Layers.AddLayerObject(Layer.BaseTerrain,tile);
				}
			}
		}
	}

	void createPlayers(){
		GameObject player = Instantiate(playerType,new Vector3(0,.75f,0),Quaternion.identity) as GameObject;
		player.layer = (int)Layer.PlayerCharacters;
		Layers.AddLayerObject(Layer.PlayerCharacters,player);

		player = Instantiate(playerType,new Vector3(1,.75f,0),Quaternion.identity) as GameObject;
		player.layer = (int)Layer.PlayerCharacters;
		Layers.AddLayerObject(Layer.PlayerCharacters,player);
	}

	void createMonsters ()
	{
		GameObject monster = Instantiate(monsterType,new Vector3(7,.75f,7),Quaternion.identity)as GameObject;
		monster.layer = (int)Layer.Monsters;
		Layers.AddLayerObject(Layer.Monsters,monster);
	}
	
	// Update is called once per frame
	void Update () {
		select();

	}

	private void select(){
		if(Input.GetButtonDown("ChangeSelection")){
			Debug.Log ("tabbed");
			List<GameObject> players = Layers.GetLayerObjects(Layer.PlayerCharacters);
			if(!playerSelectionIndex.HasValue) {
				playerSelectionIndex = 0;
			}else if(playerSelectionIndex == players.Count - 1){
				//reset to unselected texture
				players[playerSelectionIndex.Value].GetComponent<PlayerController>().SetActiveSkin(Skin.Default);
				playerSelectionIndex = 0;

			}else{
				players[playerSelectionIndex.Value].GetComponent<PlayerController>().SetActiveSkin(Skin.Default);
				playerSelectionIndex++;
			}
			GameObject player = players[playerSelectionIndex.Value];
			Debug.Log("player #" + playerSelectionIndex.Value + " @" + player.transform.position.ToString());			
			PlayerController controller = player.GetComponent<PlayerController>();
			controller.SetActiveSkin(Skin.Selected);

		}
	}
}
