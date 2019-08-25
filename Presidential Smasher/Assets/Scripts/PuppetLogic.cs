using UnityEngine;
using System.Collections;

public class PuppetLogic : MonoBehaviour {

    public GameObject whackAMoleLogicObject;
    public float maxYSpeedForHit = 0.1f;
    public float timeToHoldInAir = 1f;
    public bool isRewardHit = true;
    public GameObject smashParticlePrefab;
    public GameObject hillaryObject;
    public GameObject trumpObject;
    public GameObject pepeObject;
    public GameObject sealObject;

    private WhackAMoleLogic whackAMoleLogic;
    private bool canBeHit = false;
    private bool goingUp = false;
    private float timeInAir = 0f;
    private Rigidbody rigidbody;
    private Vector3 maxHitVelocity;
    private bool isPenalty = false;
    private bool isActive = false;

    public float heightplane = 0.95f;
    private Vector3 start;

	void Start () {
        rigidbody = this.GetComponent<Rigidbody>();
        whackAMoleLogic = whackAMoleLogicObject.GetComponent<WhackAMoleLogic>();
        Instantiate(smashParticlePrefab, new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), Quaternion.identity);
        start = this.transform.position;
    }

    void FixedUpdate()
    {   
        if (Vector3.Distance(start,this.transform.position) > 0.5)
        {
            this.transform.position = start;
        }

        if (goingUp)
        {
            if (this.transform.localPosition.y >= heightplane - 0.05f) //for FP rounding errors..
            {
                this.transform.localPosition = new Vector3(this.transform.localPosition.x, heightplane, this.transform.localPosition.z);
                //hold it in air for a second
                rigidbody.useGravity = false;
                rigidbody.velocity = new Vector3(0, 0, 0);
                timeInAir += Time.deltaTime;
                if (timeInAir > timeToHoldInAir)
                {
                    goingUp = false;
                    rigidbody.useGravity = true;
                    timeInAir = 0;
                }
            }
        } else
        {
            //Debug.Log("Going down!");
            rigidbody.useGravity = true;
            if (rigidbody.velocity.y > 0.1f)
            {
                canBeHit = true;
            }
            else
            {
                canBeHit = false;
            }
        }
    }

    public void activatePuppet(bool isPenalty, bool isTrump)
    {
        if (isActive)
            return;

        isActive = true;
        trumpObject.SetActive(false);
        hillaryObject.SetActive(false);
        pepeObject.SetActive(false);
        sealObject.SetActive(false);

        if (isPenalty)
        {
            if (Random.Range(0,100) >= 95)
            {
                sealObject.SetActive(true);
            } else
            {
                pepeObject.SetActive(true);
            }
        } else
        {
            if (isTrump)
            {
                trumpObject.SetActive(true);
            } else
            {
                hillaryObject.SetActive(true);
            }
        }

        this.isPenalty = isPenalty;
        this.GetComponent<Rigidbody>().isKinematic = false;
        this.GetComponent<Collider>().enabled = true;
        canBeHit = true;
        goingUp = true;
        rigidbody.AddForce(new Vector3(0, 2.5f, 0), ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (canBeHit)
        {
            Debug.Log("<color=cyan>Got collision from: " + collision.gameObject.tag + "</color>");
            if (collision.gameObject.tag == "Hammer")
            {
                // Play random collision.gameObject.sfxTracks
                collision.gameObject.GetComponent("WeaponScripts").SendMessage("playHitAudio");

                Debug.Log(collision.relativeVelocity);
                //whackAMoleLogic.hammer.GetComponent<Hammer>().doVibrate();
                //register the hit
                Instantiate(smashParticlePrefab, new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), Quaternion.identity);
                goingUp = false;
                canBeHit = false;
                if (isPenalty)
                {
                    if (sealObject.active)
                        sealObject.GetComponent<AudioSource>().Play();
                    else
                        pepeObject.GetComponent<AudioSource>().Play();
                    whackAMoleLogic.addPenalty();
                }
                else
                {
                    whackAMoleLogic.addReward();
                }
                //add a downward force too.
                rigidbody.AddForce(new Vector3(0, -2.5f, 0), ForceMode.Impulse);
            }
        }
    }

    public void stopPlaneHit(bool isHeightPlane)
    {
        //Debug.Log("Got a stop plane hit!");
        if (isHeightPlane)
        {
            //Debug.Log("Hit on height plane");
            this.GetComponent<PuppetLogic>().canBeHit = false;
        }
        else
        {
            //Debug.Log("Hit regular stop");
            isActive = false;
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<PuppetLogic>().canBeHit = false;
            whackAMoleLogic.reactivatePuppetForHitting(this.gameObject);
        }
    }


    }
