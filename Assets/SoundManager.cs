﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField]
    private AudioSource mainSource;

    [SerializeField]
    private AudioClip jump;
    [SerializeField]
    private AudioClip shot;
    [SerializeField]
    private AudioClip death;
    [SerializeField]
    private AudioClip explosion;

    bool waitingForMain = false;
    float mainDelay = 0;

    public void playJump()
    {
        mainSource.clip = jump;
        mainSource.Play();
    }

    public void playShot()
    {
        mainSource.clip = shot;
        mainSource.Play();
    }

    public void playDeath()
    {
        mainSource.clip = death;
        mainSource.Play();
    }

    public void playExplosion()
    {
        mainSource.clip = explosion;
        mainSource.Play();
    }
}
