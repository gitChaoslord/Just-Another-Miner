using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchControl : MonoBehaviour {
	//smelter unlock
	public Button ProductionPanelBtn;
	public Button UnlockProductionResearch;
	//for terra mineral scan
	public GameObject ResourcePref;
	public Button TerraMineralScanBtn;
	//Scopes/satellites and more planets research btns
	public Button Scope1Btn;
	public Button Scope2Btn;

	//GENERAL TREE
	public void UnlockSmelter(){
		if(CurrencyControl.Cash >= 1000){
			CurrencyControl.Cash -= 1000;	
			ProductionPanelBtn.interactable = true;
			UnlockProductionResearch.interactable = false;
		}
	}
	public void UnlockCrafter(){
		
	}
	public void UnlockScope1(){
		if(CurrencyControl.Cash >= 100){
			CurrencyControl.Cash -= 100;
			PlanetControl.PlanetRefList[1].gameObject.SetActive(true);
			PlanetControl.PlanetRefList[2].gameObject.SetActive(true);	
			Scope1Btn.interactable = false;
		}
	}
	public void TerraMineralScans(){
		if(CurrencyControl.Cash >= 200){
			CurrencyControl.Cash -= 200;
			//add "tin" resource to Planet "Terra"
			PlanetControl.Planets[0].PlanetResCount = 2;
			PlanetControl.Planets[0].PlanetRes2Idx = 1;
			PlanetControl.Planets[0].PlanetRes2R = PlanetControl.Planets[0].PlanetLVL;
			PlanetControl.Planets[0].PlanetRes2Y = 0.2f;

			//instantiate resourcePref to Terra pannel
			var bopy = Instantiate(ResourcePref);
				bopy.transform.SetParent(PlanetControl.PanelRefList[0].gameObject.GetComponentInChildren<VerticalLayoutGroup>().transform, false);
				bopy.transform.localPosition = Vector3.zero;

				bopy.gameObject.name = OreControl.Ores[PlanetControl.Planets[0].PlanetRes2Idx].OreName;
					bopy.GetComponentInChildren<Image>().sprite = OreControl.Ores[PlanetControl.Planets[0].PlanetRes2Idx].OreIcon;
					bopy.GetComponentsInChildren<Text>()[0].text = ((PlanetControl.Planets[0].PlanetRes2Y/1)*100).ToString()+ " %";
					bopy.GetComponentsInChildren<Text>()[1].text = (PlanetControl.Planets[0].PlanetRes2R*PlanetControl.Planets[0].PlanetRes2Y).ToString()+ " / S";  
				TerraMineralScanBtn.interactable = false;


		}
	}
	public void TerraFrackingTechniques(){
		
	}
	public void AutonomousAgents(){

	}
	public void UnlockMissionControl(){

	}
	public void UnlockPrestige(){
	
	}
	public void UnlockProTree(){

	}
	public void UnlockTechTree(){}
	public void UnlockExpTree(){}
	public void UnlockEcoTree(){}	
	
	
	//other tree
	public void Scope2Upgrade(){
		if(CurrencyControl.Cash >= 150){
			CurrencyControl.Cash -= 150;
			PlanetControl.PlanetRefList[3].gameObject.SetActive(true);
			Scope2Btn.interactable = false;
		}
	}

	
}
