using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MPTPlayerPlateUI : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI playerName;
    [SerializeField]
    public GameObject healthBarGameObject;
    [SerializeField]
    public Image healthBar;
    [SerializeField]
    public GameObject healthNumberGameObject;
    [SerializeField]
    public TextMeshProUGUI healthNumber;
    [SerializeField]
    public GameObject usecPlate;
    [SerializeField]
    public GameObject bearPlate;

    public void SetNameText(String text)
    {
        this.playerName.SetText(text);
    }

    public void setHealthNumberText(String text)
    {
        this.healthNumber.SetText(text);
    }
}
