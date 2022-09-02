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
	private GameObject icon;
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
	[SerializeField]
	private Text moneyText;

	private List<RectTransform> itemRects;
	private int count, count2;
	private float temp;
	private int money=23500;

	public void GetItems() {
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
		//scroll.numberOfSteps=shopItems.items.Count-11;
	}

	public void DestroyItems() {
		for (int i=0;i<shopItems.items.Count;i++) {
			Destroy(itemRects[i].gameObject);
		}
	}
    // Start is called before the first frame update
    void Start()
    {
        GetItems();
        count=0; count2=0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && count<shopItems.items.Count-1) {
        	count++;
        	//Debug.Log("Count"+count);
        	if (count>10+count2) {
        		scroll.value = 1.0f-((1.0f/(shopItems.items.Count-11))*(count-10.0f));
        		Debug.Log(scroll.value);
        		temp = scroll.value;
        		count2++;
        	} else 
        		iconSelect.anchoredPosition = new Vector2(iconSelect.anchoredPosition.x,iconSelect.anchoredPosition.y-55);
        	icon.GetComponent<Image>().sprite = shopItems.items[count].image;
        	if (shopItems.items[count].type=="Costume") {
        		icon.GetComponent<RectTransform>().sizeDelta = new Vector2(100.0f,140.0f);
        	}
        	if (shopItems.items[count].type=="Hat") {
        		icon.GetComponent<RectTransform>().sizeDelta = new Vector2(90.0f,90.0f);
        	}
        	if (shopItems.items[count].type=="Hair") {
        		icon.GetComponent<RectTransform>().sizeDelta = new Vector2(90.0f,130.0f);
        	}
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && count>0) {
        	count--;
        	if (count<count2) {
        		scroll.value = ((1.0f/(shopItems.items.Count-11))*(10.0f-count)) - 1.5f;
        		Debug.Log(scroll.value);
        		count2--;
        	} else 
        		iconSelect.anchoredPosition = new Vector2(iconSelect.anchoredPosition.x,iconSelect.anchoredPosition.y+55);
        	icon.GetComponent<Image>().sprite = shopItems.items[count].image;
        }
        if (Input.GetKeyDown(KeyCode.Space) ) {
        	if (shopItems.items[count].cost < money && !shopItems.items[count].sold) {
        		ItemsArray.ItemsData temp = new ItemsArray.ItemsData();
        		temp = shopItems.items[count];
        		temp.sold=true;
        		shopItems.items[count] = temp;
        		temp.cost = shopItems.items[count].cost - 600;
        		playerItems.items.Add(shopItems.items[count]);
        		money=money - shopItems.items[count].cost;
        		moneyText.text=money+"";
        		DestroyItems();
        		GetItems();
        	}
        }
    }
}
