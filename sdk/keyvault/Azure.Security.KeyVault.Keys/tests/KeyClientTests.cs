﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.Testing;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class KeyClientTests: ClientTestBase
    {
        public KeyClientTests(bool isAsync) : base(isAsync)
        {
            Client = InstrumentClient(new KeyClient(new Uri("http://localhost"), new DefaultAzureCredential()));
        }

        public KeyClient Client { get; set; }

        [Test]
        public void CreateKeyArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.CreateKeyAsync(null, KeyType.Ec));
            Assert.ThrowsAsync<ArgumentException>(() => Client.CreateKeyAsync("name", default));
            Assert.ThrowsAsync<ArgumentException>(() => Client.CreateKeyAsync(string.Empty, KeyType.Ec));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.CreateEcKeyAsync(null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.CreateRsaKeyAsync(null));
        }

        [Test]
        public void UpdateKeyArgumentValidation()
        {
            var keyOperations = new List<KeyOperation>() { KeyOperation.Sign };
            var key = new KeyBase("name");

            Assert.ThrowsAsync<ArgumentNullException>(() => Client.UpdateKeyAsync(null, null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.UpdateKeyAsync(null, keyOperations));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.UpdateKeyAsync(key, null));
        }

        [Test]
        public void RestoreKeyArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RestoreKeyAsync(null));
        }

        [Test]
        public void PurgeDeletedKeyArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.PurgeDeletedKeyAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.PurgeDeletedKeyAsync(string.Empty));
        }

        [Test]
        public void GetKeyArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.GetKeyAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.GetKeyAsync(string.Empty));
        }

        [Test]
        public void DeleteKeyArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.DeleteKeyAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.DeleteKeyAsync(string.Empty));
        }

        [Test]
        public void GetDeletedKeyArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.GetDeletedKeyAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.GetDeletedKeyAsync(string.Empty));
        }

        [Test]
        public void RecoverDeletedKeyArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecoverDeletedKeyAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.RecoverDeletedKeyAsync(string.Empty));
        }

        [Test]
        public void BackupKeyArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.BackupKeyAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.BackupKeyAsync(string.Empty));
        }

        [Test]
        public void ImportKeyArgumentValidation()
        {
            var keyMaterial = new JsonWebKey();
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.ImportKeyAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.ImportKeyAsync(string.Empty, keyMaterial));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.ImportKeyAsync(null, keyMaterial));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.ImportKeyAsync(null, null));
        }

        [Test]
        public void GetKeyVersionsArgumentValidation()
        {
            Assert.Throws<ArgumentNullException>(() => Client.GetKeyVersionsAsync(null));
            Assert.Throws<ArgumentException>(() => Client.GetKeyVersionsAsync(string.Empty));
        }
    }
}
