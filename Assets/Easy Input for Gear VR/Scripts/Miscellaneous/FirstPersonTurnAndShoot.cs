using UnityEngine;
using System.Collections;
using EasyInputVR.Core;

namespace EasyInputVR.Misc
{

    [AddComponentMenu("EasyInputGearVR/Miscellaneous/FirstPersonTurnAndShoot")]
    public class FirstPersonTurnAndShoot : MonoBehaviour
    {
        
        public float buttonSensitivity = 3f;
        float accumulatedRotation = 0f;
        Vector3 rotation;
        public GameObject spawn;

        Transform spawnTransform;
        private RaycastShootTriggerable rcShoot;
        
        //this decleration will be changing once we begin developing the ability system. This is purely for debug at the moment, do not forget to remove this
        public baseAbility playerAbility;

        void OnEnable()
        {
            // EasyInputHelper.On_LongClick += localOnLongClick;
            // EasyInputHelper.On_QuickClickEnd += localOnQuickEnd;
            // EasyInputHelper.On_DoubleClickEnd += localOnDoubleEnd;
            EasyInputHelper.On_TouchEnd += localOnTouchEnd;
        }

        void OnDestroy()
        {
            // EasyInputHelper.On_LongClick -= localOnLongClick;
            // EasyInputHelper.On_QuickClickEnd -= localOnQuickEnd;
            // EasyInputHelper.On_DoubleClickEnd -= localOnDoubleEnd;
            EasyInputHelper.On_TouchEnd -= localOnTouchEnd;

        }

        void Start()
        {
            spawnTransform = spawn.transform;

            //This will need to be changed later. This is purely for Debug DO NOT FORGET THAT THIS IS NOT PERMANENT
        }

        public void Update()
        {
            rotation = this.transform.rotation.eulerAngles;
            rotation.y = accumulatedRotation;
            this.transform.rotation = Quaternion.Euler(rotation);
        }

        // void localOnQuickEnd(ButtonClick click)
        // {
        //     if (click.button == EasyInputConstants.CONTROLLER_BUTTON.GearVRTrigger)
        //     {
        //         GameObject newObject = (GameObject)Instantiate(prefabBall, spawnTransform.transform.position, spawnTransform.transform.rotation);
        //         Rigidbody newRigidbody = newObject.GetComponent<Rigidbody>();
        //         newRigidbody.AddForce((spawnTransform.forward) * 1000f);
        //     }

        // }

        // void localOnDoubleEnd(ButtonClick click)
        // {
        //     if (click.button == EasyInputConstants.CONTROLLER_BUTTON.GearVRTrigger)
        //     {
        //         GameObject newObject = (GameObject)Instantiate(prefabBall, spawnTransform.transform.position, spawnTransform.transform.rotation);
        //         Rigidbody newRigidbody = newObject.GetComponent<Rigidbody>();
        //         newRigidbody.AddForce((spawnTransform.forward) * 1000f);
        //     }

        // }

        // void localOnLongClick(ButtonClick click)
        // {
        //     if (click.button == EasyInputConstants.CONTROLLER_BUTTON.GearVRTrigger)
        //     {
        //         accumulatedRotation -= buttonSensitivity * Time.deltaTime * 100f;
        //     }
        //     else if (click.button == EasyInputConstants.CONTROLLER_BUTTON.GearVRTouchClick)
        //     {
        //         accumulatedRotation += buttonSensitivity * Time.deltaTime * 100f;
        //     }

        // }

       void localOnTouchEnd(InputTouch touch)
       {
           playerAbility.TriggerAbility();
           
       }
    }
}