﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// A matrix whose element is 8UC3 (cv::Mat_&lt;cv::Vec3b&gt;)
    /// </summary>
    public class MatOfByte3 : Mat, ITypeSpecificMat<Vec3b>
    {
        private const int ThisDepth = MatType.CV_8U;
        private const int ThisChannels = 3;

        #region Init
        /// <summary>
        /// 
        /// </summary>
        public MatOfByte3()
            : base()
        {
        }

        /// <summary>
        /// Initializes by cv::Mat* pointer
        /// </summary>
        /// <param name="ptr"></param>
        public MatOfByte3(IntPtr ptr)
            : base(ptr)
        {
        }

        /// <summary>
        /// Initializes by Mat object
        /// </summary>
        /// <param name="mat"></param>
        public MatOfByte3(Mat mat)
            : base(mat.CvPtr)
        {
        }

        /// <summary>
        /// Initializes and copys array data to this
        /// </summary>
        /// <param name="arr"></param>
        public MatOfByte3(params Vec3b[] arr)
            : base()
        {
            if (arr == null)
                throw new ArgumentNullException("arr");
            if (arr.Length == 0)
                throw new ArgumentException("arr.Length == 0");
            int numElems = arr.Length;
            Create(numElems, 1, MatType.MakeType(ThisDepth, ThisChannels));
            SetArray(0, 0, arr);
        }
        /// <summary>
        /// Initializes and copys array data to this
        /// </summary>
        /// <param name="enumerable"></param>
        public MatOfByte3(IEnumerable<Vec3b> enumerable)
            : this(EnumerableEx.ToArray(enumerable))
        {
        }

        /// <summary>
        /// Initializes and copys array data to this
        /// </summary>
        /// <param name="arr"></param>
        public MatOfByte3(params byte[] arr)
            : base()
        {
            if (arr == null)
                throw new ArgumentNullException("arr");
            if (arr.Length == 0)
                throw new ArgumentException("arr.Length == 0");
            int numElems = arr.Length / ThisChannels;
            Create(numElems, 1, MatType.MakeType(ThisDepth, ThisChannels));
            SetArray(0, 0, arr);
        }
        /// <summary>
        /// Initializes and copys array data to this
        /// </summary>
        /// <param name="enumerable"></param>
        public MatOfByte3(IEnumerable<byte> enumerable)
            : this(EnumerableEx.ToArray(enumerable))
        {
        }
        #endregion

        #region Indexer
        /// <summary>
        /// 
        /// </summary>
        public sealed unsafe class Indexer : IndexerBase<Vec3b>
        {
            private readonly byte* ptr;

            internal Indexer(Mat parent)
                : base(parent)
            {
                this.ptr = (byte*)parent.Data.ToPointer();
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="i0"></param>
            /// <returns></returns>
            public override Vec3b this[int i0]
            {
                get
                {
                    return *(Vec3b*)(ptr + (steps[0] * i0));
                }
                set
                {
                    *(Vec3b*)(ptr + (steps[0] * i0)) = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="i0"></param>
            /// <param name="i1"></param>
            /// <returns></returns>
            public override Vec3b this[int i0, int i1]
            {
                get
                {
                    return *(Vec3b*)(ptr + (steps[0] * i0) + (steps[1] * i1));
                }
                set
                {
                    *(Vec3b*)(ptr + (steps[0] * i0) + (steps[1] * i1)) = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="i0"></param>
            /// <param name="i1"></param>
            /// <param name="i2"></param>
            /// <returns></returns>
            public override Vec3b this[int i0, int i1, int i2]
            {
                get
                {
                    return *(Vec3b*)(ptr + (steps[0] * i0) + (steps[1] * i1) + (steps[2] * i2));
                }
                set
                {
                    *(Vec3b*)(ptr + (steps[0] * i0) + (steps[1] * i1) + (steps[2] * i2)) = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="idx"></param>
            /// <returns></returns>
            public override Vec3b this[params int[] idx]
            {
                get
                {
                    long offset = 0;
                    for (int i = 0; i < idx.Length; i++)
                    {
                        offset += steps[i] * idx[i];
                    }
                    return *(Vec3b*)(ptr + offset);
                }
                set
                {
                    long offset = 0;
                    for (int i = 0; i < idx.Length; i++)
                    {
                        offset += steps[i] * idx[i];
                    }
                    *(Vec3b*)(ptr + offset) = value;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Indexer GetIndexer() 
        {
            return new Indexer(this);
        }
        #endregion

        #region FromArray
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        public static MatOfByte3 FromArray(params Vec3b[] arr)
        {
            return new MatOfByte3(arr);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumerable"></param>
        public static MatOfByte3 FromArray(IEnumerable<Vec3b> enumerable)
        {
            return new MatOfByte3(enumerable);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        public static MatOfByte3 FromPrimitiveArray(params byte[] arr)
        {
            return new MatOfByte3(arr);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumerable"></param>
        public static MatOfByte3 FromPrimitiveArray(IEnumerable<byte> enumerable)
        {
            return new MatOfByte3(enumerable);
        }
        #endregion

        #region ToArray
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vec3b[] ToArray()
        {
            /*int num = CheckVector(ThisChannels, ThisDepth);
            if (num < 0)
                throw new OpenCvSharpException("Native Mat has unexpected type or size: " + ToString());*/
            int numOfElems = Rows * Cols;
            if (numOfElems == 0)
                return new Vec3b[0];
            Vec3b[] arr = new Vec3b[numOfElems];
            GetArray(0, 0, arr);
            return arr;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte[] ToPrimitiveArray()
        {
            /*int num = CheckVector(ThisChannels, ThisDepth);
            if (num < 0)
                throw new OpenCvSharpException("Native Mat has unexpected type or size: " + ToString());*/
            int numOfElems = Rows * Cols;
            if (numOfElems == 0)
                return new byte[0];
            byte[] arr = new byte[numOfElems * ThisChannels];
            GetArray(0, 0, arr);
            return arr;
        }
        #endregion
    }
}
