using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using UnityEngine.Video;

//Custom 8
public partial class Wit3D : MonoBehaviour {

	public Text myHandleTextBox;
	private bool actionFound = false;

    //Above handle function
    public bool[,] itemOptions = new bool[,]{
 	//options order =open door, close door, start engine, stop engine, colour, windows, show engine, video, bonnet, hood 
					{true,true,true,true,true,true,true,true,true,true,true}, //convertlambo
					{true,true,true,true,true,true,true,true,true,true,true}, //orangeLambo
					{false,false,true,true,true,false,true,true,true,true,false}, //Police Car
					{true,true,true,true,true,true,true,true,true,true,true} //Tocus
	};
    private int switch_on;

    public object Case { get; private set; }

    public bool ErrorCheck(int col)
    {
        return itemOptions[carController.selectedIndex, col];
    }

    void showMsg()
    {
        myHandleTextBox.text = "Sorry, that action is unavailable for this vehicle.";
    }

    void Handle (string jsonString) {
		
		if (jsonString != null) {

            jsonString = jsonString.Replace("open:open", "open");
            jsonString = jsonString.Replace("close:close", "close");
            jsonString = jsonString.Replace("start:start", "start");
            jsonString = jsonString.Replace("stop:stop", "stop");
            jsonString = jsonString.Replace("colour:colour", "colour");


            RootObject theAction = new RootObject ();
			Newtonsoft.Json.JsonConvert.PopulateObject (jsonString, theAction);

			if (theAction.entities.open != null) {
				foreach (Open aPart in theAction.entities.open) {
					Debug.Log (aPart.value);
                    if (theAction._text.Contains("open"))
                    {
                        switch (aPart.value)
                        {
                            case "drivers door":
                                if (ErrorCheck (0))
                                {
                                    if (theAction._text.Contains("drivers door"))
                                    {
                                        carController.instance.triggerAnimation("openDriversDoor");
                                    }
                                }
                                else
                                {
                                    showMsg();
                                }
                                break;

                            case "windows":
                                if (ErrorCheck(5))
                                {
                                    if (theAction._text.Contains("windows"))
                                    {
                                        carController.instance.triggerAnimation("openWindows");
                                    }
                                }
                                else
                                {
                                    showMsg();
                                }
                                break;

                            case "hood":
                                if (ErrorCheck(9))
                                {
                                    if (theAction._text.Contains("hood"))
                                    {
                                        carController.instance.triggerAnimation("openHood");
                                    }
                                }
                                else
                                {
                                    showMsg();
                                }
                                break;

                            case "trunk":
                                if (ErrorCheck(10))
                                {
                                    if (theAction._text.Contains("trunk"))
                                    {
                                        carController.instance.triggerAnimation("openTrunk");
                                    }
                                }
                                else
                                {
                                    showMsg();
                                }
                                break;

                            case "bonnet":
                                if (ErrorCheck(8))
                                {
                                    if (theAction._text.Contains("bonnet"))
                                    {
                                        carController.instance.triggerAnimation("openHood");
                                    }
                                }
                                else
                                {
                                    showMsg();
                                }
                                break;

                            case "engine":
                                if (ErrorCheck(6))
                                {
                                    if (theAction._text.Contains("engine"))
                                    {
                                        carController.instance.triggerAnimation("openHood");
                                    }
                                }
                                else
                                {
                                    showMsg();
                                }
                                break;

                            default:
                                showMsg();
                                break;
                        }

                        
                        
                    }
					actionFound = true;
				}
			}
			if (theAction.entities.close != null) {
				foreach (Close aPart in theAction.entities.close) {
					Debug.Log (aPart.value);
                    if (theAction._text.Contains("close"))
                    {
                        switch (aPart.value)
                        {
                            case "drivers door":
                                if (ErrorCheck(1))
                                {
                                    if (theAction._text.Contains("drivers door"))
                                    {
                                        carController.instance.triggerAnimation("closeDriversDoor");
                                    }
                                }
                                else
                                {
                                    showMsg();
                                }
                                break;

                            case "windows":
                                if (ErrorCheck(5))
                                {
                                    if (theAction._text.Contains("windows"))
                                    {
                                        carController.instance.triggerAnimation("closeWindows");
                                    }
                                }
                                else
                                {
                                    showMsg();
                                }
                                break;

                            case "hood":
                                if (ErrorCheck(9))
                                {
                                    if (theAction._text.Contains("hood"))
                                    {
                                        carController.instance.triggerAnimation("closeHood");
                                    }
                                }
                                else
                                {
                                    showMsg();
                                }
                                break;

                            case "trunk":
                                if (ErrorCheck(10))
                                {
                                    if (theAction._text.Contains("trunk"))
                                    {
                                        carController.instance.triggerAnimation("closeTrunk");
                                    }
                                }
                                else
                                {
                                    showMsg();
                                }
                                break;

                            case "bonnet":
                                if (ErrorCheck(8))
                                {
                                    if (theAction._text.Contains("bonnet"))
                                    {
                                        carController.instance.triggerAnimation("closeHood");
                                    }
                                }
                                else
                                {
                                    showMsg();
                                }
                                break;

                            case "engine":
                                if (ErrorCheck(6))
                                {
                                    if (theAction._text.Contains("engine"))
                                    {
                                        carController.instance.triggerAnimation("closeHood");
                                    }
                                }
                                else
                                {
                                    showMsg();
                                }
                                break;

                            default:
                                showMsg();
                                break;


                        }
                    }
					actionFound = true;
				}
			}
            if (theAction.entities.start != null)
            {
                foreach (Start aPart in theAction.entities.start)
                {
                    Debug.Log(aPart.value);
                    if (theAction._text.Contains("start"))
                    {
                        switch (aPart.value)
                        {
                            case "engine":
                                if (ErrorCheck(2))
                                {
                                    if (theAction._text.Contains("engine"))
                                    {
                                        carController.instance.playSound();
                                    }
                                }
                                else
                                {
                                    showMsg();
                                }
                                break;

                            case "video":
                                if (ErrorCheck(7))
                                {
                                    if (theAction._text.Contains("video"))
                                    {
                                        GameObject.Find(colourSwitcher.instance.getCurrentTracked().name + "/activeItems/" + gameController.currentSelectedCar + "/video").GetComponent<VideoPlayer>().Play();
                                    }
                                    }
                                else
                                {
                                    showMsg();
                                }
                                break;

                            default:
                                showMsg();
                                break;
                        }
                    }
                    actionFound = true;
                }
            }
            if (theAction.entities.stop != null)
            {
                foreach (Stop aPart in theAction.entities.stop)
                {
                    Debug.Log(aPart.value);
                    if (theAction._text.Contains("stop"))
                    {
                        switch (aPart.value)
                        {
                            case "engine":
                                if (ErrorCheck(2))
                                {
                                    if (theAction._text.Contains("engine"))
                                    {
                                        carController.instance.stopSound();
                                    }
                                }
                                else
                                {
                                    showMsg();
                                }
                                break;

                            case "video":
                                if (ErrorCheck(7))
                                {
                                    if (theAction._text.Contains("video"))
                                    {
                                        GameObject.Find(colourSwitcher.instance.getCurrentTracked().name + "/activeItems/" + gameController.currentSelectedCar + "/video").GetComponent<VideoPlayer>().Stop();
                                    }
                                }
                                else
                                {
                                    showMsg();
                                }
                                break;

                            default:
                                showMsg();
                                break;
                        }
                    }
                    myHandleTextBox.text = aPart.value;
                    actionFound = true;
                }
            }

            if (theAction.entities.colour != null)
            {
                foreach (Colour aPart in theAction.entities.colour)
                {
                    Debug.Log(aPart.value);
                    if (theAction._text.Contains("colour"))
                    {
                        colourSwitcher.instance.colours(aPart.value);
                    }
                    myHandleTextBox.text = aPart.value;
                    actionFound = true;
                }
            }

            if (!actionFound) {
				myHandleTextBox.text = "Request unknown, please ask a different way.";
			} else {
				actionFound = false;
			}

 		}//END OF IF

 	}//END OF HANDLE VOID

    private bool errorCheck(int v)
    {
        throw new NotImplementedException();
    }
}//END OF CLASS
	

//Custom 9
public class Open {
	public bool suggested { get; set; }
	public double confidence { get; set; }
	public string value { get; set; }
	public string type { get; set; }
}

public class Close {
	public bool suggested { get; set; }
	public double confidence { get; set; }
	public string value { get; set; }
	public string type { get; set; }
}

public class Start
{
    public bool suggested { get; set; }
    public double confidence { get; set; }
    public string value { get; set; }
    public string type { get; set; }
}

public class Stop
{
    public bool suggested { get; set; }
    public double confidence { get; set; }
    public string value { get; set; }
    public string type { get; set; }
}

public class Colour
{
    public bool suggested { get; set; }
    public double confidence { get; set; }
    public string value { get; set; }
    public string type { get; set; }
}

public class Entities {
	public List<Open> open { get; set; }
	public List<Close> close { get; set; }
    public List<Start> start { get; set; }
    public List<Stop> stop { get; set; }
    public List<Colour> colour { get; set; }
}

public class RootObject {
	public string _text { get; set; }
	public Entities entities { get; set; }
	public string msg_id { get; set; }
}