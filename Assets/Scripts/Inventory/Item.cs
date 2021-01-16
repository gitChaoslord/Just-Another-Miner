using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	// oti thelw na exei mia Item
	public class  Item  {
		public string ItemName{ get; set; }
		public int ItemAmount{ get; set; }
		public float ItemValue{ get; set; }
		public Sprite ItemIcon{ get; set; }
	//https://www.c-sharpcorner.com/UploadFile/mahesh/insert-item-into-a-C-Sharp-list/

	public Item(string ItemName,int ItemAmount,float ItemValue,Sprite ItemIcon){
			this.ItemName = ItemName;
			this.ItemAmount = ItemAmount;
			this.ItemValue = ItemValue;
			this.ItemIcon = ItemIcon;


	}
}


	
	

	// valw kapia metavliti tou tupou Bool IsUnlocked 
	//wste na mh to deixnei an den exeis planet pou deixnei production/ h an den exeis ksekleidwsei recipe pou to apetei san material



