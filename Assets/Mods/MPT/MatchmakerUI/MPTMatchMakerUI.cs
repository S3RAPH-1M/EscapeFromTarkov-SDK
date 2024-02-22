using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class MPTMatchMakerUI : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI serversNumberAmount;
    [SerializeField]
    public Button RefreshButton;
    [SerializeField]
    public Button RaidGroupJoinButton;
    [SerializeField]
    public Button RaidGroupHostButton;
    [SerializeField]
    public GameObject RaidGroupDefaultToClone;

    public void SetServerNumberText(String text)
    {
        this.serversNumberAmount.SetText(text);
    }

}
