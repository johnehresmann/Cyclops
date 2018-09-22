using UnityEngine;
using System.Collections;
using EasyInputVR.Core;
using DarkTonic.CoreGameKit; 

namespace EasyInputVR.Misc
{

    [AddComponentMenu("EasyInputGearVR/Miscellaneous/FirstPersonTurnAndShoot")]
    public class FirstPersonTurnAndShoot : MonoBehaviour
    {
        [HideInInspector] public GameObject projectile;
        [HideInInspector]public float projectileSpeed;
        [SerializeField]
        [HideInInspector]public float fireDelay;
        [HideInInspector]public GameObject powerUp;
        [HideInInspector]public ScriptableObject[] abilityList;
        [HideInInspector]public Abilities currentAbility;
        [HideInInspector]public ScriptableObject previousAbility;
        [HideInInspector]public ScriptableObject nextAbility;
        public int defaultAbility = 0;
        private bool canFire = true;
        public float buttonSensitivity = 3f;
        float accumulatedRotation = 0f;
        Vector3 rotation;
        public GameObject spawn;

        Transform spawnTransform;

        void OnEnable()
        {
            EasyInputHelper.On_TouchEnd += localOnTouchEnd;
            EasyInputHelper.On_LongTouchEnd += localOnLongTouchEnd;
            EasyInputHelper.On_SwipeDetected += localOnSwipeDetected;
        }

        void OnDestroy()
        {

            EasyInputHelper.On_TouchEnd -= localOnTouchEnd;
            EasyInputHelper.On_LongTouchEnd -= localOnLongTouchEnd;
            EasyInputHelper.On_SwipeDetected -= localOnSwipeDetected;
        }

        void Start()
        {
            
            
            spawnTransform = spawn.transform;

            powerUp = GameObject.Find("PowerUpHolder");
            PowerManagement pwrMng = powerUp.GetComponent<PowerManagement>();
            currentAbility = pwrMng.playerAbility[defaultAbility];

            fireDelay = currentAbility.fireDelay;
            
            projectile = currentAbility.projectile;
            print(currentAbility);
        }

        public void Update()
        {
            rotation = this.transform.rotation.eulerAngles;
            rotation.y = accumulatedRotation;
            this.transform.rotation = Quaternion.Euler(rotation);
        }
    
        /*****************************************
        *****The goal of this is to have a system *
        *****Where we can have abilities unlock by*
        *****Fighting specific bosses. If it is   *
        *****Not unlocked, it should skip to the  *
        *****Next availiable power.***************/
        void localOnTouchEnd(InputTouch touch)
        {
            MasterProjectile plyrScript = FindObjectOfType<MasterProjectile>();

            if (canFire)
            {
                
                currentAbility.fireAbility(projectile, spawnTransform, projectileSpeed);
                StartCoroutine(TimeDelay());
                //plyrScript.fireProjectile(projectile, spawnTransform, projectileSpeed);

                /* Transform newObject = PoolBoss.SpawnOutsidePool(prefabBall.transform, spawnTransform.transform.position, spawnTransform.transform.rotation);
                Rigidbody newRigidBody = newObject.GetComponent<Rigidbody>();
                newRigidBody.AddForce((spawnTransform.forward)*projectileSpeed);  */         

            }        
        }

       private IEnumerator TimeDelay()
        {
            canFire = false;
            yield return new WaitForSeconds(fireDelay);
            canFire = true;

        }

        void localOnLongTouchEnd(InputTouch touch)
        {

        }

        void localOnSwipeDetected(InputTouch touch)
        {
            if (touch.swipeType == EasyInputConstants.SWIPE_TYPE.Left)
            {
                print("Left");

            }
        }
    }
}