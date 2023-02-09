using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200098A RID: 2442
public class ProFlareAtlas : MonoBehaviour
{
    // Token: 0x06003C9A RID: 15514 RVA: 0x00120878 File Offset: 0x0011EA78
    public void UpdateElementNameList()
    {
        elementNameList = new string[elementsList.Count];
        for (var i = 0; i < elementNameList.Length; i++) elementNameList[i] = elementsList[i].name;
    }

    // Token: 0x04003B32 RID: 15154
    public Texture2D texture;

    // Token: 0x04003B33 RID: 15155
    public int elementNumber;

    // Token: 0x04003B34 RID: 15156
    public bool editElements;

    // Token: 0x04003B35 RID: 15157
    [SerializeField] public List<Element> elementsList = new List<Element>();

    // Token: 0x04003B36 RID: 15158
    public string[] elementNameList;

    // Token: 0x0200098B RID: 2443
    [Serializable]
    public class Element
    {
        // Token: 0x04003B37 RID: 15159
        public string name = "Flare Element";

        // Token: 0x04003B38 RID: 15160
        public Rect UV = new Rect(0f, 0f, 1f, 1f);

        // Token: 0x04003B39 RID: 15161
        public bool Imported;
    }
}