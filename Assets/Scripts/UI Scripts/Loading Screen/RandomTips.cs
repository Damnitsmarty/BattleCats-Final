using UnityEngine;
using System.Collections;

public class RandomTips : MonoBehaviour
{
    public string[] tips =
    {
            "Watch your cat’s energy! A tired cat takes longer to train.",
            "The rarer the cat, the better it’s Cattributes!",
            "The higher the cattributes, the more Battlecoins you earn!",
            "Don’t ignore an unused cat! Find it a new home on the Marketplace!",
            "Keep an eye on the latest Battlecats news!",
            "Found any legendary cats, yet? Earn Medals to increase your chances!",
            "Check the Marketplace regularly!",
            "Upgrade rooms to speed up training times!",
            "Train Cats regularly to ensure they stay in perfect shape!",
            "Not training can have a catastrophic outcome.",
            "A cat ‘gotta eat! Feed your cats regularly.",
            "Check the calendar for details on the next Battlecats event!",
            "Listen to your cats! If you hear a hiss, someone needs a break.",
            "Love is a 4-letter word. So is Gain. Train power often.",
            "Ran out of space? Enter the build menu to demolish rooms.",
            "Unhappy with a cat’s name? Change it by tapping on the cat!",
            "Earn more Battlecoins by competing with other players!",
            "Medals can only be earned in official Battlecats events!",
            "Scout rarer cats to reach higher Cattribute levels. ",
            "Check out More 4 for more games!",
            "Check back in regularly!",
            "Keep a look out for seasonal events.",
            "Check out More 4 for more games!"
    };
    public string[] puns = 
    {
        "The path to victory is small, fluffy and might purr a little.",
        "Eye of the Tiger.",
        "Pawsome.",
        "Meow.",
        "DRAAGOO!",
        "Check Meowt!",
        "Cat pun.",
        "Battledogs doesn’t sound as good.",
        "This is a very serious game. Fur-real."
    };
    int currentTip = 0;


    public void NewTip()
    {
        //return if there are no tips or puns to display
        if (tips.Length < 1 || puns.Length < 1) return;
        //
        string res = "";
        if (currentTip % 2 == 0) res = "<size=9>" + puns[Random.Range(0, puns.Length - 1)] + "</size>";
        else res = "<size=10>Tip:</size>\n\n" + tips[Random.Range(0, tips.Length - 1)];

        GetComponent<UnityEngine.UI.Text>().text = res;
        currentTip++;
    }
}
