using UnityEngine;
using System.Collections;
using EasyInputVR.Core;
using DarkTonic.CoreGameKit;

namespace EasyInputVR.Misc
{

    [AddComponentMenu("EasyInputGearVR/Miscellaneous/FirstPersonTurnAndShoot")]
    public class FirstPersonTurnAndShoot : MonoBehaviour
    {
        public GameObject prefabBall;
        public float projectileSpeed;
        [SerializeField]
        public float fireDelay;
        private bool canFire = true;
        public float buttonSensitivity = 3f;
        float accumulatedRotation = 0f;
        Vector3 rotation;
        public GameObject spawn;

        Transform spawnTransform;

        void OnEnable()
        {
            EasyInputHelper.On_TouchEnd += localOnTouchEnd;
            EasyInputHelper.On_LongTouchStart += localOnLongTouchStart;
            EasyInputHelper.On_LongTouchEnd += localOnLongTouchEnd;        }

        void OnDestroy()
        {

            EasyInputHelper.On_TouchEnd -= localOnTouchEnd;
            EasyInputHelper.On_LongTouchStart -= localOnLongTouchStart;
            EasyInputHelper.On_LongTouchEnd -= localOnLongTouchEnd;
        }

        void Start()
        {
            spawnTransform = spawn.transform;
        }

        public void Update()
        {
            rotation = this.transform.rotation.eulerAngles;
            rotation.y = accumulatedRotation;
            this.transform.rotation = Quaternion.Euler(rotation);
        }

        void localOnQuickEnd(ButtonClick click)
        {
            if (click.button == EasyInputConstants.CONTROLLER_BUTTON.GearVRTrigger)
            {
                /* GameObject newObject = (GameObject)Instantiate(prefabBall, spawnTransform.transform.position, spawnTransform.transform.rotation);
                Rigidbody newRigidbody = newObject.GetComponent<Rigidbody>();
                newRigidbody.AddForce((spawnTransform.forward) * 1000f); */
            }

        }       

        void localOnTouchEnd(InputTouch touch)
        {
            if (canFire)
            {
                Transform newObject = PoolBoss.SpawnOutsidePool(prefabBall.transform, spawnTransform.transform.position, spawnTransform.transform.rotation);
                Rigidbody newRigidBody = newObject.GetComponent<Rigidbody>();
                newRigidBody.AddForce((spawnTransform.forward)*projectileSpeed);             

            }            
        }

       private IEnumerator TimeDelay()
        {
            canFire = false;
            yield return new WaitForSeconds(fireDelay);
            canFire = true;

        }

        void localOnLongTouchStart(InputTouch touch)
        {

        }

        void localOnLongTouchEnd(InputTouch touch)
        {

        }
    }
}