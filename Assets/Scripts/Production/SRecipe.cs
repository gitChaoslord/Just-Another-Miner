using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	
	public class  SRecipe  {

		// na dhlwnw posa resources exei gia na kalw allo prefab pou fenete pio wraio an exei ligotera required resources
		public int ResCount;

		public string Name{ get; set; }
		public int Duration{ get; set; }
		public Sprite OutputIcon{ get; set; }
		
		
		public Sprite resIcon1{ get; set; }
		public int resAmount1{ get; set; }
		public int resIdx1{ get; set; }

		public Sprite resIcon2{ get; set; }
		public int resAmount2{ get; set; }
		public int resIdx2{ get; set; }

		public Sprite resIcon3{ get; set; }
		public int resAmount3{ get; set; }
		public int resIdx3{ get; set; }


		public bool isUnlocked{ get; set; }
		public int UnlockCost{ get; set; }
		
		
	//https://www.c-sharpcorner.com/UploadFile/mahesh/insert-item-into-a-C-Sharp-list/

	public SRecipe(int ResCount,string Name,int Duration,Sprite OutputIcon, Sprite resIcon1,Sprite resIcon2, Sprite resIcon3,int resAmount1,int resIdx1,int resAmount2,int resIdx2,int resAmount3,int resIdx3, bool isUnlocked,int UnlockCost){
			this.ResCount = ResCount;
			this.Name = Name;
			this.Duration = Duration;
			this.OutputIcon = OutputIcon;
			

			this.resIcon1 = resIcon1;
			this.resAmount1 = resAmount1;
			this.resIdx1 = resIdx1;

			this.resIcon2 = resIcon2;
			this.resAmount2 = resAmount2;
			this.resIdx2 = resIdx2;

			this.resIcon3 = resIcon3;
			this.resAmount3 = resAmount3;
			this.resIdx3 = resIdx3;

			this.isUnlocked = isUnlocked;
			this.UnlockCost = UnlockCost;

	}
}


	
	

 	
	



