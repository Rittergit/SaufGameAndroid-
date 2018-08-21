using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public static class PlayerList{

    public static Player[] playList;

    public static void initList(string[] plist)
    {
        playList = new Player[plist.Length];
        for(int i = 0; i< plist.Length;i++ )
        {
            playList[i].SetName(plist[i]);
        }



    }


    
}
