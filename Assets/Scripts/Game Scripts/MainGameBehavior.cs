﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameBehavior : MonoBehaviour {

    public string[] playerList;
    private int actualPlayer = 0;
    public int maxSchlucke;
    private string remWord;
    public Text text;

    // Use this for initialization
    void Start () {
        if (PlayerList.playList != null)
        {
            for(int i =0; i < PlayerList.playList.Length; i++)
            {
                Debug.Log(PlayerList.playList[i].name);
            }
        }
        else
        {
            PlayerList.playList = new Player[2];
            PlayerList.playList[0].name = "schwul";
            PlayerList.playList[1].name = "schwul";
        }
        text.text = "";
    }
	
	// Update is called once per frame
	void Update () {
        if (GameHandler.RollTurned == true)
        {
            Debug.Log("roll turned läuft");
            GameHandler.RollTurned = false;
            int schlucke = (int)(Random.value*3)+1;
            
            actualPlayer = (int)(Random.value*(PlayerList.playList.Length));     
            
            int task = GameHandler.sideList[GameHandler.task]-1;

            switch (task)
            {
                case 0:
                    text.text = PlayerList.playList[actualPlayer].name + " trinkt " + schlucke + " Schlücke";
                    // GameHandler.textSet = PlayerList.playList[actualPlayer].name + " trinkt " + schlucke + " Schlücke";
                    break;                    
                case 1:
                    text.text = PlayerList.playList[actualPlayer].name + " verteilt " + schlucke + " Schlücke";
                    // GameHandler.textSet = PlayerList.playList[actualPlayer].name + " verteilt " + schlucke + " Schlücke";
                    break;
                case 2:
                    text.text = "Yay, alle dürfen " + schlucke + " Schlücke trinken";
                    //GameHandler.textSet = "Yay, alle dürfen " + schlucke + " Schlücke trinken";
                    break;
                case 3:
                    bool gotPlayer = false;
                    while (!gotPlayer)
                    {
                        if (PlayerList.playList[actualPlayer].remWord == null)
                        {
                            remWord = GameHandler.words[(int)(Random.value* (GameHandler.words.Length-1))];
                            text.text = PlayerList.playList[actualPlayer].name + " merkt sich das Wort: '" + remWord+"'";
                            PlayerList.playList[actualPlayer].remWord = remWord;
                            GameHandler.noRem = false;
                            gotPlayer = true;
                        }
                        else
                        {
                            if (actualPlayer < PlayerList.playList.Length)
                            {
                                actualPlayer++;
                            }
                            else
                            {
                                actualPlayer = 0;
                            }                            
                        }
                    }
                    bool isLeft = false;
                    for(int i = 0; i<PlayerList.playList.Length; i++)
                    {
                        if (PlayerList.playList[i].remWord == null)
                        {
                            isLeft = true;
                        }
                    }

                    if (!isLeft)
                    {
                        GameHandler.allRem = true;
                    }
                    break;
                case 4:
                    bool got1Player = false;
                    while (!got1Player)
                    {
                        if (PlayerList.playList[actualPlayer].remWord != null)
                        {

                            text.text = PlayerList.playList[actualPlayer].name + " sag dein Wort oder trink 4 Schlücke";
                            PlayerList.playList[actualPlayer].remWord = null;
                            got1Player = true;
                        }
                        else
                        {
                            if (actualPlayer < PlayerList.playList.Length-1)
                            {
                                actualPlayer++;
                            }
                            else
                            {
                                actualPlayer = 0;
                            }
                        }
                    }
                    bool isOneLeft = false;
                    for (int i = 0; i < PlayerList.playList.Length; i++)
                    {
                        if (PlayerList.playList[i].remWord != null)
                        {
                            isOneLeft = true;
                        }
                    }
                    if (!isOneLeft)
                    {
                        GameHandler.noRem = true;
                    }
                    break;

                case 5:
                    text.text = "Kings-Cup: " + PlayerList.playList[actualPlayer].name + " ballert was in die Mitte";
                    break;
                case 6:
                    text.text = "Kings-Cup: " + PlayerList.playList[actualPlayer].name + " darf die Scheiße saufen";
                    break;
                case 7:
                    int r = (int)(Random.value * (PlayerList.playList.Length - 1)); 
                    text.text = PlayerList.playList[actualPlayer].name+ " denk dir für " +PlayerList.playList[r].name + " ein Wahrheit- oder Pflichtaufgabe aus";

                    break;
                default:
                    text.text = "Alle Saufen";
                    break;
            }

        }
    }


}
