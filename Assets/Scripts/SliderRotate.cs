//
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

namespace Microsoft.MixedReality.Toolkit.Examples.Demos
{
    [AddComponentMenu("Scripts/MRTK/Examples/ShowSliderValue")]
    public class SliderRotate : MonoBehaviour
    {
        public float rotation;
        public GameObject thisObject;

        public void OnSliderUpdated(SliderEventData eventData)
        {
            rotation = eventData.NewValue;

            thisObject.transform.Rotate(rotation*10, 0f, 0f, Space.Self);
        }
    }
}