using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        public float h;
        public float v;
        AudioSource horn;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
            horn = GetComponent<AudioSource>();
        }


         void Update()
        {
            // pass the input to the car!
             h = CrossPlatformInputManager.GetAxis("Horizontal");
             v = CrossPlatformInputManager.GetAxis("Vertical");
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            if (Input.GetKey(KeyCode.C))
            {
                horn.Play();
            }

            if (v == 0) handbrake = 100000;
            else handbrake = 0;
            
            m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
    }
}
