using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smelter {

	public int SmelterIndex;
	public int Duration;
	public float CurrentTime;
	public Sprite OutputIcon;
	public bool IsSmelting;
	public int CurrentRecipe;

	public Smelter(int SmelterIndex,int Duration,float CurrentTime,Sprite OutputIcon,bool IsSmelting,int CurrentRecipe){
			this.SmelterIndex = SmelterIndex;
			this.CurrentTime = CurrentTime;
			this.Duration = Duration;
			this.OutputIcon = OutputIcon;
			this.IsSmelting = IsSmelting;
			this.CurrentRecipe = CurrentRecipe;

	}


}
