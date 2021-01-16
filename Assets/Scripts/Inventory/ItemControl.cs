using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemControl : MonoBehaviour {

	public static List<Item> Items = new List<Item>();

	public GameObject CopperItemRef;
	public GameObject TinItemRef;
	public GameObject BronzeItemRef;
	public GameObject IronItemRef;
	public GameObject LeadItemRef;

	public GameObject content;
	public GameObject ItemUI;
	public int ItemIndex = 0;

	public GameObject HighlightedItem;

	public void Start(){

		var Item1 = new Item("1 Item",10,10000,Resources.Load<Sprite>("Items/1Item"));
    	var Item2 = new Item("2 Item",15,20000,Resources.Load<Sprite>("Items/2Item"));
		var Item3 = new Item("3 Item",23,30000,Resources.Load<Sprite>("Items/3Item"));
		var Item4 = new Item("4 Item",9,40000,Resources.Load<Sprite>("Items/4Item"));
		var Item5 = new Item("5 Item",12,60000,Resources.Load<Sprite>("Items/5Item"));
		
		Items.Add(Item1);
		Items.Add(Item2);	
		Items.Add(Item3);
		Items.Add(Item4);
		Items.Add(Item5);

		foreach (var Item in Items) {

			var copy = (GameObject)Instantiate(ItemUI);

			copy.gameObject.name = Items[ItemIndex].ItemName;

			if(copy.gameObject.name == "1 Item"){
			CopperItemRef = copy;
			// kanei highlight to default selected otan anoigeis prwth fora to menu
			HighlightedItem = copy;
			copy.GetComponent<Image>().color = new Color32(248,62,62,110);
			}
			if(copy.gameObject.name == "2 Item"){
			TinItemRef = copy;
			}
			if(copy.gameObject.name == "3 Item"){
			BronzeItemRef = copy;
			}
			if(copy.gameObject.name == "4 Item"){
			IronItemRef = copy;
			}
			if(copy.gameObject.name == "5 Item"){
			LeadItemRef = copy;
			}

			copy.transform.SetParent(content.transform, false);
			copy.transform.localPosition = Vector3.zero;
			copy.GetComponentsInChildren<Image>()[1].sprite = (Items[ItemIndex].ItemIcon);
			copy.GetComponentsInChildren<Text>()[0].text = (Items[ItemIndex].ItemAmount).ToString();
			copy.GetComponentsInChildren<Text>()[1].text = (Items[ItemIndex].ItemValue).ToString() + " $";


			int SellItemIndex = ItemIndex;
			copy.GetComponent<Button>().onClick.AddListener(
			() =>
				{
					//selected Item
					if(HighlightedItem == copy.gameObject){
						//do nothing
					}
					else
					{
						HighlightedItem.GetComponent<Image>().color = new Color32(208,255,253,127);
						HighlightedItem = copy.gameObject;
						HighlightedItem.GetComponent<Image>().color = new Color32(248,62,62,110);
					}
				// can do anything with the current index
				SellScript.SellItemIndex = SellItemIndex;
				//Debug.Log("Item" + SellItemIndex);
				}
			);
			ItemIndex++;
		}

	}

	public void Update(){
		// Update ta texts me to current amount tou pinaka
		 CopperItemRef.GetComponentsInChildren<Text>()[0].text = (ItemControl.Items[0].ItemAmount).ToString();
		 TinItemRef.GetComponentsInChildren<Text>()[0].text = (ItemControl.Items[1].ItemAmount).ToString();
		 BronzeItemRef.GetComponentsInChildren<Text>()[0].text = (ItemControl.Items[2].ItemAmount).ToString();
		 IronItemRef.GetComponentsInChildren<Text>()[0].text = (ItemControl.Items[3].ItemAmount).ToString();
		 LeadItemRef.GetComponentsInChildren<Text>()[0].text = (ItemControl.Items[4].ItemAmount).ToString();

		}
}
