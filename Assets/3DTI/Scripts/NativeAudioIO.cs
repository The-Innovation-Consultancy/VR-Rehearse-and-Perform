using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AOT;
using UnityEngine;
#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif

public class NativeAudioIO : IDisposable
{
    

    public NativeAudioIO (int sampleRate, int bufferSize) 
    {
        #if UNITY_ANDROID && !UNITY_EDITOR // ? PLATFORM_ANDROID
        
        // NOTE: Audio Engine is instantiated Android side
        _context = NativeAudioIOBridge.getAudioEngineInstance();

        #else
        _context = NativeAudioIOBridge.New (sampleRate, bufferSize);
        #endif

        gch = GCHandle.Alloc(this);
        
        if (_context == IntPtr.Zero)
            Application.Quit();
    }

    public void Dispose()
    {
        FreeAudioDevice();
    }

    public void SetupAudioDevice(int inChannels, int outChannels)
    {
        NativeAudioIOBridge.SetChannels (_context, inChannels, outChannels);
    }

    private void FreeAudioDevice()
    {
        #if UNITY_ANDROID && !UNITY_EDITOR
        // This is cleaned up by the Android application
        #else
        if (_context != IntPtr.Zero)
        {
            NativeAudioIOBridge.Free(_context);
            GC.KeepAlive(_context);
        }
        #endif
        if (gch.IsAllocated) gch.Free();
    }

    public void SetBlockSize(int blockSize)
    {
        NativeAudioIOBridge.SetBlockSize(_context, blockSize);
    }

    public int GetBlockSize()
    {
        return NativeAudioIOBridge.GetBlockSize(_context);
    }

    public int GetSampleRate()
    {
        return NativeAudioIOBridge.GetSampleRate(_context);
    }

    public void EnableProcessing (bool enable)
    {
        NativeAudioIOBridge.EnableProcessing (_context, enable);
    }

    public void EnableMicrophone (bool enable)
    {
        NativeAudioIOBridge.EnableMicrophone (_context, enable);
    }

    public void EnableTestNoise (bool enable)
    {
        NativeAudioIOBridge.EnableTestNoise (_context, enable);
    }

    public void SetProcessor (IntPtr processor)
    {
        NativeAudioIOBridge.SetProcessor (_context, processor);
    }

    /*
    public void Process(float[] buffer, int numFrames) {
       
            NativeAudioIOBridge.ProcessInterleaved (_context, buffer, numFrames);
    }
    
    */
    private readonly GCHandle gch;
	private readonly IntPtr _context = IntPtr.Zero; // handle into unmanaged memory
}
 