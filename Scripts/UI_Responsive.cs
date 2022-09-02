using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Responsive : MonoBehaviour
{
	public RectTransform MoneyPanel;
	public Text MoneyText;
	public RectTransform MoneyImage;

	public RectTransform ChatPanel;
	public GameObject ChatText;
	public RectTransform ChatImage;
	public RectTransform ChatDecisions;
	public Text[] ChatDecisionsText;

	public RectTransform ItemPanel;
	public RectTransform ItemImage;
	public RectTransform ItemDescription;
	public RectTransform ItemContainer;

	public RectTransform TopItems;
	public RectTransform BottomItems;
	public RectTransform[] OptionsItems;
    // Start is called before the first frame update
    void Start()
    {
    	//MONEY PANEL
        MoneyPanel.sizeDelta = new Vector2(MoneyPanel.sizeDelta.x,Screen.height / 12.781f);
        MoneyImage.sizeDelta = new Vector2(MoneyPanel.sizeDelta.y,MoneyImage.sizeDelta.y);
        MoneyText.fontSize = (int)(MoneyPanel.sizeDelta.y / 1.4629);
        MoneyText.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(Screen.width/19,0);
    	//CHAT PANEL
    	ChatPanel.sizeDelta = new Vector2(ChatPanel.sizeDelta.x,Screen.height / 3.731859f);
    	ChatImage.sizeDelta = new Vector2(Screen.height/5.1428f,Screen.height/5.1428f);
    	ChatImage.anchoredPosition = new Vector2(Screen.width/28.23529f,Screen.height/108.0f);
    	ChatText.GetComponent<RectTransform>().offsetMin = new Vector2(Screen.width/6.41282f,Screen.height/8.30769f);
    	ChatText.GetComponent<RectTransform>().offsetMax = new Vector2(ChatText.GetComponent<RectTransform>().offsetMax.x,-Screen.height/28.421f);
    	ChatText.GetComponent<Text>().fontSize = (int)(Screen.height/30);
    	ChatDecisions.offsetMin = new Vector2(Screen.width/6.41282f,Screen.height/54);
    	ChatDecisions.offsetMax = new Vector2(-Screen.width/38.4f,-Screen.height/6.98983f);
    	for (int i = 0; i<3; i++) {
    		ChatDecisionsText[i].fontSize = (int)(Screen.height/27.6923);
    	}
    	//ITEM PANEL
    	ItemPanel.offsetMin = new Vector2(ItemPanel.offsetMin.x,Screen.height / 4.036779f);
    	ItemImage.sizeDelta = new Vector2(Screen.width/2.15875f, 0);
    	ItemContainer.sizeDelta = new Vector2(Screen.width/1.87518f, 0);
    	ItemDescription.sizeDelta = new Vector2(0,Screen.height/4.11742f);
    	TopItems.sizeDelta = new Vector2(0,Screen.height/8.66773f);
    	BottomItems.offsetMax = new Vector2(0,-Screen.height/8.31408f);

    	for (int i = 0; i<3; i++) {
    		OptionsItems[i].sizeDelta = new Vector2(Screen.width/6.73684f, Screen.height/14.342629f);
    	}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
