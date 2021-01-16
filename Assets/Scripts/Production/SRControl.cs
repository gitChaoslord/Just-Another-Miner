using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
	
public class  SRControl : MonoBehaviour  {

	//recipies
	public static List<SRecipe> SRecipes = new List<SRecipe>();
	public GameObject SRecipePanel;
	public GameObject RecipeContent;
		
	
	public GameObject SRecipeUIRes1;
	public GameObject SRecipeUIRes2;
	public GameObject SRecipeUIRes3;
	public List<GameObject> RefRecipeList;
	
	public void Start(){
	//int ResCount | string Name | int Duration | Sprite OutputIcon |  Sprite resIcon1 | Sprite resIcon2 | Sprite resIcon3 | int resAmount1 | int resIdx1 |int resAmount2 | int resIdx1 | int resAmount3 | int resIdx1 | bool isUnlocked |int UnlockCost)
	// ResIdx 0 = copper, 1 = tin etc
	var SRecipe1 = new SRecipe (1,"Copper Bar",30,Resources.Load<Sprite>("Bars/1CopperBar"),Resources.Load<Sprite>("Ores/1CopperOre"),null,null,1000,0,0,0,0,0,true,0);
	var SRecipe2 = new SRecipe (1,"Tin Bar",45,Resources.Load<Sprite>("Bars/2TinBar"),Resources.Load<Sprite>("Ores/2TinOre"),null,null,1000,1,0,0,0,0,false,1700);
	var SRecipe3 = new SRecipe (2,"Bronze Bar",90,Resources.Load<Sprite>("Bars/3BronzeBar"),Resources.Load<Sprite>("Ores/1CopperOre"),Resources.Load<Sprite>("Ores/2TinOre"),null,500,0,500,1,0,0,false,2500);
	var SRecipe4 = new SRecipe (3,"Iron Bar",120,Resources.Load<Sprite>("Bars/4IronBar"),Resources.Load<Sprite>("Ores/1CopperOre"),Resources.Load<Sprite>("Ores/2TinOre"),Resources.Load<Sprite>("Ores/3IronOre"),750,0,650,1,550,2,false,5000);
	

	SRecipes.Add(SRecipe1);
	SRecipes.Add(SRecipe2);
	SRecipes.Add(SRecipe3);
	SRecipes.Add(SRecipe4);
	

		for(int SRecipeIndex = 0; SRecipeIndex < SRecipes.Count; SRecipeIndex++){

			if(SRecipes[SRecipeIndex].ResCount == 1){
				
			
			var copy = (GameObject)Instantiate(SRecipeUIRes1);
				//na to kanei disable an ta proigoumena den einai unlocked, thelw na fenete ena choice available gia unlock kathe fora
				if(SRecipeIndex > 1){
					copy.gameObject.SetActive(false);
				}	
				RefRecipeList.Add(copy);	

				copy.gameObject.name = SRecipes[SRecipeIndex].Name;
				copy.transform.SetParent(RecipeContent.transform, false);
				copy.transform.localPosition = Vector3.zero;

				//input 1 image & amount
				copy.GetComponentsInChildren<Image>()[1].sprite = (SRecipes[SRecipeIndex].resIcon1);
				copy.GetComponentsInChildren<Text>()[0].text = (SRecipes[SRecipeIndex].resAmount1).ToString();
				//duration
				copy.GetComponentsInChildren<Text>()[1].text = (SRecipes[SRecipeIndex].Duration).ToString() + "s";
				//name
				copy.GetComponentsInChildren<Text>()[2].text = (SRecipes[SRecipeIndex].Name);
				//output image
				copy.GetComponentsInChildren<Image>()[2].sprite = (SRecipes[SRecipeIndex].OutputIcon);
				//cost text 3 giati exoume 5texts (ksekina apo 0)
				copy.GetComponentsInChildren<Text>()[3].text = (SRecipes[SRecipeIndex].UnlockCost).ToString();

				var localindex = SRecipeIndex;
				if(SRecipes[SRecipeIndex].isUnlocked == true){
					//na kanei disable to unlockpanel/button an to recipe einai unlocked	
					copy.GetComponentsInChildren<Button>()[1].gameObject.SetActive(false);
				}
				else
				{
					//listener gia na kanei disable to "Buy Panel" kai na kanei enable to epomeno "available to buy recipe"
					copy.GetComponentsInChildren<Button>()[1].onClick.AddListener( () => {	
					if(CurrencyControl.Cash >= SRecipes[localindex].UnlockCost	){
						CurrencyControl.Cash -= SRecipes[localindex].UnlockCost;
						copy.GetComponentsInChildren<Button>()[1].gameObject.SetActive(false);		
						//check gia na vlepei an einai to telefteo ths listas, giati allios out of bounds
						//h prwth timh tou count den einai 0, opote +1 sto index
						if(localindex+1 != SRecipes.Count){
							RefRecipeList[localindex+1].SetActive(true);
						}
						//xreiazete na kanw remove to listener gia perfomance?
						}				
					});		
				}
				copy.GetComponent<Button>().onClick.AddListener(() => 	{	
						// na pernei to selection,oti thelw na kanw smelt
						SRecipePanel.SetActive(false);
						BuySmelterScript.TestIndex1 = localindex;
				}
			);
		
			 ////------ end resource 1 prefab
		}
		else if (SRecipes[SRecipeIndex].ResCount == 2)
		{

				var copy = (GameObject)Instantiate(SRecipeUIRes2);
				//na to kanei disable an ta proigoumena den einai unlocked, thelw na fenete ena choice available gia unlock kathe fora
				if(SRecipeIndex > 1){
					copy.gameObject.SetActive(false);
				}	
				RefRecipeList.Add(copy);	

				copy.gameObject.name = SRecipes[SRecipeIndex].Name;
				copy.transform.SetParent(RecipeContent.transform, false);
				copy.transform.localPosition = Vector3.zero;
				//input 1 image & amount
				copy.GetComponentsInChildren<Image>()[1].sprite = (SRecipes[SRecipeIndex].resIcon1);
				copy.GetComponentsInChildren<Text>()[0].text = (SRecipes[SRecipeIndex].resAmount1).ToString();
				//input 2 image & amount
				copy.GetComponentsInChildren<Image>()[2].sprite = (SRecipes[SRecipeIndex].resIcon2);
				copy.GetComponentsInChildren<Text>()[1].text = (SRecipes[SRecipeIndex].resAmount2).ToString();
				//duration
				copy.GetComponentsInChildren<Text>()[2].text = (SRecipes[SRecipeIndex].Duration).ToString() + "s";
				//name
				copy.GetComponentsInChildren<Text>()[3].text = (SRecipes[SRecipeIndex].Name);
				//output image
				copy.GetComponentsInChildren<Image>()[3].sprite = (SRecipes[SRecipeIndex].OutputIcon);
				//cost text 4 giati exoume 5texts (ksekina apo 0)
				copy.GetComponentsInChildren<Text>()[4].text = (SRecipes[SRecipeIndex].UnlockCost).ToString();

				var localindex = SRecipeIndex;
				if(SRecipes[SRecipeIndex].isUnlocked == true){
					//na kanei disable to unlockpanel/button an to recipe einai unlocked	
					copy.GetComponentsInChildren<Button>()[1].gameObject.SetActive(false);
					}
				else
					{
					//listener gia na kanei disable to "Buy Panel" kai na kanei enable to epomeno "available to buy recipe"
					copy.GetComponentsInChildren<Button>()[1].onClick.AddListener( () => {	
					if(CurrencyControl.Cash >= SRecipes[localindex].UnlockCost	){
						CurrencyControl.Cash -= SRecipes[localindex].UnlockCost;
						copy.GetComponentsInChildren<Button>()[1].gameObject.SetActive(false);		
						//check gia na vlepei an einai to telefteo ths listas, giati allios out of bounds
						//h prwth timh tou count den einai 0, opote +1 sto index
						if(localindex+1 != SRecipes.Count){
							RefRecipeList[localindex+1].SetActive(true);
							}
						//xreiazete na kanw remove to listener gia perfomance?
							}				
						});		
					}
				copy.GetComponent<Button>().onClick.AddListener(() => 	{	
						// na pernei to selection,oti thelw na kanw smelt
						SRecipePanel.SetActive(false);
						BuySmelterScript.TestIndex1 = localindex;
				}
			);
			////------ end resource 2 prefab
		}
		else
		{
			var copy = (GameObject)Instantiate(SRecipeUIRes3);
				//na to kanei disable an ta proigoumena den einai unlocked, thelw na fenete ena choice available gia unlock kathe fora
				if(SRecipeIndex > 1){
					copy.gameObject.SetActive(false);
				}	
				RefRecipeList.Add(copy);	

				copy.gameObject.name = SRecipes[SRecipeIndex].Name;
				copy.transform.SetParent(RecipeContent.transform, false);
				copy.transform.localPosition = Vector3.zero;

				//input 1 image & amount
				copy.GetComponentsInChildren<Image>()[1].sprite = (SRecipes[SRecipeIndex].resIcon1);
				copy.GetComponentsInChildren<Text>()[0].text = (SRecipes[SRecipeIndex].resAmount1).ToString();
				//input 2 image & amount
				copy.GetComponentsInChildren<Image>()[2].sprite = (SRecipes[SRecipeIndex].resIcon2);
				copy.GetComponentsInChildren<Text>()[1].text = (SRecipes[SRecipeIndex].resAmount2).ToString();
				//input 3 image & amount
				copy.GetComponentsInChildren<Image>()[3].sprite = (SRecipes[SRecipeIndex].resIcon3);
				copy.GetComponentsInChildren<Text>()[2].text = (SRecipes[SRecipeIndex].resAmount3).ToString();

				//duration
				copy.GetComponentsInChildren<Text>()[3].text = (SRecipes[SRecipeIndex].Duration).ToString() + "s";
				//name
				copy.GetComponentsInChildren<Text>()[4].text = (SRecipes[SRecipeIndex].Name);
				//output image
				copy.GetComponentsInChildren<Image>()[4].sprite = (SRecipes[SRecipeIndex].OutputIcon);
				//cost text 5 giati exoume 5texts (ksekina apo 0)
				copy.GetComponentsInChildren<Text>()[5].text = (SRecipes[SRecipeIndex].UnlockCost).ToString();

				var localindex = SRecipeIndex;
				if(SRecipes[SRecipeIndex].isUnlocked == true){
					//na kanei disable to unlockpanel/button an to recipe einai unlocked	
					copy.GetComponentsInChildren<Button>()[1].gameObject.SetActive(false);
					}
				else
					{
					//listener gia na kanei disable to "Buy Panel" kai na kanei enable to epomeno "available to buy recipe"
					copy.GetComponentsInChildren<Button>()[1].onClick.AddListener( () => {	
					if(CurrencyControl.Cash >= SRecipes[localindex].UnlockCost	){
						CurrencyControl.Cash -= SRecipes[localindex].UnlockCost;
						copy.GetComponentsInChildren<Button>()[1].gameObject.SetActive(false);		
						//check gia na vlepei an einai to telefteo ths listas, giati allios out of bounds
						//h prwth timh tou count den einai 0, opote +1 sto index
						if(localindex+1 != SRecipes.Count){
							RefRecipeList[localindex+1].SetActive(true);
							}
						//xreiazete na kanw remove to listener gia perfomance?
							}				
						});		
					}
				copy.GetComponent<Button>().onClick.AddListener(() => 	{	
						// na pernei to selection,oti thelw na kanw smelt
						SRecipePanel.SetActive(false);
						BuySmelterScript.TestIndex1 = localindex;
				}
			);



			////------ end resource 3 prefab
		}
	}
	}
}


	



	

