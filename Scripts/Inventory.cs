using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	private class ItemsData {
		public int id;
		public string type;
		public int cost;
		public string name;
		public string description;
		public Sprite image;
	}

	private ItemsData[] items;
	[SerializeField]
	private Sprite[] Costumes;
	[SerializeField]
	private Sprite[] Hats;

	public void GetItems() {
		string path = "Assets/Resources/Inventory.json";
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path); 
        Debug.Log(reader.ReadToEnd());
        reader.Close();
	}
	public void GetItemsByType(string type) {

	}
	public void buy(int id, string type) {

	}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
