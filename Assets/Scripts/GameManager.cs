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

    private List<DialogueOption> dialogueList;
    public List<DialogueOption> DialogueList
    {
        get
        {
            return dialogueList;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        masterCrapList = new List<Crap>();
        dialogueList = new List<DialogueOption>();

        SetupCrapList();
        //PrintCrapList();
        SetupDialogueList();

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

    public void SetupDialogueList()
    {
        string path = "Assets/Definitions/dialogue.txt";
        string[] lines = System.IO.File.ReadAllLines(path);
        for (int i = 0; i < lines.Length; i++)
        {
            string[] dialogueInfo = lines[i].Split('\t');
            for (int j = 0; j < dialogueInfo.Length; j++)
            {
                DialogueOption d = new DialogueOption();
                d.SetupDialogueOption(dialogueInfo[0],
                    float.Parse(dialogueInfo[1]),
                    (CrapCategory)int.Parse(dialogueInfo[2]),
                    (CrapCategory)int.Parse(dialogueInfo[3])
                );
                dialogueList.Add(d);
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
