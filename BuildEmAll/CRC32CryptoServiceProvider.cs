// Copyright (c) Damien Guard. All rights reserved.
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// https://github.com/damieng/DamienGKit/blob/master/CSharp/DamienG.Library/Security/Cryptography/Crc32.cs
// Modified by BuildEmAll. All rights reserved.

using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace BuildEmAll
{
    /// <summary>
    /// Implements a 32-bit CRC hash algorithm compatible with Zip etc.
    /// </summary>
    /// <remarks>
    /// If you need to call multiple times for the same data either use the HashAlgorithm
    /// interface or remember that the result of one Compute call needs to be ~ (XOR) before
    /// being passed in as the seed for the next Compute call.
    /// </remarks>
    public sealed class CRC32CryptoServiceProvider : HashAlgorithm
    {
        /// DefaultPolynomial
        public const UInt32 DefaultPolynomial = 0xedb88320u;
        /// DefaultSeed
        public const UInt32 DefaultSeed = 0xffffffffu;
        /// defaultTable
        static UInt32[] defaultTable;
        /// seed
        readonly UInt32 seed;
        /// table
        readonly UInt32[] table;
        /// hash
        UInt32 hash;

        /// <summary>
        /// CRC32CryptoServiceProvider Constructor
        /// </summary>
        public CRC32CryptoServiceProvider() : this(DefaultPolynomial, DefaultSeed)
        {

        }

        /// <summary>
        /// CRC32CryptoServiceProvider Constructor Overloaded
        /// </summary>
        /// <param name="polynomial"></param>
        /// <param name="seed"></param>
        public CRC32CryptoServiceProvider(UInt32 polynomial, UInt32 seed)
        {
            table = InitializeTable(polynomial);
            this.seed = hash = seed;
        }

        /// <summary>
        /// Initialize
        /// </summary>
        public override void Initialize()
        {
            hash = seed;
        }

        /// <summary>
        /// HashCore
        /// </summary>
        /// <param name="array"></param>
        /// <param name="ibStart"></param>
        /// <param name="cbSize"></param>
        protected override void HashCore(byte[] array, int ibStart, int cbSize)
        {
            hash = CalculateHash(table, hash, array, ibStart, cbSize);
        }

        /// <summary>
        /// HashFinal
        /// </summary>
        /// <returns></returns>
        protected override byte[] HashFinal()
        {
            var hashBuffer = UInt32ToBigEndianBytes(~hash);
            HashValue = hashBuffer;
            return hashBuffer;
        }

        /// <summary>
        /// HashSize
        /// </summary>
        public override int HashSize
        {
            get { return 32; }
        }

        /// <summary>
        /// Compute
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static UInt32 Compute(byte[] buffer)
        {
            return Compute(DefaultSeed, buffer);
        }

        /// <summary>
        /// Compute
        /// </summary>
        /// <param name="seed"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static UInt32 Compute(UInt32 seed, byte[] buffer)
        {
            return Compute(DefaultPolynomial, seed, buffer);
        }

        /// <summary>
        /// Compute
        /// </summary>
        /// <param name="polynomial"></param>
        /// <param name="seed"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static UInt32 Compute(UInt32 polynomial, UInt32 seed, byte[] buffer)
        {
            return ~CalculateHash(InitializeTable(polynomial), seed, buffer, 0, buffer.Length);
        }

        /// <summary>
        /// InitializeTable
        /// </summary>
        /// <param name="polynomial"></param>
        /// <returns></returns>
        static UInt32[] InitializeTable(UInt32 polynomial)
        {
            if (polynomial == DefaultPolynomial && defaultTable != null)
                return defaultTable;

            var createTable = new UInt32[256];
            for (var i = 0; i < 256; i++)
            {
                var entry = (UInt32)i;
                for (var j = 0; j < 8; j++)
                    if ((entry & 1) == 1)
                        entry = (entry >> 1) ^ polynomial;
                    else
                        entry = entry >> 1;
                createTable[i] = entry;
            }

            if (polynomial == DefaultPolynomial)
                defaultTable = createTable;

            return createTable;
        }

        /// <summary>
        /// CalculateHash
        /// </summary>
        /// <param name="table"></param>
        /// <param name="seed"></param>
        /// <param name="buffer"></param>
        /// <param name="start"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        static UInt32 CalculateHash(UInt32[] table, UInt32 seed, IList<byte> buffer, int start, int size)
        {
            var hash = seed;
            for (var i = start; i < start + size; i++)
                hash = (hash >> 8) ^ table[buffer[i] ^ hash & 0xff];
            return hash;
        }

        /// <summary>
        /// UInt32ToBigEndianBytes
        /// </summary>
        /// <param name="uint32"></param>
        /// <returns></returns>
        static byte[] UInt32ToBigEndianBytes(UInt32 uint32)
        {
            var result = BitConverter.GetBytes(uint32);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(result);

            return result;
        }
    }
}
