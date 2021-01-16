using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarControl : MonoBehaviour {

	public static List<Bar> Bars = new List<Bar>();

	public GameObject CopperBarRef;
	public GameObject TinBarRef;
	public GameObject BronzeBarRef;
	public GameObject IronBarRef;
	public GameObject LeadBarRef;

	public GameObject content;
	public GameObject BarUI;
	public int BarIndex = 0;

	public GameObject HighlightedBar;

	public void Start(){

		var Bar1 = new Bar("Copper Bar",0,1500,Resources.Load<Sprite>("Bars/1CopperBar"));
    	var Bar2 = new Bar("Tin Bar",0,1800,Resources.Load<Sprite>("Bars/2TinBar"));
		var Bar3 = new Bar("Bronze Bar",0,2000,Resources.Load<Sprite>("Bars/3BronzeBar"));
		var Bar4 = new Bar("Iron Bar",0,3000,Resources.Load<Sprite>("Bars/4IronBar"));
		var Bar5 = new Bar("Lead Bar",0,6000,Resources.Load<Sprite>("Bars/5LeadBar"));
		
		Bars.Add(Bar1);
		Bars.Add(Bar2);	
		Bars.Add(Bar3);
		Bars.Add(Bar4);
		Bars.Add(Bar5);

		foreach (var Bar in Bars) {

			var copy = (GameObject)Instantiate(BarUI);

			copy.gameObject.name = Bars[BarIndex].BarName;

			if(copy.gameObject.name == "Copper Bar"){
			CopperBarRef = copy;
			// kanei highlight to default selected otan anoigeis prwth fora to menu
			HighlightedBar = copy;
			copy.GetComponent<Image>().color = new Color32(248,62,62,110);
			}
			if(copy.gameObject.name == "Tin Bar"){
			TinBarRef = copy;
			}
			if(copy.gameObject.name == "Bronze Bar"){
			BronzeBarRef = copy;
			}
			if(copy.gameObject.name == "Iron Bar"){
			IronBarRef = copy;
			}
			if(copy.gameObject.name == "Lead Bar"){
			LeadBarRef = copy;
			}

			copy.transform.SetParent(content.transform, false);
			copy.transform.localPosition = Vector3.zero;
			copy.GetComponentsInChildren<Image>()[1].sprite = (Bars[BarIndex].BarIcon);
			copy.GetComponentsInChildren<Text>()[0].text = (Bars[BarIndex].BarAmount).ToString();
			copy.GetComponentsInChildren<Text>()[1].text = (Bars[BarIndex].BarValue).ToString() + " $";


			int SellBarIndex = BarIndex;
			copy.GetComponent<Button>().onClick.AddListener(
			() =>
				{
					//selected bar
					if(HighlightedBar == copy.gameObject){
						//do nothing
					}
					else
					{
						HighlightedBar.GetComponent<Image>().color = new Color32(208,255,253,127);
						HighlightedBar = copy.gameObject;
						HighlightedBar.GetComponent<Image>().color = new Color32(248,62,62,110);
					}
				// can do anything with the current index
				SellScript.SellBarIndex = SellBarIndex;
				//Debug.Log("Bar" + SellBarIndex);
				}
			);
			BarIndex++;
		}

	}

	public void Update(){
		// Update ta texts me to current amount tou pinaka
		 CopperBarRef.GetComponentsInChildren<Text>()[0].text = (BarControl.Bars[0].BarAmount).ToString();
		 TinBarRef.GetComponentsInChildren<Text>()[0].text = (BarControl.Bars[1].BarAmount).ToString();
		 BronzeBarRef.GetComponentsInChildren<Text>()[0].text = (BarControl.Bars[2].BarAmount).ToString();
		 IronBarRef.GetComponentsInChildren<Text>()[0].text = (BarControl.Bars[3].BarAmount).ToString();
		 LeadBarRef.GetComponentsInChildren<Text>()[0].text = (BarControl.Bars[4].BarAmount).ToString();

		}
}
