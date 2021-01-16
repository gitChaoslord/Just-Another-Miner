using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet {

		//Planetlanet info
		public int PlanetIndex;
		public string PlanetName;
		public int PlanetLVL;
		public int PlanetUNC;
		public int PlanetUPC;
		public bool PlanetUnlocked;
		public Sprite PlanetIcon;
		public int PlanetXcoord;
		public int PlanetYcoord;

		// TODO add coordinates for instantiation in gameworld


		//Planetlanet resources
		public int PlanetResCount;
		
			public int PlanetRes1Idx;
			public float PlanetRes1Y;
			public float PlanetRes1R;

			public int PlanetRes2Idx;
			public float PlanetRes2Y;
			public float PlanetRes2R;

			public int PlanetRes3Idx;
			public float PlanetRes3Y;
			public float PlanetRes3R;


		public Planet (int PlanetIndex,string PlanetName,int PlanetLVL,int PlanetUNC,int PlanetUPC, bool PlanetUnlocked,Sprite PlanetIcon,int PlanetXcoord,int PlanetYcoord,int PlanetResCount,
			int PlanetRes1Idx,float PlanetRes1Y,float PlanetRes1R,
			int PlanetRes2Idx,float PlanetRes2Y,float PlanetRes2R,
			int PlanetRes3Idx,float PlanetRes3Y,float PlanetRes3R ){
			

					this.PlanetIndex = PlanetIndex; //this.planetindex = planetobject.planetindex;
					this.PlanetName = PlanetName;
					this.PlanetLVL = PlanetLVL;
					this.PlanetUNC = PlanetUNC;
					this.PlanetUPC = PlanetUPC;
					this.PlanetUnlocked = PlanetUnlocked;
					this.PlanetIcon = PlanetIcon;
					this.PlanetXcoord = PlanetXcoord;
					this.PlanetYcoord = PlanetYcoord;
					this.PlanetResCount = PlanetResCount;

					this.PlanetRes1Idx = PlanetRes1Idx;
					this.PlanetRes1Y = PlanetRes1Y;
					this.PlanetRes1R = PlanetRes1R;

					this.PlanetRes2Idx = PlanetRes2Idx;
					this.PlanetRes2Y = PlanetRes2Y;
					this.PlanetRes2R = PlanetRes2R;

					this.PlanetRes3Idx = PlanetRes3Idx;
					this.PlanetRes3Y = PlanetRes3Y;
					this.PlanetRes3R = PlanetRes3R;




		}	
}
