﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactor_ReactionBase : ScriptableObject
{
    public abstract void InteractorReacts(Object_InteractorBase interactor);
}
