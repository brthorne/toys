using UnityEngine;
using System.Collections.Generic;

public class BoardController : MonoBehaviour {

	public GameObject tileGrass;
	public GameObject tileWall;
	public GameObject playerType;
	public GameObject monsterType;
	public Material tileHighlight;
	public Material tileDefault;


	public int width=800;
	public int depth=800;
	public const float BOARD_HEIGHT = 0;


	int? playerSelectionIndex;
	GameObject player;
	PlayerController playerController;

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
		int? oldPlayerSelectionIndex = playerSelectionIndex;
		select();
		if(playerSelectionIndex.HasValue && !oldPlayerSelectionIndex.HasValue ||
		   playerSelectionIndex.HasValue && oldPlayerSelectionIndex.HasValue &&
		   playerSelectionIndex != oldPlayerSelectionIndex){//we just selected something.  not good enough.  
			//need to also change on player moving and depleting distance movable this turn
			//color the movable area
			colorMovableTiles(player.transform.position,playerController.speed);
		}

	}

	private void colorMovableTiles(Vector3 playerPosition, int distance){
		List<GameObject> tiles = Layers.GetLayerObjects(Layer.BaseTerrain);
		foreach(GameObject tile in tiles){
			if(Vector3.Distance(tile.transform.position,playerPosition) < 2 * distance){
				tile.renderer.material = tileHighlight;
			}
			else{ tile.renderer.material = tileDefault;}
		}
	}

	private void select(){
		if(Input.GetButtonDown("ChangeSelection")){
			Debug.Log ("tabbed");
			List<GameObject> players = Layers.GetLayerObjects(Layer.PlayerCharacters);
			if(!playerSelectionIndex.HasValue) {
				playerSelectionIndex = 0;
			}else if(playerSelectionIndex == players.Count - 1){
				//reset to unselected texture
				playerSelectionIndex = 0;
				playerController.SetActiveSkin(Skin.Default);
			}else{
				playerSelectionIndex++;
				playerController.SetActiveSkin(Skin.Default);
			}
			player = players[playerSelectionIndex.Value];
			Debug.Log("player #" + playerSelectionIndex.Value + " @" + player.transform.position.ToString());			
			playerController = player.GetComponent<PlayerController>();
			playerController.SetActiveSkin(Skin.Selected);

		}
	}

	private void endTurn(){
		playerSelectionIndex = null;
		player = null;
		playerController = null;
	}
}
