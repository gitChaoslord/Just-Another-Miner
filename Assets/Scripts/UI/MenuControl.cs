using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour {



//bottom menu + Planets	
public GameObject VisiblePanel;
//resource menu
public GameObject VisibleInnerResourcePanel;
public GameObject HighlightedButton;
//production menu
public GameObject VisibleInnerProductionPanel;

//research menu
public GameObject VisibleResearchTree;





// 	GIA BOTTOM MENU NAVIGATION
public void ShowMenuPanel(Transform PanelToShow) {
// 	an einai to idio panel, na to kleinei, allios na alalzei panel
	if(VisiblePanel == PanelToShow.gameObject && PanelToShow.gameObject.activeSelf == true)
	{
	VisiblePanel.SetActive(false);
	}
	else
	//	(on click) kanei disable to current panel kai 'allazei' sto epomeno panel
	{
	VisiblePanel.SetActive(false);
	VisiblePanel = PanelToShow.gameObject;
	VisiblePanel.SetActive(true);
	}
}

// GIA INNER MENU NAVIGATION (resourcemenu ores/bars/items)
public void ShowInnerResourcePanel(Transform InnerPanelToShow) {
	
	if(VisibleInnerResourcePanel == InnerPanelToShow.gameObject && InnerPanelToShow.gameObject.activeSelf == true)
	{
		// sta eswterika panel thelw na uparxei panta ena anoikto, to last used pio sugkekrimena
	//VisibleInnerPanel.SetActive(false);
	}
	else
	{
	VisibleInnerResourcePanel.SetActive(false);
	VisibleInnerResourcePanel = InnerPanelToShow.gameObject;
	VisibleInnerResourcePanel.SetActive(true);
	}

}
// >> alla gia production menu
public void ShowInnerProductionPanel(Transform InnerPanelToShow) {

	if(VisibleInnerProductionPanel == InnerPanelToShow.gameObject && InnerPanelToShow.gameObject.activeSelf == true)
	{
	//VisibleInnerPanel.SetActive(false);
	}
	else
	{
	VisibleInnerProductionPanel.SetActive(false);
	VisibleInnerProductionPanel = InnerPanelToShow.gameObject;
	VisibleInnerProductionPanel.SetActive(true);
	}

}
// kanei color to selected button tou selected category kai den allazei xrwma ama klikareis alou
public void SelectedResourceButton(GameObject ButtonToHighlight) {

	if(HighlightedButton == ButtonToHighlight.gameObject )
	{
		//HighlightedButton.GetComponent<Image>().color = Color.red;
	}
	else
	{
		HighlightedButton.GetComponent<Image>().color = new Color32(245,245,245,255);
		HighlightedButton = ButtonToHighlight;
		HighlightedButton.GetComponent<Image>().color =  new Color32(206,233,233,255);
	}

}
public void SelectedProductionButton(GameObject ButtonToHighlight) {
}


public void ShowResearchTree(Transform InnerTreeToShow){
		if(VisibleResearchTree == InnerTreeToShow.gameObject && InnerTreeToShow.gameObject.activeSelf == true)
	{
		// sta eswterika panel thelw na uparxei panta ena anoikto, to last used pio sugkekrimena
	//VisibleInnerPanel.SetActive(false);
	}
	else
	{
	VisibleResearchTree.SetActive(false);
	VisibleResearchTree = InnerTreeToShow.gameObject;
	VisibleResearchTree.SetActive(true);
	}
}




}
