using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeClothes : MonoBehaviour
{
	private List<ItemsArray.ItemsData> Heads;
	private List<ItemsArray.ItemsData> Bodys;
	private List<ItemsArray.ItemsData> Hats;
	[SerializeField]
	private SpriteArray Principal;
	[SerializeField]
	private Sprite Preview;
    [SerializeField]
    private ItemsArray Items;
	private int[] PosxArray; 
	private int posx, posy;
    // Start is called before the first frame update
    void OnEnable()
    {
        countItems();
    }

    public void countItems() {
        Bodys = new List<ItemsArray.ItemsData>();
        Heads = new List<ItemsArray.ItemsData>();
        Hats = new List<ItemsArray.ItemsData>();

        for (int i=0;i<Items.items.Count;i++) {
            Debug.Log(Items.items[i].name);
            if (Items.items[i].type=="Costume")
                Bodys.Add(Items.items[i]);
            if (Items.items[i].type=="Hat")
                Hats.Add(Items.items[i]);
            if (Items.items[i].type=="Hair")
                Heads.Add(Items.items[i]);
        }
    }

    /*public void Customize(int HeadNum, int BodyNum, int HatNum) {
    	Resources.UnloadUnusedAssets();
    	recorrer(BodyNum,0);
    	int tempy, tempx;
		for (int x = 0; x < Bodys[BodyNum].spriteArray[0].rect.width; x++) {
    		for (int y = 0; y < Bodys[BodyNum].spriteArray[0].rect.height; y++) {
    			tempx = (int)(45+(Heads[HeadNum].spriteArray[0].rect.width/2)-posx);
    			tempy = (int)(Principal.spriteArray[0].texture.height - (2*Bodys[BodyNum].spriteArray[0].rect.height)+posy-10) - (38);
    			var color = Bodys[BodyNum].spriteArray[0].texture.GetPixel((int)Bodys[BodyNum].spriteArray[0].rect.x+x,(int)Bodys[BodyNum].spriteArray[0].rect.y +y);
    			Preview.texture.SetPixel(tempx+x, tempy+y, color);
    		}
    	}
    	//HEAD
    	//Debug.Log((int)Heads[HeadNum].spriteArray[0].rect.x);
    	for (int x = 0; x < Heads[HeadNum].spriteArray[0].rect.width; x++) {
    		for (int y = 0; y < Heads[HeadNum].spriteArray[0].rect.height; y++) {
    			var color = Heads[HeadNum].spriteArray[0].texture.GetPixel((int)Heads[HeadNum].spriteArray[0].rect.x+x,(int)Heads[HeadNum].spriteArray[0].rect.y+y);
    			if (color.a != 0) {
	    			posy=(int)(Preview.texture.height - Heads[HeadNum].spriteArray[0].rect.height) - (35);
	    			Preview.texture.SetPixel(45+x,posy+y, color);
	    		}
    		}
    	}
    	Preview.texture.Apply();
    }*/

    public void CustomizeAnimation(int HeadNum, int BodyNum, int HatNum) {
        Debug.Log("IDNWIUNDWIUWD");
    	Resources.UnloadUnusedAssets();
    	Clean();
    	int cont=0;
    	int tempy, tempx;
    	for (int row = 0; row < 8; row++) {
    		for (int col = 0; col < 5; col++) {
                //COSTUMES
    			recorrer(BodyNum,cont);
    			for (int x = 0; x < Bodys[BodyNum].spriteArray.spriteArray[cont].rect.width; x++) {
		    		for (int y = 0; y < Bodys[BodyNum].spriteArray.spriteArray[cont].rect.height; y++) {
		    			tempx = (int)(45+(124*row)+(Heads[HeadNum].spriteArray.spriteArray[col].rect.width/2)-posx);
		    			tempy = (int)(Principal.spriteArray[0].texture.height - (2*Bodys[BodyNum].spriteArray.spriteArray[cont].rect.height)+posy-10) - (38 + (143*col));
		    			var color = Bodys[BodyNum].spriteArray.spriteArray[cont].texture.GetPixel((int)Bodys[BodyNum].spriteArray.spriteArray[cont].rect.x+x,(int)Bodys[BodyNum].spriteArray.spriteArray[cont].rect.y +y);
		    			Principal.spriteArray[0].texture.SetPixel(tempx+x, tempy+y, color);
		    		}
		    	}
		    	//HEAD
		    	//Debug.Log((int)Heads[HeadNum].spriteArray[0].rect.x);
		    	for (int x = 0; x < Heads[HeadNum].spriteArray.spriteArray[col].rect.width; x++) {
		    		for (int y = 0; y < Heads[HeadNum].spriteArray.spriteArray[col].rect.height; y++) {
		    			var color = Heads[HeadNum].spriteArray.spriteArray[col].texture.GetPixel((int)Heads[HeadNum].spriteArray.spriteArray[col].rect.x+x,(int)Heads[HeadNum].spriteArray.spriteArray[col].rect.y+y);
		    			if (color.a != 0) {
			    			posy=(int)(Principal.spriteArray[0].texture.height - Heads[HeadNum].spriteArray.spriteArray[col].rect.height) - (35 + (143*col));
			    			Principal.spriteArray[0].texture.SetPixel(45+(124*row)+x,posy+y, color);
			    		}
		    		}
		    	}
                //HATS
                for (int x = 0; x < Hats[HatNum].spriteArray.spriteArray[col].rect.width; x++) {
                    for (int y = 0; y < Hats[HatNum].spriteArray.spriteArray[col].rect.height; y++) {
                        var color = Hats[HatNum].spriteArray.spriteArray[col].texture.GetPixel((int)Hats[HatNum].spriteArray.spriteArray[col].rect.x+x,(int)Hats[HatNum].spriteArray.spriteArray[col].rect.y+y);
                        if (color.a != 0) {
                            posy=(int)(Principal.spriteArray[0].texture.height - Hats[HatNum].spriteArray.spriteArray[col].rect.height) - (25 + (143*col));
                            Principal.spriteArray[0].texture.SetPixel(43+(124*row)+x,posy+y, color);
                        }
                    }
                }
		    	cont = cont + 1;
		    	Principal.spriteArray[0].texture.Apply();
    		}
    	}
    	//BODY
		
    }
    public void recorrer(int BodyNum, int num) {
    	for (int x = 0; x < Bodys[BodyNum].spriteArray.spriteArray[num].rect.width; x++) {
    		for (int y = 0; y < Bodys[BodyNum].spriteArray.spriteArray[num].rect.height; y++) {
    			var color = Bodys[BodyNum].spriteArray.spriteArray[num].texture.GetPixel((int)Bodys[BodyNum].spriteArray.spriteArray[num].rect.x+x,(int)Bodys[BodyNum].spriteArray.spriteArray[num].rect.y + y);
    			if (color.r > 0.1176 && color.r < 0.1177 && color.g == 1 && color.b==0) {
    				posx=x;
    				posy=y;
    				Debug.Log("cont: " + num + " / posx: " + posx);
    				return;
    			}
    		}
    	}
    	posx=2000;
    	posy=2000;
    }
    public void Clean() {
    	for (int x = 0; x < Principal.spriteArray[0].texture.width; x++) {
    		for (int y = 0; y < Principal.spriteArray[0].texture.height; y++) {
    			Principal.spriteArray[0].texture.SetPixel(x,y, Color.clear);
    		}
    	}
    }
}
