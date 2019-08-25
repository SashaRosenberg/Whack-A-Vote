using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using VRTK;

public class WritingScriptForPaper : MonoBehaviour {
    private bool started;
    private bool inside;
    public List<Vector3> LinePoints = new List<Vector3>();
    private int numberoflines = 0;
    private GameObject crayon;
    private LineRenderer line;
    private LineRenderer line2;
    private Color colour;
    private RaycastHit hit;
    private Vector3 temp;
    public GameObject CamerRig;
    private GameObject left;
    private VRTK_ControllerEvents leftevent;
    private bool lefton;
    private GameObject right;
    private VRTK_ControllerEvents rightevent;
    private bool righton;
    public GameObject MoveRigToPoint;
    public Color purple = new Color(128, 0, 128);


    void Start()
    {
        left = CamerRig.transform.FindChild("Controller (left)").gameObject;
        leftevent = left.GetComponent<VRTK_ControllerEvents>();
        right = CamerRig.transform.FindChild("Controller (right)").gameObject;
        rightevent = right.GetComponent<VRTK_ControllerEvents>();
    }
    // Update is called once per frame
    void Update()
    {

        lefton = leftevent.triggerPressed;

        righton = rightevent.triggerPressed;
      

        if (inside == true)
        {
            //if the crayon is inside the box
            if (Physics.Raycast(crayon.transform.position, new Vector3(0, -1, 0), out hit, 100))
            {
                //This raycasts down to allow drawing
                if (hit.transform.name == "ThisIsPaper")
                {
                    temp = hit.point;
                    Debug.DrawLine(hit.point, crayon.transform.position);


                    LinePoints.Add(temp);
                    numberoflines++;
                    if (numberoflines > 1)
                    {


                        line2.SetVertexCount(numberoflines);
                        for (int i = 0; i <= numberoflines - 1; i++)
                        {
                            line2.SetPosition(i, LinePoints[i]);
                        }
                        //this ensures the line follows the crayon
                    }
                }
                else
                {
                    if (Physics.Raycast(crayon.transform.position, new Vector3(0, 1, 0), out hit, 100))
                    {
                        //This raycasts down to allow drawing
                        if (hit.transform.name == "ThisIsPaper")
                        {
                            temp = hit.point;
                            Debug.DrawLine(hit.point, crayon.transform.position);



                            LinePoints.Add(temp);
                            numberoflines++;
                            if (numberoflines > 1)
                            {


                                line2.SetVertexCount(numberoflines);
                                for (int i = 0; i <= numberoflines - 1; i++)
                                {
                                    line2.SetPosition(i, LinePoints[i]);
                                }
                                //this ensures the line follows the crayon
                            }
                        }


                    }
                }
            }

            else
            {


                //if the crayon is inside the box
                if (Physics.Raycast(crayon.transform.position, new Vector3(0, -1, 0), out hit, 100))
                {
                    //This raycasts down to allow drawing
                    if (hit.transform.name == "ThisIsPaper")
                    {
                        temp = hit.point + new Vector3(0, -0.5f, 0);
                        Debug.DrawLine(hit.point, crayon.transform.position);



                        LinePoints.Add(temp);
                        numberoflines++;
                        if (numberoflines > 1)
                        {


                            line2.SetVertexCount(numberoflines);
                            for (int i = 0; i <= numberoflines - 1; i++)
                            {
                                line2.SetPosition(i, LinePoints[i]);
                            }
                            //this ensures the line follows the crayon
                        }
                    }


                }


            }
                }
                
            }
        



    
	
    void OnTriggerEnter(Collider col)
    {
        if (started == false) {
            if (col.tag == "Crayon")
            {
                GameObject obj;
                obj = col.transform.FindChild("Child").gameObject;
                line2 = this.gameObject.AddComponent<LineRenderer>();
                //generates a linerenderer and makes it the appropriate colour
                line2.SetWidth(0.01f, 0.01f);


                crayon = obj;
                inside = true;
                //differenciate colours
                if (col.gameObject.name == "Cylinder.004")
                    colour = Color.yellow;
                if (col.gameObject.name == "Cylinder.003")
                    colour = Color.green;
                if (col.gameObject.name == "Cylinder.006")
                    colour = Color.red;
                if (col.gameObject.name == "Cylinder.002")
                    colour = Color.blue;
                if (col.gameObject.name == "Cylinder.005")
                    colour = purple;

                //line2.SetColors(colour,colour);
                line2.material.color = colour;
                started = true;
            }

        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Crayon")
        {
            //assign these variables to move the camerarig to the game start point
            StartCoroutine("Example");
        }
    }
    IEnumerator Example()
    {
       
        yield return new WaitForSeconds(2);
          CamerRig.transform.position = MoveRigToPoint.transform.position;
            Destroy(line2);
            LinePoints.Clear();
    }
}
