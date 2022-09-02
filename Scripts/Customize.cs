using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customize : MonoBehaviour
{
	[SerializeField]
	private ItemsArray Items;
	[SerializeField]
	private Text hairText;
	[SerializeField]
	private Text costumeText;
	[SerializeField]
	private Text hatText;
	[SerializeField]
	private Image hairImage;
	[SerializeField]
	private Image costumeImage;
	[SerializeField]
	private Image hatImage;
	[SerializeField]
    private Animator anim1;
    [SerializeField]
    private Animator anim2;
    [SerializeField]
	private GameObject Player;

	[SerializeField]
	private ChangeClothes ClothesSystem;

	private List<ItemsArray.ItemsData> costumes;
	private List<ItemsArray.ItemsData> hats;
	private List<ItemsArray.ItemsData> faces;
	private int[] position = new int[] {0,0,0};
    // Start is called before the first frame update
    void OnEnable()
    {
        countItems();
        Player.GetComponent<PlayerMov>().enabled = false;
    }

    void OnDisable()
    {
        Player.GetComponent<PlayerMov>().enabled = true;
    }

    public void countItems() {
    	costumes = new List<ItemsArray.ItemsData>();
		hats = new List<ItemsArray.ItemsData>();
		faces = new List<ItemsArray.ItemsData>();

    	for (int i=0;i<Items.items.Count;i++) {
    		Debug.Log(Items.items[i].name);
    		if (Items.items[i].type=="Costume")
    			costumes.Add(Items.items[i]);
    		if (Items.items[i].type=="Hat")
    			hats.Add(Items.items[i]);
    		if (Items.items[i].type=="Hair")
    			faces.Add(Items.items[i]);
        }
    }

    public void insertItems() {

    }

    public void selectItem(string flags) {
    	string[] split = flags.Split (',');
	    int direction = int.Parse(split[0]);
	    int type = int.Parse(split[1]);

	    int[] temp = new int[] {faces.Count,costumes.Count,hats.Count};
	    if (direction==0 && position[type]>0) {
	    	position[type]--;
	    }
	    if (direction==1 && position[type]<temp[type]-1) {
	    	position[type]++;
	    }

    	hairText.text = faces[position[0]].name;
		costumeText.text = costumes[position[1]].name;
		hatText.text = hats[position[2]].name;

		hairImage.sprite = faces[position[0]].image;
		costumeImage.sprite = costumes[position[1]].image;
		hatImage.sprite = hats[position[2]].image;
    }

    public void Save() {
        Debug.Log("face: "+position[0]+", costume: "+position[1]+", hat: "+position[2]);
    	ClothesSystem.CustomizeAnimation(position[0],position[1],position[2]);
    	exit();
    }

    public void exit() {
    	anim1.SetInteger("state",1);
        anim2.SetInteger("state",1);
    	StartCoroutine("animation");
    }

    public IEnumerator animation() {
        yield return new WaitForSeconds(1.4f);
        anim1.SetInteger("state",2);
        anim2.SetInteger("state",2);
        this.gameObject.SetActive(false);
    }

}
