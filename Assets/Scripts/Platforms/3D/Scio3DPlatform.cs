﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scio3DPlatform : Platform
{
    public override void SetupPlayerObject(GameObject loadedModel, SaveData data)
    {
        base.SetupPlayerObject(loadedModel, data);

        loadedModel.AddComponent<InteractFlat3D>();
    }

    public override void SetupEditorObject(GameObject loadedModel, SaveData data)
    {
        base.SetupEditorObject(loadedModel, data);

        loadedModel.AddComponent<EditorTransform3D>();
    }
}
