﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Config
{
    public float jump_minHeight = .5f;
    public float jump_maxHeight = 3f;
    public float walk_velocity = 3f;
    public float fly_velocity = 5f;
    public float dash_normalDistance = 3f;
    public float dash_boostDistance = 5f;
}