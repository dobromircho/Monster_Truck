using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform[] nitroPoints;
    public Transform[] fuelPoints;
    public Transform[] enemyPoints;
    public GameObject nitroBottle;
    public GameObject fuelBarrel;
    public GameObject enemy;
    public GameObject fullMap;
    public GameObject mainCamera;
    public GameObject rain;
    public GameObject[] checkFlags;
    public GameObject canvas;
    public GameObject tempCam;
    public Transform player;

    public static GameManager GM;
    public Slider nitroSlider;
    public Image nitroSliderImage;
    public Slider fuelSlider;
    public Image fuelSliderImage;
    public Transform nitroArrow;
    public Image nitroDisplay;
    public float fuelConsumption;
    public float timeToFuelConsumption = 1f;
    float timerFuel;
    float timerNitroInst;
    float timerFuelInst;
    float timerEnemyInst;
    AudioSource music;

    bool isGameStarted;
    bool nitroPresedd;
    bool isFullMap;
    Color nitroDisplayColor;
    Color nitroSliderColor;
    Color fuelSliderColor;
    Transform currentNitroPoint;

    void Start()
    {
        GM = this;
        nitroDisplayColor = nitroDisplay.color;
        nitroSliderColor = nitroSliderImage.color;
        fuelSliderColor = fuelSliderImage.color;
        isFullMap = false;
        music = GetComponent<AudioSource>();
        canvas.SetActive(false);
        
    }
    
    void Update()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            if (!isGameStarted)
            {
                tempCam.SetActive(false);
                InstantiateCamera();
                InstantiateRain();
                InstantiateCheckFlags();

                canvas.SetActive(true);

                isGameStarted = true;
            }
            

            if (Input.GetKeyUp(KeyCode.M))
            {
                isFullMap = !isFullMap;
            }
            fullMap.SetActive(isFullMap);
            if (GameObject.FindWithTag("nitro") == null)
            {
                timerNitroInst += Time.deltaTime;
                if (timerNitroInst > 3)
                {
                    InstantiateNitroBottle();
                    timerNitroInst = 0;
                }
            }

            if (GameObject.FindWithTag("barrel") == null)
            {
                timerFuelInst += Time.deltaTime;
                if (timerFuelInst > 3)
                {
                    InstantiateFuelBarrel();
                    timerFuelInst = 0;
                }
            }

            if (GameObject.FindWithTag("enemy") == null)
            {
                timerEnemyInst += Time.deltaTime;
                if (timerEnemyInst > 3)
                {
                    InstantiateEnemy();
                    timerEnemyInst = 0;
                }
            }

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
            if (CarController.carController != null)
            {
                CarController.carController.nitroPressed = nitroPresedd;
            }

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
                NitroArrowDown(0);
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
        if (fuelSlider.value < 1)
        {
            Time.timeScale = 0.1f;
        }
        else
        {
            Time.timeScale = 1;
        }
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

    public void InstantiateNitroBottle()
    {
        for (int i = 0; i < nitroPoints.Length; i++)
        {
            Instantiate(nitroBottle, nitroPoints[i].position, Quaternion.identity);
        }
    }

    public void InstantiateFuelBarrel()
    {
        for (int i = 0; i < fuelPoints.Length; i++)
        {
            Instantiate(fuelBarrel, fuelPoints[i].position, Quaternion.identity);
        }
    }

    public void InstantiateEnemy()
    {
        for (int i = 0; i < enemyPoints.Length; i++)
        {
            Instantiate(enemy, enemyPoints[i].position, Quaternion.identity);
        }
    }

    public void InstantiateCamera()
    {
        Instantiate(mainCamera);
    }

    public void InstantiateRain()
    {
        Instantiate(rain);
    }

    public void InstantiateCheckFlags()
    {
        for (int i = 0; i < checkFlags.Length; i++)
        {
            Instantiate(checkFlags[i]);
        }
        
    }

    public void PlayMusic()
    {
        music.Play();
    }
}
