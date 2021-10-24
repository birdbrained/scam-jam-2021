using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOption
{
    [SerializeField]
    private string optionText = "undefined";
    public string OptionText
    {
        get
        {
            return optionText;
        }
    }
    [SerializeField]
    private float modifier;
    public float Modifier
    {
        get
        {
            return modifier;
        }
    }
    [SerializeField]
    private CrapCategory bonusCategory = CrapCategory.CC_NULL;
    public CrapCategory BonusCategory
    {
        get
        {
            return bonusCategory;
        }
    }
    [SerializeField]
    private CrapCategory badCategory = CrapCategory.CC_NULL;
    public CrapCategory BadCategory
    {
        get
        {
            return BadCategory;
        }
    }

    public void SetupDialogueOption(string text, float mod, CrapCategory bonus, CrapCategory bad)
    {
        optionText = text;
        modifier = mod;
        bonusCategory = bonus;
        badCategory = bad;
    }
}
