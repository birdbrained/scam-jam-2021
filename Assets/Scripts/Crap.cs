using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CrapCategory
{
    CC_NULL = 0,
    CC_Sports = 1,
    CC_Food = 2,
    CC_KnickKnack = 3,
    CC_Electronic = 4,
    CC_Clothes = 5,
    CC_Kitchenware = 6,
//    CC_PetRelated = 7,
    CC_Games = 8,
    CC_Furniture = 9
};

public class Crap
{
    //[SerializeField]
    private int crapID = 0;
    public int CrapID
    {
        get
        {
            return crapID;
        }
    }
    //[SerializeField]
    private string crapName = "undefined";
    public string CrapName
    {
        get
        {
            return crapName;
        }
    }
    //[SerializeField]
    private string crapDescription = "undefined";
    public string CrapDescription
    {
        get
        {
            return crapDescription;
        }
    }
    //[SerializeField]
    private CrapCategory crapType = CrapCategory.CC_NULL;
    public CrapCategory CrapType
    {
        get
        {
            return crapType;
        }
    }
    //[SerializeField]
    private float crapMsrp = 0.00f;
    public float CrapMsrp
    {
        get
        {
            return crapMsrp;
        }
    }
    //[SerializeField]
    private string imageFilepath = "Sprites/none";
    //[SerializeField]
    private Sprite imageSprite;

    // Start is called before the first frame update
    /*void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/

    public void SetupCrap(int id, string name, string desc, CrapCategory type, float msrp, string imgFilepath)
    {
        crapID = id;
        crapName = name;
        crapDescription = desc;
        crapType = type;
        crapMsrp = msrp;
        imageFilepath = imgFilepath;
    }
}
