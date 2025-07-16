using System;
using System.IO;
using Unity.Collections;
using UnityEngine;

namespace YVR.Enterprise.Camera
{
    public class UndistortionMap
    {
        public readonly NativeArray<float> xDataArray;
        public readonly NativeArray<float> yDataArray;

        public UndistortionMap(int width, int height, string mapXFile, string mapYFile)
        {
            xDataArray = LoadLut(mapXFile, width * height);
            yDataArray = LoadLut(mapYFile, width * height);
        }

        private NativeArray<float> LoadLut(string resourceName, int length)
        {
            var binAsset = Resources.Load<TextAsset>(resourceName);
            if (binAsset == null)
                throw new FileNotFoundException("Resource not found: " + resourceName);

            byte[] bytes = binAsset.bytes;

            var arr = new NativeArray<float>(length, Allocator.Persistent);
            for (int i = 0; i < length; ++i)
                arr[i] = BitConverter.ToSingle(bytes, i * 4);
            return arr;
        }
    }
}