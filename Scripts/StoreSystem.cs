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
	[SerializeField]
	private Scrollbar scroll;
	[SerializeField]
	private RectTransform content;
	[SerializeField]
	private ItemsArray playerItems;

	private List<RectTransform> itemRects;
	private int count, count2;
	private float temp;
	private int money=23500;

	public void GetItems(string type) {
		itemRects = new List<RectTransform>();
		for (int i=0;i<shopItems.items.Count;i++) {
			var temp = Instantiate(itemPrefab);
			temp.transform.SetParent(Container.transform, false);
			temp.transform.GetChild(1).GetComponent<Text>().text = shopItems.items[i].name;
			temp.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "$" + shopItems.items[i].cost;
			if (shopItems.items[i].sold==true)
				temp.transform.GetChild(3).gameObject.SetActive(true);
			itemRects.Add(temp.GetComponent<RectTransform>());
			itemRects[i].anchoredPosition = new Vector2(0, -55*i);
			//Destroy(itemRects[i].gameObject);
		}
		content.sizeDelta = new Vector2(content.sizeDelta.x, 55*shopItems.items.Count);
		scroll.numberOfSteps=shopItems.items.Count-10;
	}

	public void DestroyItems() {

	}
    // Start is called before the first frame update
    void Start()
    {
        GetItems("Costume");
        count=0; count2=0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && count<shopItems.items.Count-1) {
        	count++;
        	Debug.Log(count);
        	if (count>10+count2) {
        		scroll.value = (1.0f/scroll.numberOfSteps)*(count-10.0f);
        		temp = scroll.value;
        		count2++;
        	} else 
        		iconSelect.anchoredPosition = new Vector2(iconSelect.anchoredPosition.x,iconSelect.anchoredPosition.y-55);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && count>0) {
        	count--;
        	Debug.Log(count);
        	if (count<count2) {
        		scroll.value = 1.0f - (temp*(count2-count));
        		count2--;
        		Debug.Log(1.0f-((1.0f/scroll.numberOfSteps)*(count2-count)));
        		Debug.Log(1.0f-((1.0f/scroll.numberOfSteps)*(count2-count)));
        	} else 
        		iconSelect.anchoredPosition = new Vector2(iconSelect.anchoredPosition.x,iconSelect.anchoredPosition.y+55);
        }
        if (Input.GetKeyDown(KeyCode.Space) ) {
        	if (shopItems.items[count].cost < money) {
        		playerItems.items.Add(shopItems.items[count]);
        	}
        }
    }
}
