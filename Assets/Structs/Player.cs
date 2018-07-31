using UnityEngine;

public struct Player
{
    public string name;
    public string remWord;
    public int remNumber;
    //Player next;
    public void SetName(string name)
    {
        this.name = name;
    }
}

public class Player2
{
    public string name;
    public string remWord;
    public int remNumber;
    public Player2 next;

}