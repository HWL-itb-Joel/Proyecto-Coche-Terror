using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightConfig : MonoBehaviour
{
    [SerializeField] GameObject light1;
    [SerializeField] GameObject light2;

    public void OnClick()
    {
        if (light1.active)
        {
            light1.SetActive(false);
            light2.SetActive(false);
        }
        else
        {
            light1.SetActive(true);
            light2.SetActive(true);
        }
    }

    public bool Lose()
    {
        if (light1.active)
        {
            Debug.Log("aihfiuwhf");
            return true;
        }
        else
        {
            return false;
        }
    }
}
