using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformBtn : MonoBehaviour
{
    public bool e;

    private void OnMouseDown()
    {
        print("asdasds");
        gameObject.transform.GetChild(0).GetComponent<Plataform>().OnClick();
    }
}
