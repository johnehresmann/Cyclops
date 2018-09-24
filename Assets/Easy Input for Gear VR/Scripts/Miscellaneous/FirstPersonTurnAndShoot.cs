using UnityEngine;
using System.Collections;
using EasyInputVR.Core;
using DarkTonic.CoreGameKit; 

namespace EasyInputVR.Misc
{

    [AddComponentMenu("EasyInputGearVR/Miscellaneous/FirstPersonTurnAndShoot")]
    public class FirstPersonTurnAndShoot : MonoBehaviour
    {
        #region Projectile Variables - Controlled in the individual Scripted Objects
        
        [HideInInspector] public GameObject projectile;
        [HideInInspector]public float projectileSpeed;
        [SerializeField]
        [HideInInspector]public float fireDelay;
        [HideInInspector]public GameObject powerUp;
        [HideInInspector]public ScriptableObject[] abilityList;
        [HideInInspector]public Abilities currentAbility;
        [HideInInspector]public ScriptableObject previousAbility;
        [HideInInspector]public ScriptableObject nextAbility;
        [HideInInspector]bool isLongTouch;
        [HideInInspector]bool isDoubleTouch;
        #endregion
        
        
        public int defaultAbility = 0;
         PowerManagement pwrMng;
        int currentAbilityID;
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
            EasyInputHelper.On_LongTouch += localOnLongTouch;
            EasyInputHelper.On_DoubleTouchEnd += localOnDoubleTouchEnd;
        }

        void OnDestroy()
        {

            EasyInputHelper.On_TouchEnd -= localOnTouchEnd;
            EasyInputHelper.On_LongTouchEnd -= localOnLongTouchEnd;
            EasyInputHelper.On_SwipeDetected -= localOnSwipeDetected;
            EasyInputHelper.On_LongTouch -= localOnLongTouch;
            EasyInputHelper.On_DoubleTouchEnd -= localOnDoubleTouchEnd;
        }

        void Start()
        {
            spawnTransform = spawn.transform;

            powerUp = GameObject.Find("PowerUpHolder");
            pwrMng = powerUp.GetComponent<PowerManagement>();
            currentAbilityID = defaultAbility;
            this.AbiltyChecker();
            
        }

        public void Update()
        {
            rotation = this.transform.rotation.eulerAngles;
            rotation.y = accumulatedRotation;
            this.transform.rotation = Quaternion.Euler(rotation);

            this.AbiltyChecker();

            //DEBUG CODE
            if (Input.GetKeyDown("r"))
            {
                currentAbilityID = 0;
                print("Pressed R");
            }
            
        }
    
        /*****************************************
        *****The goal of this is to have a system *
        *****Where we can have abilities unlock by*
        *****Fighting specific bosses. If it is   *
        *****Not unlocked, it should skip to the  *
        *****Next availiable power.***************/
        void localOnTouchEnd(InputTouch touch)
        {
            
              
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
                if(currentAbilityID >= pwrMng.playerAbility.Length)
                {
                    currentAbilityID = 0;
                }
                else
                {
                    currentAbilityID++;
                }
            }

           else if (touch.swipeType == EasyInputConstants.SWIPE_TYPE.Right)
            {
                currentAbilityID--;
            }
        }

        void localOnLongTouch(InputTouch touch)
        {
            MasterProjectile plyrScript = FindObjectOfType<MasterProjectile>();
             projectileSpeed = currentAbility.pSpeed;

            if(isLongTouch)
            {
                if (canFire)
                {
                    
                    currentAbility.fireAbility(projectile, spawnTransform, projectileSpeed);
                    StartCoroutine(TimeDelay());
                    //plyrScript.fireProjectile(projectile, spawnTransform, projectileSpeed);

                    /* Transform newObject = PoolBoss.SpawnOutsidePool(prefabBall.transform, spawnTransform.transform.position, spawnTransform.transform.rotation);
                    Rigidbody newRigidBody = newObject.GetComponent<Rigidbody>();
                    newRigidBody.AddForce((spawnTransform.forward)*projectileSpeed);  */         

                }
            } else
            {
                Debug.Log("Not Long Touch");
            }

        }

        void localOnDoubleTouchEnd (InputTouch touch)
        {
            MasterProjectile plyrScript = FindObjectOfType<MasterProjectile>();
             projectileSpeed = currentAbility.pSpeed;

            if(isDoubleTouch)
            {
                if (canFire)
                {
                    
                    currentAbility.fireAbility(projectile, spawnTransform, projectileSpeed);
                    StartCoroutine(TimeDelay());
                    //plyrScript.fireProjectile(projectile, spawnTransform, projectileSpeed);

                    /* Transform newObject = PoolBoss.SpawnOutsidePool(prefabBall.transform, spawnTransform.transform.position, spawnTransform.transform.rotation);
                    Rigidbody newRigidBody = newObject.GetComponent<Rigidbody>();
                    newRigidBody.AddForce((spawnTransform.forward)*projectileSpeed);  */         

                }
            } else
            {
                Debug.Log("Not Quick Touch");
            }
        }

        public void AbiltyChecker()
        {
        
            currentAbility = pwrMng.playerAbility[currentAbilityID];
            isLongTouch = currentAbility.isLongTouch;
        isDoubleTouch = currentAbility.isDoubleTouch;
           

            fireDelay = currentAbility.fireDelay;
            
            projectile = currentAbility.projectile;
            print(currentAbility);
            print(currentAbilityID);
        }
    }
}