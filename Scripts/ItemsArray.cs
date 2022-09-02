using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ItemsArray", order = 2)]
public class ItemsArray : ScriptableObject
{
	[System.Serializable]
	public struct ItemsData {
		public int id;
		public string type;
		public bool sold;
		public int cost;
		public string name;
		public string description;
		public Sprite image;
		public SpriteArray spriteArray;
	}
	[SerializeField]
    public ItemsData[] items;
    [SerializeField]
    public List<ItemsData> items2;
}

