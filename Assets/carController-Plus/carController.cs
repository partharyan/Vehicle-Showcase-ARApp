using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{

    Animator anim;
    AudioSource audio;

    //Car Controller
    //above awake
    public static int selectedIndex = 0;

    public static carController instance;

    //Create a cloned object so we can access the functions
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Use this for initialization
    void Start()
    {

        //Loop through the child items activating the correct item by name
        for (int i = 0; i < transform.childCount; ++i)
        {

            //Check the current selected item and activate
            if (transform.GetChild(i).gameObject.name == gameController.currentSelectedCar)
            {
                transform.GetChild(i).gameObject.SetActive(true);

                //Inside Start
                selectedIndex = i;

                //Get the animator componant from the active item
                anim = transform.GetChild(i).gameObject.GetComponent<Animator>();
            }
            else
            {
                //Deactivate all other cars
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }


    }

    //Called from _Handle
    public void triggerAnimation(string action)
    {
        anim = GameObject.Find("/UserDefinedTarget-1/activeitems/" + gameController.currentSelectedCar).GetComponent<Animator>();
        anim.SetTrigger(action);
    }

    //Called from _Handle
    public void showMessage()
    {
        //TODO
    }

    public void playSound()
    {
        audio = GameObject.Find("/UserDefinedTarget-1/activeitems/" + gameController.currentSelectedCar).GetComponent<AudioSource>();
        audio.Play();
    }

    public void stopSound()
    {
        audio = GameObject.Find("/UserDefinedTarget-1/activeitems/" + gameController.currentSelectedCar).GetComponent<AudioSource>();
        audio.Stop();
    }

}
