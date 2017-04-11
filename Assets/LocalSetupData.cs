using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalSetupData : MonoBehaviour
{
    private Color myPlayerColor = new Color();
    public Color MyPlayerColor
    {
        get { return myPlayerColor; }
        set { myPlayerColor = value; }
    }
}
