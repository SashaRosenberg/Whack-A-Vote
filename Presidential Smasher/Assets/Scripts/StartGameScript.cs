using UnityEngine;
using System.Collections;

public class StartGameScript : MonoBehaviour {

    public GameObject whackAMoleLogicObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider c)
    {
        WhackAMoleLogic w = whackAMoleLogicObject.GetComponent<WhackAMoleLogic>();

        if (c.name == "don_coin(Clone)")
        {
            w.startGame(1);
            Destroy(c.gameObject);
            
        } else if (c.name == "hill_coin(Clone)")
        {
            w.startGame(2);
            Destroy(c.gameObject);
        } else if (c.name == "Reg_coin(Clone)")
        {
            w.startGame(0);
            Destroy(c.gameObject);
        }
    }
}
