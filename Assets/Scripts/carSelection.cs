using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSelection : MonoBehaviour
{
    // We create an empty list of gameObjects
    private GameObject[] carList;
    private int currentCar = 0;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        // Count the child gameObjects from the car transform
        carList = new GameObject[transform.childCount];

        // Loop through the child items and fill the list in the correct slots
        for (int i = 0; i < transform.childCount; ++i)
        {
            carList[i] = transform.GetChild(i).gameObject;
        }

        // Deactivate all the gameObjects in the list
        foreach (GameObject gameObj in carList)
        {
            gameObj.SetActive(false);
        }

        // Set the initial GO to be active
        if (carList [0])
        {
            carList[0].SetActive(true);
            if (carList[0].name == "myLamboConvert")
            {
                carList[0].GetComponent<Animator>().SetTrigger("intro");
                GameObject cloudSystem = Instantiate(Resources.Load("cloudParticle")) as GameObject;
                ParticleSystem cloudPuff = cloudSystem.GetComponent<ParticleSystem>();
                cloudPuff.Play();
                cloudPuff.transform.position = new Vector3(22f, 0.5f, 0f);
                Destroy(cloudSystem, 2f);

            }
        }
    }

    public void toggleCars(string direction)
    {
        carList[currentCar].SetActive(false);

        if (direction == "Right")
        {
            currentCar++;
            if (currentCar > carList.Length - 1)
            {
                currentCar = 0;
            }
        }
        else if (direction == "Left")
        {
            currentCar--;
            if(currentCar < 0)
            {
                currentCar = carList.Length - 1;
            }
        }

        carList[currentCar].SetActive(true);
        if (carList[currentCar].name == "myLamboConvert")
        {
            carList[currentCar].GetComponent<Animator>().SetTrigger("intro");

        }
        gameController.currentSelectedCar = carList[currentCar].name;
        GameObject cloudSystem = Instantiate(Resources.Load("cloudParticle")) as GameObject;
        ParticleSystem cloudPuff = cloudSystem.GetComponent<ParticleSystem>();
        cloudPuff.Play();
        cloudPuff.transform.position = new Vector3(22f, 0.5f, 0f);
        Destroy(cloudSystem, 2f);
    }

    public void showPanel()
    {
        panel.SetActive(true);
    }
}
