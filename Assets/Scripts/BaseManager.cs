using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour
{
    public Sprite lvl0;
    public Sprite lvl1;
    public Sprite lvl2;
    public Sprite lvl3;
    public Sprite lvl4;
    public Sprite lvl5;

    int baseLevel;

    SpriteRenderer baseManager;

    private void Start()
    {
        baseLevel = PlayerPrefs.GetInt("baselvl");
        baseManager = this.gameObject.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        switch(baseLevel)
        {
            case 0:
                baseManager.sprite = lvl0;
                break;
            case 1:
                baseManager.sprite = lvl1;
                break;
            case 2:
                baseManager.sprite = lvl2;
                break;
            case 3:
                baseManager.sprite = lvl3;
                break;
            case 4:
                baseManager.sprite =lvl4;
                break;
            case 5:
                baseManager.sprite = lvl5;
                break;
        }
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("baselvl",baseLevel);
        PlayerPrefs.Save();
    }
}
