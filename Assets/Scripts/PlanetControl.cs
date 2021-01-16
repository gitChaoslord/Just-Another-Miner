using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetControl : MonoBehaviour {

public static List<Planet> Planets = new List<Planet>();
//CanvasController Ref gia na trexei to MenuControl Script
public GameObject CanvasControllerOBJ;

public GameObject WorldSpaceContent;
public GameObject PanelContent;	

public GameObject PlanetPref;
public GameObject PanelPref;
public GameObject ResourcePref;

//static gia na tin kanei access to ResearchControl kai "new" list giati allios crasharei, de kserw to reasoning
//https://answers.unity.com/questions/607093/static-list-wontt-call-add-or-count.html
public static List<GameObject> PlanetRefList = new List<GameObject>();
//allakse kai auto gia to kanei acess to ResearchCOntrol
public static List<GameObject> PanelRefList = new List<GameObject>();

public void Start(){
	//TODO, find alternative for FIND, its considered slow
	//telika apla evala to alithino object ws orisma sto inspector kai doulepse xwris error
	//CanvasControllerOBJ = GameObject.Find("CanvasController");//.GetComponent<MenuControl>();;
	
	// Make a planet
	//int PlanetIndex,string PlanetName,int PlanetLVL,int PlanetUNC,int PlanetUPC, bool PlanetUnlocked,Sprite PlanetIcon,int PlanetXcoord,int PlanetYcoord,int PlanetResCount,
	//int PlanetRes1Idx,int PlanetRes1Y,float PlanetRes1R,
	//int PlanetRes2Idx,int PlanetRes2Y,float PlanetRes2R,
	//int PlanetRes3Idx,int PlanetRes3Y,float PlanetRes3R )

	// read data from json....
	// gameObj = filessystem.read('wow.json')
	// planets = gameObj.planets; //Array<planets>
	// planets.foreach((planet[i])=>{ new Planet(planet[i]) })


	var Planet1 = new Planet(1,"Terra",0,100,10,true,Resources.Load<Sprite>("Planets/1Terra"),0,0,1,0,1,1,0,0,0,0,0,0);
	var Planet2 = new Planet(2,"Krakaum",0,250,25,false,Resources.Load<Sprite>("Planets/2Krakaum"),70,80,2,1,0.8f,1,2,0.4f,1,0,0,0);
	var Planet3 = new Planet(3,"Asteroid XB-35",0,750,75,false,Resources.Load<Sprite>("Planets/3PH"),100,-40,3,1,0.4f,1,2,0.4f,1,3,0.2f,1);
	var Planet4 = new Planet(4,"Asteroid SR-71",0,1500,150,false,Resources.Load<Sprite>("Planets/4PH"),-90,-20,2,3,0.8f,1,2,0.2f,1,0,0,0);
	
	Planets.Add(Planet1);
	Planets.Add(Planet2);
	Planets.Add(Planet3);
	Planets.Add(Planet4);

	for (int PlanetIDX = 0; PlanetIDX < Planets.Count; PlanetIDX++){
		// index-1 giati o pinakas ksekinaei apo 0, alla to prwto value einai to 1
		var localindex = PlanetIDX;
		//instantiate PLANET
		var copy = (GameObject)Instantiate(PlanetPref);
			//kanei disable olous tous planites peran tou prwtou, wste na tous kanw reveal me ta research later// douleue swsta palia, twra de kserw ti skata epathe
			//if(PlanetIDX >= 1){
			//	copy.gameObject.SetActive(false);
			//}	
			if(PlanetIDX == 0){
			copy.gameObject.SetActive(true);
			}	
		
			PlanetRefList.Add(copy);
			copy.GetComponent<Image>().sprite = Planets[localindex].PlanetIcon;
			copy.gameObject.name = Planets[localindex].PlanetName;
			//Setup location in worldspace
			copy.transform.SetParent(WorldSpaceContent.transform,false);
			copy.transform.localPosition = Vector3.zero;
			//coord stuff
			Vector2 pos = transform.position;
				pos.x = Planets[localindex].PlanetXcoord;
				pos.y = Planets[localindex].PlanetYcoord;
			copy.transform.position = pos;
			//https://answers.unity.com/questions/656129/c-changing-the-x-and-y-values-of-a-gameobject.html


			copy.GetComponent<Button>().onClick.AddListener(()=>{
				OpenPanel(localindex);
			});
		//instantiate PANEL
		var kopy = Instantiate(PanelPref);
			PanelRefList.Add(kopy);
			kopy.gameObject.name = Planets[localindex].PlanetName;
			kopy.transform.SetParent(PanelContent.transform, false);
			kopy.transform.localPosition = Vector3.zero;
			
			//MAIN PANEL
				//planet name & indx
				kopy.GetComponentsInChildren<Text>()[0].text = Planets[localindex].PlanetIndex + " - "+ Planets[localindex].PlanetName;
				//planet icon inside panel
				kopy.GetComponentsInChildren<Image>()[1].sprite = Planets[localindex].PlanetIcon;
				//planet lvl
				kopy.GetComponentsInChildren<Text>()[4].text = Planets[localindex].PlanetLVL.ToString();
				kopy.GetComponentsInChildren<Button>()[0].onClick.AddListener(()=>{
					Debug.Log("manager panel");
				});

				//Info/Help Panel
				kopy.GetComponentsInChildren<Button>()[2].onClick.AddListener(()=>{
					Debug.Log("info");
				});

			// BUY PANEL
				kopy.GetComponentsInChildren<Text>()[6].text = Planets[localindex].PlanetIndex.ToString()+" - "+Planets[localindex].PlanetName.ToString();
				kopy.GetComponentsInChildren<Text>()[7].text = Planets[localindex].PlanetUNC.ToString();
				kopy.GetComponentsInChildren<Image>()[10].sprite = Planets[localindex].PlanetIcon;
				
			//button 2 = planet buy
			kopy.GetComponentsInChildren<Button>()[3].onClick.AddListener(()=>{
				//Buy Planet
				if(CurrencyControl.Cash >= Planets[localindex].PlanetUNC){

			
					// no idea how to reference this part in the future
				//instantiate resources in Panel
					for(int residx = 0; residx < Planets[localindex].PlanetResCount; residx++){
						var bopy = Instantiate(ResourcePref);
						//initializes values for each resource in panel
						if(residx == 0){
							bopy.gameObject.name = OreControl.Ores[Planets[localindex].PlanetRes1Idx].OreName;
							bopy.GetComponentInChildren<Image>().sprite = OreControl.Ores[Planets[localindex].PlanetRes1Idx].OreIcon;
							bopy.GetComponentsInChildren<Text>()[0].text = ((Planets[localindex].PlanetRes1Y/1)*100).ToString()+ " %";
							bopy.GetComponentsInChildren<Text>()[1].text = (Planets[localindex].PlanetRes1R*Planets[localindex].PlanetRes1Y).ToString()+ " / S";
							
						}	
						else if (residx == 1){
							bopy.gameObject.name = OreControl.Ores[Planets[localindex].PlanetRes2Idx].OreName;
							bopy.GetComponentInChildren<Image>().sprite = OreControl.Ores[Planets[localindex].PlanetRes2Idx].OreIcon;
							bopy.GetComponentsInChildren<Text>()[0].text = ((Planets[localindex].PlanetRes2Y/1)*100).ToString()+ " %";
							bopy.GetComponentsInChildren<Text>()[1].text = (Planets[localindex].PlanetRes2R*Planets[localindex].PlanetRes2Y).ToString()+ " / S";
						}
						else
						{
							bopy.gameObject.name = OreControl.Ores[Planets[localindex].PlanetRes3Idx].OreName;
							bopy.GetComponentInChildren<Image>().sprite = OreControl.Ores[Planets[localindex].PlanetRes3Idx].OreIcon;
							bopy.GetComponentsInChildren<Text>()[0].text = ((Planets[localindex].PlanetRes3Y/1)*100).ToString()+ " %";
							bopy.GetComponentsInChildren<Text>()[1].text = (Planets[localindex].PlanetRes3R*Planets[localindex].PlanetRes3Y).ToString()+ " / S";
						}
						//sets location in panel
						bopy.transform.SetParent(kopy.GetComponentInChildren<VerticalLayoutGroup>().transform, false);
						bopy.transform.localPosition = Vector3.zero;
						//deactivates resources which are not yet enabled for a planet
					/* 	if( residx >= Planets[localindex].PlanetResCount  ){
							bopy.gameObject.SetActive(false);
						}*/
						// thelw to kathe planet na exei max 3 resource
						
					}
				// end instantiation of resources in panel	
					//removes cash
					CurrencyControl.Cash -= Planets[localindex].PlanetUNC;
					//disables buy panel	
					kopy.GetComponentsInChildren<Button>()[3].transform.parent.gameObject.SetActive(false);
					// updates planet lvl
					Planets[localindex].PlanetLVL = 1;
					kopy.GetComponentsInChildren<Text>()[4].text = "LvL : " + Planets[localindex].PlanetLVL;
					//updates Upgrade Cost
					Planets[localindex].PlanetUPC = Mathf.RoundToInt((Planets[localindex].PlanetUPC * 110)/100);
					kopy.GetComponentsInChildren<Text>()[5].text = Planets[localindex].PlanetUPC.ToString();
					//start production
				//	StartCoroutine(PlanetProduction(localindex,Planets[localindex].PlanetRes1Idx,Planets[localindex].PlanetRes2Idx,Planets[localindex].PlanetRes3Idx));
					StartCoroutine(PlanetProduction(localindex));
				}
			});
			//button 1 = upgrade planet
			kopy.GetComponentsInChildren<Button>()[1].onClick.AddListener(()=>{
				if(CurrencyControl.Cash >= Planets[localindex].PlanetUPC){
					//removes cash
					CurrencyControl.Cash -= Planets[localindex].PlanetUPC;
					//updates Upgrades cost
					Planets[localindex].PlanetUPC = Mathf.RoundToInt((Planets[localindex].PlanetUPC * 110)/100);
					kopy.GetComponentsInChildren<Text>()[5].text = Planets[localindex].PlanetUPC.ToString();
					// updates planet lvl
					Planets[localindex].PlanetLVL += 1;
					kopy.GetComponentsInChildren<Text>()[4].text = "LvL : " + Planets[localindex].PlanetLVL;


					
					
					//TODO, prestige bonus added here?
					//updates resource rates 
					Planets[localindex].PlanetRes1R = Planets[localindex].PlanetLVL;
					Planets[localindex].PlanetRes2R = Planets[localindex].PlanetLVL;
					Planets[localindex].PlanetRes3R = Planets[localindex].PlanetLVL;
					//pio tsapatsouliko xanei
					if(Planets[localindex].PlanetResCount == 1){
						kopy.GetComponentsInChildren<Text>()[7].text = (Planets[localindex].PlanetRes1R*Planets[localindex].PlanetRes1Y).ToString()+ " / S";
					}
					else if(Planets[localindex].PlanetResCount == 2){
						kopy.GetComponentsInChildren<Text>()[7].text = (Planets[localindex].PlanetRes1R*Planets[localindex].PlanetRes1Y).ToString()+ " / S";
						kopy.GetComponentsInChildren<Text>()[9].text = (Planets[localindex].PlanetRes2R*Planets[localindex].PlanetRes2Y).ToString()+ " / S";
					}
					else
					{
						kopy.GetComponentsInChildren<Text>()[7].text = (Planets[localindex].PlanetRes1R*Planets[localindex].PlanetRes1Y).ToString() + " / S";
						kopy.GetComponentsInChildren<Text>()[9].text = (Planets[localindex].PlanetRes2R*Planets[localindex].PlanetRes2Y).ToString()+ " / S";
						kopy.GetComponentsInChildren<Text>()[11].text = (Planets[localindex].PlanetRes3R*Planets[localindex].PlanetRes3Y).ToString()+ " / S";
					}
					
 				}
			});
			
	}

//




	}
	//public MyScript = MenuControl();
	public void OpenPanel(int localindex){
		//anoigei to panel xrhsimopoiontas to CanvasController.menuControl.ShowPanel(transform paneltoShow);
		var test = PanelRefList[localindex].gameObject;
		CanvasControllerOBJ.GetComponent<MenuControl>().ShowMenuPanel(test.transform);;
	}
	//Ore generation
	//private IEnumerator PlanetProduction(int idx,int res1idx,int res2idx,int res3idx){
	private IEnumerator PlanetProduction(int idx){
		//na valw check poso rescount exei gia an mi kanw kathe second mhdenikes praksis
		OreControl.Ores[Planets[idx].PlanetRes1Idx].OreAmount += Mathf.RoundToInt(Planets[idx].PlanetRes1R * Planets[idx].PlanetRes1Y);
		OreControl.Ores[Planets[idx].PlanetRes2Idx].OreAmount += Mathf.RoundToInt(Planets[idx].PlanetRes2R * Planets[idx].PlanetRes2Y);
		OreControl.Ores[Planets[idx].PlanetRes3Idx].OreAmount += Mathf.RoundToInt(Planets[idx].PlanetRes3R * Planets[idx].PlanetRes3Y);
		yield return new WaitForSeconds(1);
		//StartCoroutine(PlanetProduction(idx,res1idx,res2idx,res3idx));
		StartCoroutine(PlanetProduction(idx));
		

		//Debug.Log(Planets[idx].PlanetRes1Idx+"" +Planets[idx].PlanetRes2Idx+""+Planets[idx].PlanetRes3Idx);

	}

}






//kanw to resource instantiation tou planiti sto panel, otan patithei to buy button giati den borw na to kanw early during script start, logo outi o pinakas me ta resources den exei ginei akoma instantiate