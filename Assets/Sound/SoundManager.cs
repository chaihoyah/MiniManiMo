using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public AudioClip BoxOpen;
    public AudioClip BoxResultBad;
    public AudioClip BoxResultGood;
    public AudioClip Button;
    public AudioClip JamsuDie;
    public AudioClip Ending;
    public AudioClip JamsuMonster;
    public AudioClip PickGameBoxFloor;
    public AudioClip Reborn;
    public AudioClip StartingSound;
    public AudioClip StoneFloor;
    public AudioClip ThrowingStone;
    public AudioClip Walk;
    public AudioClip WallCollide;
    public AudioClip Wolf;
    public AudioClip WolfGameDie;
    public AudioClip WallBack;
    public AudioClip PartyTime;
    public AudioClip Coin;
    public AudioClip StartSound;
    public AudioClip DDRSound;
    public AudioClip JamsuSpeedStart;
    public AudioClip JamsuAlarm;
    public AudioClip BHMonsterHit;
    public AudioClip BHShot;
    public AudioClip BHLightning;
    public AudioClip BHWall;
    public AudioClip BHFire;
    public AudioClip BHPlayerHit;
    public AudioClip PizzaMove;
    public AudioClip PickMoneyInsert;
    public AudioClip BHWeaponChange;

    public AudioSource myAudio;

    public static SoundManager soundManager;
    void Awake()
    {
        if (SoundManager.soundManager == null)
            SoundManager.soundManager = this;
        myAudio.volume = soundManager.myAudio.volume;
    }
    public void PlayBoxOpen()
    {
        myAudio.PlayOneShot(BoxOpen);
    }

    public void PlayBoxResultBad()
    {
        myAudio.PlayOneShot(BoxResultBad);
    }

    public void PlayBoxResultGood()
    {
        myAudio.PlayOneShot(BoxResultGood);
    }

    public void PlayButton()
    {
        myAudio.PlayOneShot(Button);
    }
    
    public void PlayJamsuDie()
    {
        myAudio.PlayOneShot(JamsuDie);
    }

    public void PlayEnding()
    {
        myAudio.PlayOneShot(Ending);
    }

    public void PlayJamsuMonster()
    {
        myAudio.PlayOneShot(JamsuMonster);
    }

    public void PlayPickGameBoxFloor()
    {
        myAudio.PlayOneShot(PickGameBoxFloor);
    }

    public void PlayReborn()
    {
        myAudio.PlayOneShot(Reborn);
    }

    public void PlatStartingSound()
    {
        myAudio.PlayOneShot(StartingSound);
    }

    public void PlayStoneFloor()
    {
        myAudio.PlayOneShot(StoneFloor);
    }

    public void PlayThrowingStone()
    {
        myAudio.PlayOneShot(ThrowingStone);
    }

    public void PlayWalk()
    {
        myAudio.PlayOneShot(Walk);
    }

    public void PlayWallCollide()
    {
        myAudio.PlayOneShot(WallCollide);
    }
    
    public void PlayWolf()
    {
        myAudio.PlayOneShot(Wolf);
    }

    public void PlayWolfGameDie()
    {
        myAudio.PlayOneShot(WolfGameDie);
    }
    public void PlayBackWall()
    {
        myAudio.PlayOneShot(WallBack);
    }
    public void PlayPartyTime()
    {
        myAudio.PlayOneShot(PartyTime);
    }
    public void PlayCoin()
    {
        myAudio.PlayOneShot(Coin);
    }

    public void PlayStart()
    {
        myAudio.PlayOneShot(StartSound);
    }

    public void PlayDDR()
    {
        myAudio.PlayOneShot(DDRSound);
    }
    public void PlayStop()
    {
        myAudio.Stop();
    }

    public void PlayJamsuSpeedStart()
    {
        myAudio.PlayOneShot(JamsuSpeedStart);
    }
    public void PlayJamsuAlarm()
    {
        myAudio.PlayOneShot(JamsuAlarm);
    }

    public void PlayBHMonsterHit()
    {
        myAudio.PlayOneShot(BHMonsterHit);
    }

    public void PlayBHWall()
    {
        myAudio.PlayOneShot(BHWall);
    }

    public void PlayBHShot()
    {
        myAudio.PlayOneShot(BHShot);
    }

    public void PlayBHLightning()
    {
        myAudio.PlayOneShot(BHLightning);
    }

    public void PlayBHFire()
    {
        myAudio.PlayOneShot(BHFire);
    }

    public void PlayPlayerHit()
    {
        myAudio.PlayOneShot(BHPlayerHit);
    }

    public void PlayPizzaMove()
    {
        myAudio.PlayOneShot(PizzaMove);
    }

    public void PlayPickMoneyInsert()
    {
        myAudio.PlayOneShot(PickMoneyInsert);
    }

    public void PlayBHWeaponChange()
    {
        myAudio.PlayOneShot(BHWeaponChange);
    }

    void Update()
    {
        myAudio.volume = VolumeControlScript.Volume;
        soundManager.myAudio.volume = myAudio.volume;
    }
}
