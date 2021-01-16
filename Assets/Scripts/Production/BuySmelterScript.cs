using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuySmelterScript : MonoBehaviour {
	//actual smelter shit
public static List<Smelter> Smelters = new List<Smelter>();
public GameObject SmelterContent;
public GameObject SmelterUI;
public Text SmelterCostText;
public List<GameObject> RefSmelterList;
public Button ProductionPanelBtn;
public float NewSmelterCost = 5000;
	
	//research related
	public Button UnlockProductionResearch;
	//SmelterRecipePanel
	public GameObject SmelterRecipePanel;
	//recipe index
	public static int TestIndex1;

	//unlocks production panel and adds 1st Smelter
	public void BuySmelterResearch(){
		if(CurrencyControl.Cash >= 1000){
			CurrencyControl.Cash -= 1000;	
			ProductionPanelBtn.interactable = true;
			UnlockProductionResearch.interactable = false;

				//int SmelterIndex,int Duration,float CurrentTime,Sprite OutputIcon,bool IsSmelting,int CurrentRecipe
				var Smelter = new Smelter (1,0,0,Resources.Load<Sprite>("Bars/1CopperBar"),false,-1);
				Smelters.Add(Smelter);
				var smelterIndex = Smelters.Count;
			
			var copy = Instantiate(SmelterUI);
				copy.transform.SetParent(SmelterContent.transform, false);
				copy.transform.localPosition = Vector3.zero;	
				copy.name =("Smelter"+smelterIndex);

				//plin 1 giati ksekinaei apo to 0 kai oxi apo to 1 o pinakas
				copy.GetComponentInChildren<Button>().onClick.AddListener( () =>{
					//opens recipe panel
					StartCoroutine(WaitForSelection(smelterIndex-1));
					});
				//CANCEL BUTTON
				//Stops production 
				copy.GetComponentsInChildren<Button>()[1].onClick.AddListener( () =>{
					StopSmelter((smelterIndex-1));
				});
		RefSmelterList.Add(copy);
		
		}

	}
	//Buys additional Smelters
	public void BuySmelter(){
	if(CurrencyControl.Cash >= NewSmelterCost){
		CurrencyControl.Cash -= NewSmelterCost;
		//TODO BETTER FORMULA
		NewSmelterCost = NewSmelterCost * 5 ; 
		SmelterCostText.text = NewSmelterCost.ToString();
			//int SmelterIndex,int Duration,float CurrentTime,Sprite OutputIcon,bool IsSmelting,int CurrentRecipe
			var Smelter = new Smelter (1,0,0,Resources.Load<Sprite>("Bars/1CopperBar"),false,-1);
			Smelters.Add(Smelter);
			var smelterIndex = Smelters.Count;
		//instantiate another smelter
		var copy = Instantiate(SmelterUI);
			copy.transform.SetParent(SmelterContent.transform, false);
			copy.transform.localPosition = Vector3.zero;
			copy.name =("Smelter"+smelterIndex);
		//to index tou kathe smelter, de xreiazete -1 giati ton prwto tha ton valw na ginete instantiate apo research
			
		copy.GetComponentsInChildren<Button>()[0].onClick.AddListener( () =>{
			//opens recipe panel
			StartCoroutine(WaitForSelection(smelterIndex-1));
			});
		//CANCEL BUTTON
		//Stops production 
		copy.GetComponentsInChildren<Button>()[1].onClick.AddListener( () =>{
			StopSmelter(smelterIndex-1);
		});
		RefSmelterList.Add(copy);
		}
	}
	

private IEnumerator WaitForSelection(int anotherindex){
	SmelterRecipePanel.SetActive(true);
	//kanei wait mexri na kleisei to panel hoho haha
	while(SmelterRecipePanel.activeSelf == true){
		yield return new WaitForSeconds(0);
	}

	RefSmelterList[anotherindex].GetComponentsInChildren<Image>()[1].sprite = SRControl.SRecipes[TestIndex1].OutputIcon;

	
		if(Smelters[anotherindex].CurrentRecipe != TestIndex1){
			//otan kanei click ena recipe, ginete update o TestIndex1
			//resets values on the smelter
				
				Smelters[anotherindex].Duration = SRControl.SRecipes[TestIndex1].Duration;
				
				Smelters[anotherindex].CurrentTime = 0;
				RefSmelterList[anotherindex].GetComponentInChildren<Slider>().value = 0;
				
				//kathe fora pou clickarw otan den exw mats ksekinaei ena coroutine pou perimenei na exw mats
				if(Smelters[anotherindex].IsSmelting == true){
				OreControl.Ores[SRControl.SRecipes[Smelters[anotherindex].CurrentRecipe].resIdx1].OreAmount += SRControl.SRecipes[Smelters[anotherindex].CurrentRecipe].resAmount1; 
				OreControl.Ores[SRControl.SRecipes[Smelters[anotherindex].CurrentRecipe].resIdx2].OreAmount += SRControl.SRecipes[Smelters[anotherindex].CurrentRecipe].resAmount2;
				OreControl.Ores[SRControl.SRecipes[Smelters[anotherindex].CurrentRecipe].resIdx3].OreAmount += SRControl.SRecipes[Smelters[anotherindex].CurrentRecipe].resAmount3;
				
				}
				Debug.Log("Recipe Changed");
				Smelters[anotherindex].IsSmelting = false;
				Smelters[anotherindex].CurrentRecipe = TestIndex1;
				
				
				
				
				
				StartCoroutine(WaitForMaterials(anotherindex));
		}	
		else {
			//do nothing
			Debug.Log("same recipe selected");	
			//if(Smelters[anotherindex].IsSmelting == false && Smelters[anotherindex].CurrentRecipe == TestIndex1){
		}
	/* 	else{
			//change recipe
			Debug.Log("Recipe Changed");
			//Returns Materials before changing recipe
			if(Smelters[anotherindex].IsSmelting == true){
				OreControl.Ores[SRControl.SRecipes[Smelters[anotherindex].CurrentRecipe].resIdx1].OreAmount += SRControl.SRecipes[Smelters[anotherindex].CurrentRecipe].resAmount1; 
				OreControl.Ores[SRControl.SRecipes[Smelters[anotherindex].CurrentRecipe].resIdx2].OreAmount += SRControl.SRecipes[Smelters[anotherindex].CurrentRecipe].resAmount2;
				OreControl.Ores[SRControl.SRecipes[Smelters[anotherindex].CurrentRecipe].resIdx3].OreAmount += SRControl.SRecipes[Smelters[anotherindex].CurrentRecipe].resAmount3;
			}
			//resets values on the smelter
			Smelters[anotherindex].IsSmelting = false;
			Smelters[anotherindex].CurrentTime = 0;
			Smelters[anotherindex].CurrentRecipe = TestIndex1;
			Smelters[anotherindex].Duration = SRControl.SRecipes[TestIndex1].Duration;
			RefSmelterList[anotherindex].GetComponentInChildren<Slider>().value = 0;
			//RefSmelterList[anotherindex].GetComponentsInChildren<Text>()[1].text = "INACTIVE";
			
			
		//	StartCoroutine(WaitForMaterials(anotherindex));  */
		
		//}
}
	


	
	
	int idx;
public void Update(){
	idx = 0;
	foreach (var Smelter in Smelters){
		if(Smelters[idx].IsSmelting == true ){
			//start
				//auto de xreiazete mesa sto update, kalutera ekso optimization
			RefSmelterList[idx].GetComponentInChildren<Slider>().maxValue = Smelters[idx].Duration;
			//update
			Smelters[idx].CurrentTime += Time.deltaTime;
			RefSmelterList[idx].GetComponentInChildren<Slider>().value = Smelters[idx].CurrentTime;
				//timer text
				if((Smelters[idx].Duration - Smelters[idx].CurrentTime) >= 60){
					int min = Mathf.RoundToInt((Smelters[idx].Duration - Smelters[idx].CurrentTime)) / 60;
					int sec = Mathf.RoundToInt((Smelters[idx].Duration - Smelters[idx].CurrentTime)) % 60;
					RefSmelterList[idx].GetComponentsInChildren<Text>()[1].text = min.ToString("0m") +  sec.ToString("00s");
				}
				else
				{
					int sec = Mathf.RoundToInt((Smelters[idx].Duration - Smelters[idx].CurrentTime)) % 60;
					RefSmelterList[idx].GetComponentsInChildren<Text>()[1].text = sec.ToString("00s");
				}
			//reset/restart process
			if (Smelters[idx].Duration <= Smelters[idx].CurrentTime ){
				OnProgressComplete(idx);
			}
		}
		idx++;
		
	}
}

public void OnProgressComplete(int idx){
	//add bar/item
	BarControl.Bars[Smelters[idx].CurrentRecipe].BarAmount +=1;
	//resets smelter
	Smelters[idx].CurrentTime = 0;
	Smelters[idx].IsSmelting = false;
	RefSmelterList[idx].GetComponentInChildren<Slider>().value = Smelters[idx].CurrentTime;
		//var superindex = idx;
		StartCoroutine(WaitForMaterials(idx));
}


private IEnumerator WaitForMaterials(int superindex){
	//repaints duration text
	RefSmelterList[superindex].GetComponentsInChildren<Text>()[1].text = "STANDBY";
	var txt = RefSmelterList[superindex].GetComponentsInChildren<Text>()[1];
	txt.color = Color.yellow;
	
	
			//index gia na kseroume an allakse h recipe sto trexon smelter kai na kleinei thn sunarthsh
			var tempindex = Smelters[superindex].CurrentRecipe;
			//perimenei mexri na uparxoun ta apetoumena resources gia to kathe recipe OR na allaksei to recipe sto trexon smelter gia na kleinei thn sunarthsh
		yield return new WaitUntil(() =>
		tempindex != Smelters[superindex].CurrentRecipe || (OreControl.Ores[SRControl.SRecipes[Smelters[superindex].CurrentRecipe].resIdx1].OreAmount>= SRControl.SRecipes[Smelters[superindex].CurrentRecipe].resAmount1 &&
		OreControl.Ores[SRControl.SRecipes[Smelters[superindex].CurrentRecipe].resIdx2].OreAmount >= SRControl.SRecipes[Smelters[superindex].CurrentRecipe].resAmount2 &&
		OreControl.Ores[SRControl.SRecipes[Smelters[superindex].CurrentRecipe].resIdx3].OreAmount >= SRControl.SRecipes[Smelters[superindex].CurrentRecipe].resAmount3));

		if(tempindex != Smelters[superindex].CurrentRecipe){
			yield break;
		}
		
		//starts production
		Smelters[superindex].IsSmelting = true;
		//removes resources
		OreControl.Ores[SRControl.SRecipes[Smelters[superindex].CurrentRecipe].resIdx1].OreAmount -= SRControl.SRecipes[Smelters[superindex].CurrentRecipe].resAmount1;
		OreControl.Ores[SRControl.SRecipes[Smelters[superindex].CurrentRecipe].resIdx2].OreAmount -= SRControl.SRecipes[Smelters[superindex].CurrentRecipe].resAmount2;
		OreControl.Ores[SRControl.SRecipes[Smelters[superindex].CurrentRecipe].resIdx3].OreAmount -= SRControl.SRecipes[Smelters[superindex].CurrentRecipe].resAmount3;
		//repaints duration text
		txt = RefSmelterList[superindex].GetComponentsInChildren<Text>()[1];
		txt.color = Color.white;			
		//isws na valw ena if, gia smelterstatus & smelterCurrent recipe, gia pithana melontika error otan allazei recipe
		}
		

	


public void StopSmelter(int specialindex){
	RefSmelterList[specialindex].GetComponentsInChildren<Image>()[1].sprite = Resources.Load<Sprite>("Empty");
	RefSmelterList[specialindex].GetComponentsInChildren<Text>()[1].text = "INACTIVE";
	//repaints duration text
	var txt = RefSmelterList[specialindex].GetComponentsInChildren<Text>()[1];
	txt.color = Color.red;
	
	//returns resources
	if(Smelters[specialindex].IsSmelting == true){
		OreControl.Ores[SRControl.SRecipes[Smelters[specialindex].CurrentRecipe].resIdx1].OreAmount += SRControl.SRecipes[Smelters[specialindex].CurrentRecipe].resAmount1;
		OreControl.Ores[SRControl.SRecipes[Smelters[specialindex].CurrentRecipe].resIdx2].OreAmount += SRControl.SRecipes[Smelters[specialindex].CurrentRecipe].resAmount2;
		OreControl.Ores[SRControl.SRecipes[Smelters[specialindex].CurrentRecipe].resIdx3].OreAmount += SRControl.SRecipes[Smelters[specialindex].CurrentRecipe].resAmount3;	
		Smelters[specialindex].IsSmelting = false;
		//to efera edw anti gia mesa sto update
		RefSmelterList[specialindex].GetComponentInChildren<Slider>().value = 0;
		Smelters[specialindex].CurrentTime = 0;
				
		}
		Smelters[specialindex].CurrentRecipe = -1;

}

}





//MAYBE TODO
// na valw ena neo recipe prwto prwto pou tha einai 'keno'

//IDIOTROPIES
//Otan ginete instantiate to smelter apo research/buy, tou bazw index -1 sto current recipe to OPIO EINAI EKTOS RANGE tou pinaka suntagwn (min value 0)
//otan pataw to cancel, bazei pali to current recipe sto -1
//auto egine gia na apofugw to provlima pou parousiazotan otan patousa polles fores to idio recipe sto idio smelter, otan den eixa materials gia na ksekinisei
// kai eixe ws apotelesma na dhmiourgei ena coroutine se kathe click pou perimene na uparxoun ta materials(waituntil) gia na ksekinisei, auto eixe ws apotelesma apla na xanontai ta materials
//ti stigmh pou upirxan diathesima, kai na teliwne to process ekei, afou to smelter.ismelting htan idi true apo to prwto coroutine, den allaze tipota allo ousiastika afou kai to prgoresscomplete
//basizotan sto slider bar kai oxi se kapio coroutine gia na deiksei to progress
//sth sunexeia, gia na mhn emfanistoun out of range provlima me to current recipe index = -1 oso kapio coroutine perimene gia materials, ebala sto wait until mia OR me ena temp index gia na prosexei 
// an allaksei to currentrecipe sto sugkekrimeno smelter, ama allaksei, teliwnei h wait until kai kleinei to coroutine.