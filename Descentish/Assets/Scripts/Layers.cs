using UnityEngine;
using System.Collections.Generic;

public static class Layers {

	private static Dictionary<Layer,List<GameObject>> layers;

	public static List<GameObject> GetLayerObjects(Layer searchLayer){
		if(layers==null) throw new UnityException("layers have not been populated");
		List<GameObject> gameObjects = layers[searchLayer];
		return gameObjects;
	}

	public static void AddLayerObject(Layer layer, GameObject gameObject){
		if(layers == null) layers = new Dictionary<Layer,List<GameObject>>();
		List<GameObject> gameObjects;
		try{
			gameObjects = layers[layer];
		}catch(KeyNotFoundException){
			Debug.Log("Layer " + layer.ToString() + " not found.  Adding...");
			createLayer(layer);
			Debug.Log("LayerCount = " + layers.Count);
			gameObjects = layers[layer];
		}		
		gameObjects.Add(gameObject);
	}

	private static void createLayer(Layer layer){
		layers.Add(layer,new List<GameObject>());
	}

}
