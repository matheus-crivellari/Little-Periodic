using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalBond : MonoBehaviour {

    public static int Bonded = 1;
    public static int NotBonded = 0;

    private Transform otherTransform = null;

    [SerializeField]
    private ChemicalBond otherElement = null;

    private int bondState = 0;

    private void Start()
    {
        if(otherElement)
            otherTransform = otherElement.GetComponent<Transform>();

        OnNotBonded();
    }

    private void Update()
    {
        if (otherTransform)
        {
            float distance = Vector3.Distance(transform.position, otherTransform.position);

            /*if(gameObject.name == "Hydrogene2")
                Debug.Log(distance);*/

            if (distance <= 1.2f)
            {
                if(bondState == NotBonded)
                {
                    bondState = Bonded;
                    OnBonded();
                }
            }
            else{
                if (bondState == Bonded)
                {
                    bondState = NotBonded;
                    OnNotBonded();
                }
            }
        }
    }

    /**
     * Fired when this chemical element and 
     * other are bonded. That is, when they are 1 unit
     * or less closer to each other.
     * 
     * Fired in the frame the distance becomes 1 or less.
     */
    public void OnBonded()
    {
        Debug.Log("Bonded! "+gameObject.name);
    }

    /**
     * Fired when this chemical element and 
     * other are not bonded. That is, when 
     * they are more than 1 unit far from each 
     * other.
     * 
     * Fired in the frame the distance becomes more than 1.
     */
    public void OnNotBonded()
    {
        Debug.Log("NotBonded! " + gameObject.name);
    }
}
