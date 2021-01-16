using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OreControl : MonoBehaviour {

	// prepei h list na einai public allios einai telios inaccessible
	// kai static
	public static List<Ore> Ores = new List<Ore>();


	//reference sto prefab, gia na borw na kanw update ta texts pera tou instantiation/initiation
	public GameObject CopperOreRef;
	public GameObject TinOreRef;
	public GameObject IronOreRef;
	public GameObject LeadOreRef;

	public GameObject content;
	public GameObject OreUI;
	public int OreIndex = 0;
	

	//selected ore
	public GameObject HighLightedOre;
		


	public void Start(){
		//kanei assign ta base values TODO, make them variables
    	var Ore1 = new Ore("Copper",0,1,Resources.Load<Sprite>("Ores/1CopperOre"));
    	var Ore2 = new Ore("Tin",0,1.2f,Resources.Load<Sprite>("Ores/2TinOre"));
		var Ore3 = new Ore("Iron",0,2,Resources.Load<Sprite>("Ores/3IronOre"));
		var Ore4 = new Ore("Lead",0,4,Resources.Load<Sprite>("Ores/4LeadOre"));
		// ta bazei sti lista
		Ores.Add(Ore1);
		Ores.Add(Ore2);	
		Ores.Add(Ore3);
		Ores.Add(Ore4);
		//TextCopper.text =""+ Ores[0].OreAmount;   test gia arxikopoihsh, worked

		


 	foreach (var Ore in Ores) {
		 // en telei gameObject epitrepei gia na allakseis pragmata sto Paketo prefab apo eksw
		var copy = (GameObject)Instantiate(OreUI);

		copy.gameObject.name = Ores[OreIndex].OreName;
		//https://answers.unity.com/questions/1515530/changing-prefab-of-a-gameobject-at-runtime-c.html THANK THIS GUY
		// sets up the references
			if(copy.gameObject.name == "Copper"){
			CopperOreRef = copy;
			//gia xrwmata
			HighLightedOre = copy;
			copy.GetComponent<Image>().color = new Color32(248,62,62,110);

			}
			if(copy.gameObject.name == "Tin"){
			TinOreRef = copy;
			}
			if(copy.gameObject.name == "Iron"){
			IronOreRef = copy;
			}
			if(copy.gameObject.name == "Lead"){
			LeadOreRef = copy;	
			}
		// Sets Prefabs values
		copy.transform.SetParent(content.transform, false);
		copy.transform.localPosition = Vector3.zero;
		copy.GetComponentsInChildren<Image>()[1].sprite = (Ores[OreIndex].OreIcon);
		copy.GetComponentsInChildren<Text>()[0].text = (Ores[OreIndex].OreAmount).ToString();
		copy.GetComponentsInChildren<Text>()[1].text = (Ores[OreIndex].OreValue).ToString() + " $";
		//passes clicked prefabs index to sellscript
		int SellOreIndex = OreIndex;
		
		
		copy.GetComponent<Button>().onClick.AddListener(
			() =>
			{
					
			//GIA XRWMATA, PIO EINAI SELECTED
			if( HighLightedOre == copy.gameObject){
				// do nothing
				}
			else{
				
				HighLightedOre.GetComponent<Image>().color = new Color32(208,255,253,127);
				HighLightedOre =copy.gameObject;
				HighLightedOre.GetComponent<Image>().color = new Color32(248,62,62,110);
				
			}
			
			//SelectOre(SellOreIndex);
			
			SellScript.SellOreIndex = SellOreIndex;
			//Debug.Log( "Ore" + SellOreIndex);

			}
		);
		OreIndex++;
		}
		
	}

	/* public void SelectOre(int localindex){
		SellScript.SellOreIndex = localindex;
	}
	*/
	
	public void Update(){
		
		// Update ta texts me to current amount tou pinaka
		 CopperOreRef.GetComponentsInChildren<Text>()[0].text = (OreControl.Ores[0].OreAmount).ToString();
		 TinOreRef.GetComponentsInChildren<Text>()[0].text = (OreControl.Ores[1].OreAmount).ToString();
		 IronOreRef.GetComponentsInChildren<Text>()[0].text = (OreControl.Ores[2].OreAmount).ToString();
		 LeadOreRef.GetComponentsInChildren<Text>()[0].text = (OreControl.Ores[3].OreAmount).ToString();
				 
		}



	
	// on click na pernei xrwma ena button gia na deixnei pio einai selected
	//public void HighlightOre (GameObject OreToHighlight) {
		
			//	HighLightedOre = OreToHighlight;

		//if( HighLightedOre == OreToHighlight){
			// do nothing
		//}
		//else
		//{
		//	HighLightedOre.GetComponent<Image>().color	= Color.red;
		//	HighLightedOre = OreToHighlight;
		//	HighLightedOre.GetComponent<Image>().color	= Color.blue;
	//	}

//	}


}
