﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Core.Testing;
using Azure.Identity;
using Azure.Security.KeyVault.Keys.Cryptography;
using NUnit.Framework;
using System;
using System.IO;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class CryptographyClientTests : ClientTestBase
    {
        public CryptographyClientTests(bool isAsync) : base(isAsync)
        {
            Client = InstrumentClient(new CryptographyClient(new Uri("http://localhost"), new DefaultAzureCredential()));
        }

        public CryptographyClient Client { get; set; }

        [Test]
        public void ConstructorArgumentValidation()
        {
            Assert.Throws<ArgumentNullException>(() => new CryptographyClient(null, new DefaultAzureCredential()));
            Assert.Throws<ArgumentNullException>(() => new CryptographyClient(new Uri("http://localhost"), null));
        }

        [Test]
        public void SignDataAsyncArugmentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.SignDataAsync(SignatureAlgorithm.ES256, (byte[])null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.SignDataAsync(SignatureAlgorithm.ES256, (Stream)null));
        }

        [Test]
        public void VerifyDataAsyncArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.VerifyDataAsync(SignatureAlgorithm.ES256, (byte[])null, new byte[0]));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.VerifyDataAsync(SignatureAlgorithm.ES256, (Stream)null, new byte[0]));
        }
    }
}
