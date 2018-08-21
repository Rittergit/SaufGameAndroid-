using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameBehavior : MonoBehaviour {

    public string[] playerList;
    private int actualPlayer = 0;
    public int maxSchlucke;
    private string remWord;

    // Use this for initialization
    void Start () {
        for(int i =0; i < PlayerList.playList.Length; i++)
        {
            Debug.Log(PlayerList.playList[i].name);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (GameHandler.RollTurned == true)
        {
            Debug.Log("roll turned läuft");
            GameHandler.RollTurned = false;
            float x = Random.value;
            int schlucke = 2;

            actualPlayer = Mathf.RoundToInt(x*(PlayerList.playList.Length)-1);

            int auf = GameHandler.task;





            switch (auf)
            {
                case 0:
                case 1:
                case 2:
                    GameHandler.textSet = PlayerList.playList[actualPlayer].name + " trinkt " + schlucke + " Schlücke";
                    break;
                case 3:
                case 4:
                case 5:
                    GameHandler.textSet = PlayerList.playList[actualPlayer].name + " verteilt " + schlucke + " Schlücke";
                    break;
                case 6:
                    GameHandler.textSet = "Yay, alle dürfen " + schlucke + " Schlücke trinken";
                    break;
                case 7:
                    bool gotPlayer = false;
                    while (!gotPlayer)
                    {
                        if (PlayerList.playList[actualPlayer].remWord == null)
                        {
                            remWord = GameHandler.words[Mathf.RoundToInt(Random.value* GameHandler.words.Length)];
                            GameHandler.textSet = PlayerList.playList[actualPlayer].name + " merkt sich das Wort: " + remWord;
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
                case 8:
                    bool got1Player = false;
                    while (!got1Player)
                    {
                        if (PlayerList.playList[actualPlayer].remWord != null)
                        {
                            
                            GameHandler.textSet = PlayerList.playList[actualPlayer].name + " sagt sein Wort oder trinkt 4 Schlücke";
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
                default:
                    GameHandler.textSet = "Alle Saufen";
                    break;
            }

        }
    }


}
