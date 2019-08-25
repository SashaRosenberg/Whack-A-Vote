using UnityEngine;
using System.Collections;
using VRTK;

public class CustomReactor : MonoBehaviour
{


    private Rigidbody Handle;
    private float gravity = -50;
    private Vector3 gravityDirection = new Vector3(0, -1, 0);
    private VRTK_Lever lever;
    private float angle;
    private bool resetable;
    private bool prev_value;
    private Transform startlocation;
    private GameObject parent;
    private GameObject spin1;
    private GameObject spin2;
    private GameObject spin3;
    private SpinScript spinScript1;
    private SpinScript spinScript2;
    private SpinScript spinScript3;
    private SpinLight slotlightScript;
    private int timer;
    private int lighttimer;
    private bool spinning = false;
    private Quaternion winrotation = Quaternion.Euler(new Vector3(60, 0, 0));
    //everything is set by object name
    //i like how clean it feals.
    private Transform spawnpoint;
    public GameObject Coin;
    public GameObject Coin2;
    public GameObject Coin3;
    public GameObject slotlight;

    private void Start()
    {

        GetComponent<VRTK_Control>().defaultEvents.OnValueChanged.AddListener(HandleChange);
        HandleChange(GetComponent<VRTK_Control>().GetValue(), GetComponent<VRTK_Control>().GetNormalizedValue());
        Handle = this.GetComponent<Rigidbody>();
        lever = this.GetComponent<VRTK_Lever>();
        startlocation = this.transform;
        Handle.AddForce(gravityDirection * gravity * 1);
        // set up variables
        parent = this.transform.parent.parent.gameObject;
        spin1 = parent.transform.FindChild("Spin 1").gameObject;
        spinScript1 = spin1.GetComponent<SpinScript>();
        spin2 = parent.transform.FindChild("Spin 2").gameObject;
        spinScript2 = spin2.GetComponent<SpinScript>();
        spin3 = parent.transform.FindChild("Spin 3").gameObject;
        spinScript3 = spin3.GetComponent<SpinScript>();
        slotlight = parent.transform.FindChild("slot_light").gameObject;
        slotlightScript = slotlight.GetComponent<SpinLight>();

       
        spawnpoint = parent.transform.FindChild("SpawnPoint").gameObject.transform;
        //find the spin Wheels
        //spin wheels must be a sibling to the lever

    }

    private void HandleChange(float value, float normalizedValue)
    {       
        angle = value;
        //this gets the change in handle amount.
    }
    void Update()
    {
        if (resetable != prev_value)
        {
            if (resetable == true)
            {
                slot_pulled();
                timer = 0;
                //this creates a pulse evertime resetable changes
            }
            prev_value = resetable;
        }
        if (angle > 45)
        {
            resetable = true;

        }
        if (angle < 45)
        {
            resetable = false;
        }
        if (angle > 20)
        {
            Handle.AddForce(gravityDirection * gravity * 1);
            //this allows the lever to jump back to its resting state.
        }
        // snapback (the other type)
        if (spinning == true)
        {
            if (timer == 50)
            {

                spinScript3.stop();
                spin3.transform.localRotation = winrotation;
                //stop spinning and rotate to a 7
            }
            if (timer == 75)
            {
                spinScript2.stop();
                spin2.transform.localRotation = winrotation;
            }
            if (timer == 100)
            {
                //start the red light and jackpot audio
                gameObject.GetComponent<AudioSource>().Play();
                Debug.Log("start light");
                lighttimer = 1;
                slotlight.SetActive(true);
                slotlightScript.enabled = true;
                spinScript1.stop();
                spinning = false;
                spin1.transform.localRotation = winrotation;

                for (int i = 0; i < 10; i++)
                {
                    //spawn coins at spawnpoint
                    float r = Random.value;
                    GameObject coin2 = (GameObject)Instantiate((r <= 0.33 ? Coin : (r <= 0.66 ? Coin2 : Coin3)), spawnpoint.position, spawnpoint.rotation);
                }
            }
            timer++;
            //incrament the timer, probably should have used DeltaTime but its not exactly relying on perfect timing plus this is efficient
        }
        if (lighttimer > 0)
           {
                lighttimer++;
            }
        if (lighttimer == 500)
            {
                Debug.Log("here");
                lighttimer = 0;
                slotlight.SetActive(false);
                slotlightScript.enabled = false;
            }

    }

    void slot_pulled()
    {
        Debug.Log("pulled");
        spinScript1.speed = 1800;
        spinScript2.speed = 1800;
        spinScript3.speed = 1800;
        spinning = true;
        // Play slot reeling audio
        spinScript2.PlaySpinAudio();

        //you spin me right right round right round like a ... eh i forgot the rest.
        //HURRICANE! Here I am! Rock you like a HURRICANE! xD

    }

}