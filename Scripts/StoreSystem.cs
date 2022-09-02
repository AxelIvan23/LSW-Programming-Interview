using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreSystem : MonoBehaviour
{

	[SerializeField]
	private GameObject Container;
	[SerializeField]
	private ItemsArray shopItems;
	[SerializeField]
	private Sprite[] Costumes;
	[SerializeField]
	private Sprite[] Hats;
	[SerializeField]
	private Image icon;
	[SerializeField]
	private GameObject itemPrefab;
	[SerializeField]
	private RectTransform iconSelect;
	private List<RectTransform> itemRects;
	private int count;

	public void GetItems() {
		itemRects = new List<RectTransform>();
		for (int i=0;i<shopItems.items.Length;i++) {
			var temp = Instantiate(itemPrefab);
			temp.transform.SetParent(Container.transform, false);
			temp.transform.GetChild(1).GetComponent<Text>().text = shopItems.items[i].name;
			temp.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "$" + shopItems.items[i].cost;
			if (shopItems.items[i].sold==true)
				temp.transform.GetChild(3).gameObject.SetActive(true);
			itemRects.Add(temp.GetComponent<RectTransform>());
			itemRects[i].anchoredPosition = new Vector2(0, -55*i);
		}
	}
    // Start is called before the first frame update
    void Start()
    {
        GetItems();
        count=0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && count<shopItems.items.Length-1) {
        	iconSelect.anchoredPosition = new Vector2(iconSelect.anchoredPosition.x,iconSelect.anchoredPosition.y-55);
        	count++;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && count>0) {
        	iconSelect.anchoredPosition = new Vector2(iconSelect.anchoredPosition.x,iconSelect.anchoredPosition.y+55);
        	count--;
        }
        if (Input.GetKeyDown(KeyCode.Space) ) {
        	Debug.Log("Hola");
        }
    }
}
