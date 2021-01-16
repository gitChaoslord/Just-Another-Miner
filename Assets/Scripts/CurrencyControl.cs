using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CurrencyControl : MonoBehaviour {


// me to static, borei na to kanei access otidipote, apla anaferontas ton typo Currency.Cash
public static float Cash;
public Text CashText;
public int StartingCash = 10000;
//prestige currency
public static int GalaxyCredits = 10000;
public Text CreditsText;
public Text CreditCostText;
public static float CreditsCost = 20000;

//galaxy value
//public static float Galaxyvalue = 30;
//public Text GvalueText;
public Button SellButton;

// otan ksekinaei to game, bazei sta cash to starting ammount,
void Start(){
	Cash = StartingCash;
	CreditCostText.text = ("Buy 5 Credits for : " + Mathf.RoundToInt(CreditsCost).ToString());
	
	//GalaxyCredits = startingCredits;
}

void Update(){
	//kathe frame kanei update to Cash, isws einai ligo overkill na to kanw kathe frame, isws gia perfomance optimazation na to bgalw sto mellon
	CashText.text = Mathf.RoundToInt(Cash).ToString();
	CreditsText.text = GalaxyCredits.ToString();
	//

	//kanei disable to button
	if(Cash < CreditsCost){
		SellButton.interactable = false;
	}
	else
	{
		SellButton.interactable = true;
	}

}

public void BuyCredits () {
	Cash -= CreditsCost;
	CreditsCost = Mathf.RoundToInt(CreditsCost*1.5f);
	GalaxyCredits += 5;
	CreditCostText.text = ("Buy 5 Credits for : " + Mathf.RoundToInt(CreditsCost).ToString());
	//GalaxyCredits +=  Mathf.RoundToInt(5 + (17* (Galaxyvalue/(100000000))));
	//kapos reset game
	//auto kanei duplicates
	//SceneManager.LoadScene("SampleScene");
	}
}
