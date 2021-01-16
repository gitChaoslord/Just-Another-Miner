using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellScript : MonoBehaviour {

	
	public GameObject SellSlider;
	public float SellAmount;
	public int SellAmountInt;

	public static int SellOreIndex;
	public static int SellBarIndex;
	public static int SellItemIndex;

	public Text SellSliderText;

	public void SellOre(){
		//works flawlessly
		//Debug.Log(SellIndex);
		//Debug.Log(OreControl.Ores[SellIndex].OreAmount );

		if(OreControl.Ores[SellOreIndex].OreAmount == 0){
			// do nothing
		}
		else
		{
			if(SellSlider.GetComponent<Slider>().value == 0){
				OreControl.Ores[SellOreIndex].OreAmount -= 1;
				CurrencyControl.Cash += OreControl.Ores[SellOreIndex].OreValue;
			}
			else
			{
			SellAmount = ((Mathf.Abs(SellSlider.GetComponent<Slider>().value / 10)) * OreControl.Ores[SellOreIndex].OreAmount);
			SellAmountInt = Mathf.RoundToInt(SellAmount);
			CurrencyControl.Cash += (SellAmountInt * OreControl.Ores[SellOreIndex].OreValue);
			OreControl.Ores[SellOreIndex].OreAmount -= SellAmountInt;

			// works flawlessly, isws na valw kapou na to kanei display
			// ti periseuh
			//Debug.Log("- " +OreControl.Ores[SellIndex].OreAmount+ " " + OreControl.Ores[SellIndex].OreName);
			//posa lefta peira
			//Debug.Log("+" + (SellAmountInt * OreControl.Ores[SellIndex].OreValue));
			
			}
		}
	}

	
	public void SellBar(){


		if(BarControl.Bars[SellBarIndex].BarAmount == 0) {
			// do nothing
		}
		else
		{
			if(SellSlider.GetComponent<Slider>().value == 0){
				BarControl.Bars[SellBarIndex].BarAmount -= 1;
				CurrencyControl.Cash += BarControl.Bars[SellBarIndex].BarValue;
			}
			else
			{
			SellAmount = ((Mathf.Abs(SellSlider.GetComponent<Slider>().value / 10)) * BarControl.Bars[SellBarIndex].BarAmount);
			SellAmountInt = Mathf.RoundToInt(SellAmount);
			CurrencyControl.Cash += (SellAmountInt * BarControl.Bars[SellBarIndex].BarValue);
			BarControl.Bars[SellBarIndex].BarAmount -= SellAmountInt;
			}
		}
	}
		public void SellItem(){


		if(ItemControl.Items[SellItemIndex].ItemAmount == 0) {
			// do nothing
		}
		else
		{
			if(SellSlider.GetComponent<Slider>().value == 0){
				ItemControl.Items[SellItemIndex].ItemAmount -= 1;
				CurrencyControl.Cash += ItemControl.Items[SellItemIndex].ItemValue;
			}
			else
			{
			SellAmount = ((Mathf.Abs(SellSlider.GetComponent<Slider>().value / 10)) * ItemControl.Items[SellItemIndex].ItemAmount);
			SellAmountInt = Mathf.RoundToInt(SellAmount);
			CurrencyControl.Cash += (SellAmountInt * ItemControl.Items[SellItemIndex].ItemValue);
			ItemControl.Items[SellItemIndex].ItemAmount -= SellAmountInt;
			}
		}

	}


	// Update is called once per frame
	void Update () {
		//na valw isws popup text me mikro duration?

		SellSliderText.GetComponent<Text>().text = ("  " + (SellSlider.GetComponent<Slider>().value) * 10) + " % ";
		
	}
}
