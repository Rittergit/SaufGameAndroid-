using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public static class PlayerList{

    public static string[] playList;

    public static void initList(string[] plist)
    {
        playList = new string[plist.Length];
        for(int i = 0; i< plist.Length-1;i++ )
        {
            playList[i] = plist[i];
        }



    }


    
}
