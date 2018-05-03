using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    public Slider nitroSlider;
    public Image nitroSliderImage;
    public Slider fuelSlider;
    public Image fuelSliderImage;
    public Transform nitroArrow;
    public Image nitroDisplay;
    public float fuelConsumption;
    float timeToFuelConsumption = 1f;
    float timerFuel;
    bool nitroPresedd;
    Color nitroDisplayColor;
    Color nitroSliderColor;
    Color fuelSliderColor;


    void Start()
    {
        GM = this;
        nitroDisplayColor = nitroDisplay.color;
        nitroSliderColor = nitroSliderImage.color;
        fuelSliderColor = fuelSliderImage.color;
    }
    
    void Update()
    {
        timerFuel += Time.deltaTime;
        if (timerFuel > timeToFuelConsumption)
        {
            DecreaseFuel(fuelConsumption);
            timerFuel = 0;
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            nitroPresedd = !nitroPresedd;
        }
        CarController.carController.nitroPressed = nitroPresedd;

        if (nitroPresedd)
        {
            ChangeNitroColorRed();
        }
        else
        {
            ChangeNitroColorOrigin();
        }

        if (nitroPresedd && CarController.carController.AccelInput > 0.8f)
        {
            fuelConsumption = 5;
            NitroArrowDown(1);
            if (NitroArrow.arrow.sliderNitro.value < 1)
            {
                nitroPresedd = false;
            }
        }
        else
        {
            fuelConsumption = 1;
        }

    }

    public void IncreaseFuel(float fuelValue)
    {
        fuelSlider.value += fuelValue;
        if (fuelSlider.value > 100)
        {
            fuelSlider.value = 100;
        }
    }

    public void DecreaseFuel(float fuelValue)
    {
        fuelSlider.value -= fuelValue;
    }

    public void NitroArrowUp(float value)
    {
        NitroArrow.arrow.value -= value;
    }

    public void NitroArrowDown(float value)
    {
        NitroArrow.arrow.value += value;
    }

    public void ChangeNitroColorRed()
    {
        nitroDisplay.color = Color.Lerp(nitroDisplayColor, Color.red, CarController.carController.AccelInput);
        nitroSliderImage.color = Color.Lerp(nitroSliderColor, Color.red, CarController.carController.AccelInput);
        fuelSliderImage.color = Color.Lerp(fuelSliderColor, Color.red, CarController.carController.AccelInput);

    }

    public void ChangeNitroColorOrigin()
    {
        nitroDisplay.color = nitroDisplayColor;
        nitroSliderImage.color = nitroSliderColor;
        fuelSliderImage.color = fuelSliderColor;

    }
}
