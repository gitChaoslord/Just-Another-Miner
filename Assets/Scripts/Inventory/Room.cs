using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room {
    // Start is called before the first frame update
   public string RoomName {get; set;}
   public string RoomEffectText {get; set;}
   public int RoomEffect {get; set;}
   public int RoomLevel {get; set;}
   public int RoomMaxLevel {get; set;}
   public int RoomCost {get; set;}
   public Sprite RoomImg{ get; set; }
   public int RoomType { get; set; }

    public Room(string RoomName,string RoomEffectText,int RoomEffect,int RoomLevel,int RoomMaxLevel,int RoomCost,Sprite RoomImg,int RoomType){
			
			this.RoomName = RoomName;
            this.RoomEffectText = RoomEffectText;
            this.RoomEffect = RoomEffect;
            this.RoomLevel = RoomLevel;
            this.RoomMaxLevel = RoomMaxLevel;
            this.RoomCost = RoomCost;
            this.RoomImg = RoomImg;
            this.RoomType = RoomType;
	}




}
