using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChineseLocalization : MonoBehaviour {


    public bool IsChinese { get {
            return Application.systemLanguage == SystemLanguage.Chinese ||
            Application.systemLanguage == SystemLanguage.ChineseSimplified ||
            Application.systemLanguage == SystemLanguage.ChineseTraditional;
        } }


    public GameObject[] chineseOnlyGameobjects;
    public GameObject[] chineseNoGameobjects;
    private void Awake()
    {
        if (!IsChinese)
        {
            foreach (var g in chineseOnlyGameobjects)
            {
                g.SetActive(false);
            }
        }
        if (IsChinese)
        {
            foreach (var g in chineseNoGameobjects)
            {
                g.SetActive(false);
            }
        }
    }
    
}
