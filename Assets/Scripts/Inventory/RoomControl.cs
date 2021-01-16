using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomControl : MonoBehaviour {
    
    public static List<Room> Rooms = new List<Room>();

    public GameObject RoomContent;
    public GameObject RoomPrefab;
    public int RoomIDX = 0;

    //room refs -- na ta kanw rename sthn poria
    public GameObject InvestorRef;
    public GameObject PaparasRef;
    public GameObject trobetasRef;
    public GameObject idinahueRef;

///ROOM TYPE 1 = PLUS PERCENTAGE BONUS, 2 MINUS PERCENTAGE BONUS, 3 FLAT INT INCREASE --------- TEXT PURPOSES ONLY
    public void Start(){
        
        var Room1 = new Room("Investment Analyst","Generates Cash",1,0,10,5,Resources.Load<Sprite>("Ores/1CopperOre"),1);
        var Room2 = new Room("Paparas","Mining rate",10,0,20,5,Resources.Load<Sprite>("Ores/1CopperOre"),1);
        var Room3 = new Room("trobetas","Mission Times",1,0,25,5,Resources.Load<Sprite>("Ores/1CopperOre"),1);
        var Room4 = new Room("idinahue","Smelting speed",5,0,25,5,Resources.Load<Sprite>("Ores/1CopperOre"),1);


        Rooms.Add(Room1);
        Rooms.Add(Room2);  
        Rooms.Add(Room3);
        Rooms.Add(Room4);
        
        foreach (var Room in Rooms) {
            //Instantiation
            var copy = (GameObject)Instantiate(RoomPrefab);
		    copy.gameObject.name = Rooms[RoomIDX].RoomName;
            copy.transform.SetParent(RoomContent.transform, false);
		    copy.transform.localPosition = Vector3.zero;

            copy.gameObject.name = Rooms[RoomIDX].RoomName;
            //makes reference list, prepei na vrw kalutero tropo, lol
            if(RoomIDX == 0){
			    InvestorRef = copy;
            }
            if(RoomIDX == 1){
			    PaparasRef = copy;
            }
            if(RoomIDX == 2){
			    trobetasRef = copy;
            }
            if(RoomIDX == 3){
			    idinahueRef = copy;
            }

            // Sets Prefabs values
            copy.GetComponentsInChildren<Image>()[1].sprite = (Rooms[RoomIDX].RoomImg);
            copy.GetComponentsInChildren<Text>()[0].text = (Rooms[RoomIDX].RoomName);
            copy.GetComponentsInChildren<Text>()[1].text = "LvL : " + (Rooms[RoomIDX].RoomLevel).ToString() + " / " + (Rooms[RoomIDX].RoomMaxLevel).ToString();
            copy.GetComponentsInChildren<Text>()[2].text = (Rooms[RoomIDX].RoomEffectText);
            //na dw pws tha ftiaksw to effect
            
            copy.GetComponentsInChildren<Text>()[3].text = (Rooms[RoomIDX].RoomEffect).ToString() + " %";

            //buy/ugprade btn 
            int localindex = RoomIDX; // pass clicked buttons index to upgrade room
            copy.GetComponentsInChildren<Text>()[4].text = (Rooms[RoomIDX].RoomCost).ToString();
            copy.GetComponentsInChildren<Button>()[0].onClick.AddListener( () =>{
                //check if room can be leveled up
                if(Rooms[localindex].RoomLevel < Rooms[localindex].RoomMaxLevel){
                    if (CurrencyControl.GalaxyCredits >= Rooms[localindex].RoomCost){
                        //substract galaxy credits
                        CurrencyControl.GalaxyCredits -= Rooms[localindex].RoomCost;
                        //handle level change
                        Rooms[localindex].RoomLevel +=1;
                        //NEED TO ADD EFFECT FOR EACH ROOM
                        
                        copy.GetComponentsInChildren<Text>()[1].text = "LvL : " + (Rooms[localindex].RoomLevel).ToString() + " / " + (Rooms[localindex].RoomMaxLevel).ToString();

                        copy.GetComponentsInChildren<Text>()[3].text = "+ "+(Rooms[localindex].RoomEffect *Rooms[localindex].RoomLevel ).ToString() + " %";
                        //handle cost change
                        Rooms[localindex].RoomCost +=1;
                        copy.GetComponentsInChildren<Text>()[4].text = (Rooms[localindex].RoomCost).ToString();
                        //if it current level reaches max, disable the button
                        if(Rooms[localindex].RoomLevel == Rooms[localindex].RoomMaxLevel){
                            copy.GetComponentsInChildren<Button>()[0].interactable = false;
                            copy.GetComponentsInChildren<Text>()[4].text = "MAX";
                        }
                    }
                    else
                    {
                        Debug.Log("not enough credits");
                    }
                }
                else
                {
                    Debug.Log("room at max level");
                }

                //    UpgradeRoom(localindex);
                
            });
            RoomIDX++;
        }
        
    }

   // public void UpgradeRoom(int Roomindex) {
   //     Debug.Log(Roomindex);
   //     CurrencyControl.GalaxyCredits -= Rooms[Roomindex].RoomCost;
  //      Rooms[Roomindex].RoomCost +=1;

  //  }
    
}
