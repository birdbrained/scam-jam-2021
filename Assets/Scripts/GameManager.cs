using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    private List<Crap> masterCrapList;// = new List<Crap>();
    public List<Crap> MasterCrapList
    {
        get
        {
            return masterCrapList;
        }
    }

    [SerializeField]
    private Text object1;
    [SerializeField]
    private Text object2;
    [SerializeField]
    private Text object3;

    private string[] dialogueOptions =
    {
        "It'll keep your face from getting any uglier!",
        "You'll rule the world!",
        "A must have. Even I kinda want it.....",
        "Just, k'now. Do it. Live your life!",
        "They are watching us, be quick O__O",
        "I know you want it.",
        "You don't like. Need. Your money.",
        "FOMO",
        "You will regret not getting it now!",
        "People have been eyeing that all day my dood...",
        "C'monnnnnnnnnnnnnn",
        "It solves your back pain!",
        "It washes cars! Bars! Mars! ....cars!",
        "It's edible!",
        "It smells nice :)",
        ":)",
        "It's good!",
        "You. Me. Let us stare into each others eyes, and ponder about buying my crap.",
        "It's the whim of causality. Buy it!",
        "Just do it!!!",
        "YOLO!",
        "Don't let your jean dreams be memes...!",
        "*stares menacingly*",
        "I bet this would compliment your getup!",
        "Why haven't you given me your money yet!?",
        "DSFRGDFAGDFSFGFSGFDGSDGADg",
        "Quality merchandising!",
        "A fine transaction.",
        "When you know, y'know. And I think you know, y'know?",
        "I get it. You want it. Guess what. You could have it...",
        "Money can be exchanged for goods and services. My goods and services!",
        "I swear it's not shit. S W E A R .",
        "It's our anniversary, surprise! Make me happy by buying this!",
        "A transaction is near in your future.",
        "The stars align.... for this very moment!!!",
        "Buy now! Act later...",
        "Buy now! Regret never!",
        "B U Y",
        "This was originally owner by George Washington.",
        "This was originally owner by George Lucas.",
        "This was originally owner by George Foreman.",
        "This was originally owner by George Clooney.",
        "This was originally owner by George.",
        "It'll kick-start a meaningful relationship!"
    };

    // Start is called before the first frame update
    void Start()
    {
        masterCrapList = new List<Crap>();
        SetupCrapList();
        PrintCrapList();

        GenerateRoundCrap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupCrapList()
    {
        string path = "Assets/Definitions/all_crap.txt";
        //StreamReader reader = new StreamReader(path);
        string[] lines = System.IO.File.ReadAllLines(path);
        for (int i = 0; i < lines.Length; i++)
        {
            //Debug.Log(i.ToString() + ": " + lines[i]);
            string[] crapInfo = lines[i].Split('\t');
            for (int j = 0; j < crapInfo.Length; j++)
            {
                //Debug.Log(i.ToString() + "-" + j.ToString() + ": " + crapInfo[j]);
                Crap c = new Crap();
                c.SetupCrap(int.Parse(crapInfo[0]),
                    crapInfo[1],
                    crapInfo[2],
                    (CrapCategory)int.Parse(crapInfo[3]),
                    float.Parse(crapInfo[4]),
                    crapInfo[5]
                );
                masterCrapList.Add(c);
            }
        }
    }

    public void PrintCrapList()
    {
        foreach (Crap c in masterCrapList)
        {
            Debug.Log(c.CrapName);
        }
    }

    public void GenerateRoundCrap()
    {
        if (masterCrapList.Count < 3)
            return;

        int i1 = Random.Range(0, masterCrapList.Count);
        int i2 = Random.Range(0, masterCrapList.Count);
        while (i2 == i1)
            i2 = Random.Range(0, masterCrapList.Count);
        int i3 = Random.Range(0, masterCrapList.Count);
        while (i3 == i1 && i3 == i2)
            i3 = Random.Range(0, masterCrapList.Count);

        if (object1 != null)
            object1.text = masterCrapList[i1].CrapName;
        if (object2 != null)
            object2.text = masterCrapList[i2].CrapName;
        if (object3 != null)
            object3.text = masterCrapList[i3].CrapName;
    }
}
