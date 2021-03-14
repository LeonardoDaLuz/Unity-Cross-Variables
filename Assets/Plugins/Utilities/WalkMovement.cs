using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkMovement : MonoBehaviour {

    public XPrimitivesRequireds RequiredToStart;
    public XPrimitivesRequireds RequiredToMantain;
  // public xbool grounded;

    [sincronizeWithAnimator]
    public xbool pressingSpace;
    public xfloat hor;
    public xbool grounded;
  //  public xfloat hor2;
    [sincronizeWithAnimator]
    public xint state;

   // public xbool esteAqui;
    public testClasse test;
    //  public testClasse test2;
    [sincronizeWithAnimator]
    public xbool facingRight;
   // public xbool esteAqui;


    [System.Serializable]
   public class testClasse
    {
        public xbool esteAqui;
    }
    void Start () {



    }
	
	// Update is called once per frame
	void Update () {
        pressingSpace.Set(Input.GetMouseButton(0));

        if (RequiredToStart)
        {
            print("FUNCIONANDO");
        }

        GetComponent<XBrain>().velocity2D = Vector2.right;

    }
}
