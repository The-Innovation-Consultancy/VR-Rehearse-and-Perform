using UnityEngine;
using UnityEngine.Android;
using UnityEngine.Assertions;
using System;
using System.Collections;
using System.Runtime.InteropServices;

public class BinauralProcessor
{
    public IntPtr _context; // handle into unmanaged memory

    public BinauralProcessor(int sampleRate, int bufferSize) 
    {
        _context = BinauralBridge.New ((double)sampleRate, bufferSize);
    }

    ~BinauralProcessor()
    {
        BinauralBridge.Free (_context);
    }

    public void SetAzimuth (float azimuth)
    {
        BinauralBridge.SetParameter (_context, "Azimuth", azimuth);
    }

    public void SetDistance (float distance)
    {
        BinauralBridge.SetParameter (_context, "Distance", distance);
    }

    public void SetElevation (float elevation)
    {
        BinauralBridge.SetParameter (_context, "Elevation", elevation);
    }

    public bool SetReverbSize (int index)
    {
        return BinauralBridge.LoadBundledBRIR (_context, index);
    }

    public void ProcessAudio(float[] buffer, int numChannels) 
    {
        BinauralBridge.ProcessInlineInterleaved (_context, buffer, buffer.Length / numChannels);
    }
}