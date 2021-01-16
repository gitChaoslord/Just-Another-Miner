using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	// oti thelw na exei ena Ore
	public class  Ore  {
		
		public string OreName{ get; set; }
		public int OreAmount{ get; set; }
		public float OreValue{ get; set; }
		public Sprite OreIcon{ get; set; }
	//https://www.c-sharpcorner.com/UploadFile/mahesh/insert-item-into-a-C-Sharp-list/

	public Ore(string OreName,int OreAmount,float OreValue,Sprite OreIcon){
			
			this.OreName = OreName;
			this.OreAmount = OreAmount;
			this.OreValue = OreValue;
			this.OreIcon = OreIcon;


	}
}


	
	

 	
	//wste na mh to deixnei an den exeis planet pou deixnei production/ h an den exeis ksekleidwsei recipe pou to apetei san material



